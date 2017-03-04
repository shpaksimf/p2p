﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace P2P
{
    public partial class formMain : Form
    {
        delegate void StringToForm(string message);       //Делегат передающий строку
        delegate void ActionToForm();       //Делегат для выполнения функций без аргументов

        const int UdpPort = 58623;     //Номер UDO порта
        const int TcpPort = 1800;       //Номер TCP порта
        const string broadcastUdpAddress = "192.168.0.255";      //IP-адрес вещания

        UdpClient receivingUdpClient;      //Передатчик инф.
        UdpClient sendingUdpClient;        //Приемник инф.

        Thread receivingUdpThread;     //Поток приемника UDP
        Thread listenerTcpThread;       //Поток применика TCP

        FileSystemWatcher FSwatcher;        //Класс наблюдения за папкой share

        TcpListener TCPlistener;        //Класс приемника TCP


        string userName;    //Имя пользователя чата
        string localIP;     //IP текущего пользователя
        string thisUser;        //Строка с именем и IP текущего пользователя

        Int64 recievingFileSize;
        string recievingFileName;

        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            if (File.Exists("name.txt"))   //Если файл с именем существует
            {
                GetUserNameFromFile();      //Получить имя пользователя из файла
            }
            else
            {
                nameForm nf = new nameForm();     //Новая форма с именем
                nf.ShowDialog();      //Показать форму с именем
                this.Hide();        //Спрятать главню форму
                if (nf.itClose) this.Close();       //Если форму с именем закрыли, то закрыть и главную форму
                GetUserNameFromFile();      //Получить имя пользователя из файла
            }

            localIP = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();     //Получение IP текущего пользователя
            thisUser = userName + "_" + localIP;        //Строка с именем и IP текущего пользователя

            if (Directory.Exists("index")) Directory.Delete("index", true);      //Удаление папки index (для ее очистки)
            Directory.CreateDirectory("index");     //Создание папки index

            if (!Directory.Exists("share"))     //Если не существует папка share
            {
                Directory.CreateDirectory("share");     //Создать папку share
            }

            InitializeUdpSender();     //Инициализация UDP передатчика
            InitializeUdpReciever();       //Инициализация UDP приемника
            InitializeShareFolderCheck();       //Инициализация провеки папки share

            CreateIndexFile();      //Создать index-файл текущего пользователя
            SendIndexFile();        //Отправить index-файл всем пользователям
            SendIndexFileRequest();     //Отправить запрос index-файлов


            //////////////////////////////////////////////////////////////////////
            ThreadStart start = new ThreadStart(TCPListener);       //Поток приеника TCP
            listenerTcpThread = new Thread(start);
            listenerTcpThread.IsBackground = true;
            listenerTcpThread.Start();
            //////////////////////////////////////////////////////////

            MessageSend("***User " + userName + " is connected***");        //Сообщение о подключении пользователя к сети
        }

        private void GetUserNameFromFile()      //Получить имя пользователя из файла
        {
            FileStream fs = new FileStream("name.txt", FileMode.Open, FileAccess.Read);     //Файловый поток
            StreamReader sr = new StreamReader(fs);     //Поток чтения текстовых файлов
            userName = sr.ReadLine();       //Считывание первой строки файла
            sr.Close();     //Закрытие потока
            fs.Close();     //Закрытие потока
            this.Text = "Hello, " + userName + "!";     //Вывод имени в название формы
        }

        private void InitializeUdpSender()     //Инициализация передатчика
        {
            sendingUdpClient = new UdpClient(broadcastUdpAddress, UdpPort);      //Класс передатчика
            sendingUdpClient.EnableBroadcast = true;       //Разрешение вещания
        }

        private void InitializeUdpReciever()       //Инициализация приемника
        {
            receivingUdpClient = new UdpClient(UdpPort);      //Класс приемника
            ThreadStart start = new ThreadStart(UDPReceiver);      //Создание нового потока
            receivingUdpThread = new Thread(start);        //Создание нового потока
            receivingUdpThread.IsBackground = true;        //Фоновый режим работы потока
            receivingUdpThread.Start();        //Старт потока
        }

        private void UDPReceiver()
        {
            StringToForm messageDelegate = RecievedMessageAdd;       //Делегат принимаемого сообщения
            StringToForm leftingUserDelegate = DeleteUserFromLb;        //Делегат удаления пользователя
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, UdpPort);      //Сетевая конечная точка

            while (true)        //Бесконецный цикл
            {
                byte[] recieveData = receivingUdpClient.Receive(ref endPoint);    //Возвращает UDP-датаграмму, которая была послана удаленным узлом
                byte[] commandBytes = new byte[6];      //Массив байт комманды
                byte[] data = new byte[recieveData.Length - 6];     //Массив файл данных
                Array.Copy(recieveData, 6, data, 0, data.Length);       //Копирование данных в массив из принятого массива
                Array.Copy(recieveData, commandBytes, 6);       //Копирование байт команды из принятного массива

                string command = Encoding.Unicode.GetString(commandBytes);     //Преобразование команды в строку

                switch (command)        //Выбор действия исходя из команды
                {
                    case "RIF":      //Команда принятия индекс файла (RecieveIndexFile)
                        {
                            ProcessingIndexFile(data);      //Обработка принятого index-файла
                            break;    
                        }
                    case "UFR":     //Команда запроса файла у пользователя (UserFileRequest)
                        {
                            ProcessingUserFileRequest(data);        //Обработка запроса файла
                            break;
                        }
                    case "MSG":     //Команда сообщения (MeSsaGe)
                        {
                            string message = Encoding.Unicode.GetString(data);      //Преобразование массива байт в строку
                            Invoke(messageDelegate, message);       //Вывод строки в чат
                            break;
                        }
                    case "IFR":     //Команда запроса index-файла (IndexFileRequest)
                        {
                            if (Encoding.Unicode.GetString(data) != thisUser) SendIndexFile();      //Если запрос прислал не текущий пользователь, отправить index-файл
                            break;
                        }
                    case "ULP":    //Команда выхода пользователя из программы (UserLeftProgram) 
                        {
                            string leftingUser = Encoding.Unicode.GetString(data);      //Строка с имененм и IP удаляющегося пользователя
                            Invoke(leftingUserDelegate, leftingUser);       //Удаление пользователя из listBox
                            break;
                        }
                    default: return;        //Если неопознанная команда - ничего не предпринимать
                }
            }
        }       //UDP приемник

        private void RecievedMessageAdd(string message)        //Ф-я добавления сообщения в rtb
        {
            rtbChat.Text += "(" + DateTime.Now.ToLongTimeString() + ") " + message + "\n";       //Добавление в rtb принятого текста
        }

        private void ProcessingIndexFile(byte[] data)       //Обработка принятяного index-файла
        {
            StringToForm newUser = ProcessingNewUser;     //Создание делегата подключившегося пользовалетя

            FileStream fs = new FileStream("index/index.temp", FileMode.Create, FileAccess.Write);      //Поток зааписи временного файла
            fs.Write(data, 0, data.Length);     //Запись данных во временный файл
            fs.Close();     //Закрытие потока

            FileStream readTempFile = new FileStream("index/index.temp", FileMode.Open, FileAccess.Read);       //Поток чтения временного файла
            StreamReader sr = new StreamReader(readTempFile);           //Поток работы с текстовыми файлами
            string userInfo = sr.ReadLine();        //Чтение первой строки временного файла
            sr.Close();     //Закрытие потока
            readTempFile.Close();       //Закрытие потока

            if (userInfo != thisUser)       //Если присоеденившийся пользователь не текущий
            {
                File.Copy("index/index.temp", "index/" + userInfo + ".index", true);        //Копирование временного файла в index-файл пользователя
                Invoke(newUser, userInfo);       //Выполнение делегата в потоке, которому принадлежит базовый дескриптор управления
            }

            File.Delete("index/index.temp");        //Удаление временного файла
        }

        private void ProcessingNewUser(string connectedUser)      //Ф-я добавления пользователя в чат
        {
            if (lbUsers.Items.Contains(connectedUser))      //Если в списке есть подключившийся пользователь
            {
                if (lbUsers.SelectedIndex == lbUsers.Items.IndexOf(connectedUser))       //Если выбран элемент подключившегося пользователя
                {
                    lbUsers.SelectedItem = null;        
                    lbUsers.SelectedItem = connectedUser;       //Обновление его index-файла
                }
            }
            else lbUsers.Items.Add(connectedUser);        //Иначе добавление в lb нового пользователя
        }

        private async void ProcessingUserFileRequest(byte[] data)
        {
            StringToForm logWriteDelegate = LogWrite;       //Делегат записи строки в лог
            string fullRequest = Encoding.Unicode.GetString(data);      //Строка с полным запросом
            string[] request = fullRequest.Split('^');      //Разделение строки на подстроки
            if (request[0] == thisUser) return; // Если запрос пришел от себя - выйти из функции
            if (request[2] != localIP) return; // Если запрос не текущему пользователю - выйти из функции

            string fileName = request[1];       //Строка с именем файла
            string[] userInfo = request[0].Split('_');      //Строка с информацией о пользователе (имя и IP)
            string userIP = userInfo[1];        //Строка с IP пользователя, которому нужно отправить файл

            IPAddress address;      //Класс IP-адреса
            FileInfo file;      //Класс с информацией о файле
            FileStream fileStream;      //Поток работы с файлом
            if (!IPAddress.TryParse(userIP, out address))       //Если IP-адрес указан неверно
            {
                Invoke(logWriteDelegate,"Error with IP Address");       //Сообщение о неверном IP
                return;     //Выход из функции
            }
            try
            {  
                file = new FileInfo("share/"+fileName);             //Класс информации о файле
                fileStream = file.OpenRead();       //Открытие файла для чтения
            }
            catch
            {
                Invoke(logWriteDelegate, "Error opening file");     //Сообщение о ошибке открытия файла  
                return;     //Выйли из функции
            }

            TcpClient client = new TcpClient();     //Новый TCP клиент
            try
            {
                await client.ConnectAsync(address, TcpPort);        //Ожидание соединения
            }
            catch
            {
                Invoke(logWriteDelegate, "Error connecting to destination");        //Сообщение о ошибке соединения
                return;     //выйти из функции
            }

            NetworkStream ns = client.GetStream();      //Сетевой поток

            { // Отправка информации о файле (надежнее, чем по UDP)
                byte[] fileName1 = ASCIIEncoding.Unicode.GetBytes(file.Name);
                byte[] fileNameLength = BitConverter.GetBytes(fileName1.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await ns.WriteAsync(fileLength, 0, fileLength.Length);
                await ns.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await ns.WriteAsync(fileName1, 0, fileName1.Length);
            }

            // Отправка файла
            int read;
            int totalWritten = 0;
            byte[] buffer = new byte[32 * 1024]; // части файла по 32 кБ
            while ((read = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)       //Цикл отправки файла
            {
                await ns.WriteAsync(buffer, 0, read);       //Отправка части файла
                totalWritten += read;
            }

            fileStream.Dispose();
            fileStream.Close();
            client.Close();
            Invoke(logWriteDelegate, "The file " + fileName + " was downloaded by user " + userInfo[0]);        //Сообщение о скафивании файла пользователем
        }    

        private void DeleteUserFromLb(string leftingUser)       //Удаление пользователя из listbox
        {
            lbUsers.Items.Remove(leftingUser);      //Удаление пользователя
            lbFiles.Items.Clear();      //Очистка списка файлов
            btnDownload.Enabled = false;        //Отключение кнопки Download
        }

        private void LogWrite(string message)       //Запись строки в лог
        {
            rtbLog.Text += DateTime.Now.ToLongTimeString() + ": " + message + "\n";     //Запись строки с временем события
        }

        private void InitializeShareFolderCheck()       //Запуск мониторинга папки share
        {
            FSwatcher = new FileSystemWatcher("share");     //Класс налючения за папкой share
            FSwatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            FSwatcher.Changed += new FileSystemEventHandler(ShareFolderChanged);        //Событие при изменеии файла
            FSwatcher.Created += new FileSystemEventHandler(ShareFolderChanged);        //Событие при создании файла
            FSwatcher.Deleted += new FileSystemEventHandler(ShareFolderChanged);        //Событие при удалении файла
            FSwatcher.EnableRaisingEvents = true;       //Разрешение обработки событий
        }

        private void ShareFolderChanged(object source, FileSystemEventArgs e)        //Если есть изменения в папке share
        {
            try
            { 
                FSwatcher.EnableRaisingEvents = false;      //Запрет событий мониторинга папки share

                //Код ниже выполняется только один раз (при множественном вызове события - баг FileSystemWatcher)
                ActionToForm ATF1 = CreateIndexFile;        //Делегат создания index-файла
                ActionToForm ATF2 = SendIndexFile;      //Деленат отправки index-файла
                Invoke(ATF1);       //Создать index-файл
                Invoke(ATF2);       //Отправить index-файл
            }

            finally
            {
                FSwatcher.EnableRaisingEvents = true;       //Разрешение событий мониторинга папки share
            }
        }

        public void CreateIndexFile()       //Создание index-файла
        {
            StringToForm toLog = LogWrite;      //Делегат записи в лог
            FileStream fs = new FileStream(thisUser + ".index", FileMode.Create, FileAccess.Write);     //Поток записи index-файла
            StreamWriter sw = new StreamWriter(fs);     //Поток работы с текстовым файлом
            sw.WriteLine(thisUser);     //Запись в первую строку текущего пользователя
            foreach (string file in Directory.GetFiles("share"))        //Для каждого файла из папки share
            {
                FileInfo fi = new FileInfo(file);       //Класс с информацией о файле
                string fileInfo = thisUser + "^" + Path.GetFileName(file) + "^" + ComputeMD5Checksum(file) + "^" + fi.Length.ToString() + "\n";      //Строка с информацией о файле
                sw.Write(fileInfo);     //Запись строки с информацией о файле
            }
            sw.Close();     //Закрытие потока
            fs.Close();     //Закрытие потока
            Invoke(toLog, "Index file was created");        //Запись сообщения в лог
        }

        private string ComputeMD5Checksum(string path)      //Вычисление хеш суммы файла
        {
            FileStream fs = System.IO.File.OpenRead(path);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fileData = new byte[fs.Length];
            fs.Read(fileData, 0, (int)fs.Length);
            byte[] checkSum = md5.ComputeHash(fileData);
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            fs.Close();
            return result;
        }

        private void SendIndexFile()        //Отправка index-файла
        {
            StringToForm toLog = LogWrite;
            FileStream fs = new FileStream(thisUser + ".index", FileMode.Open, FileAccess.Read);        //Поток чтения index-файла текущего пользователя 
            byte[] command = Encoding.Unicode.GetBytes("RIF");     //Массив байт команды
            byte[] indexFile = new byte [fs.Length];        //Массив байт index-файла
            fs.Read(indexFile, 0, indexFile.Length);        //Чтение index-файла в массив байт
            byte[] toSend = command.Concat(indexFile).ToArray();        //Объединение байт команды и index-файла
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
            fs.Close();     //остановка потока
            Invoke(toLog, "Index file was sended");     //Сообщение в лог
        }

        private void SendIndexFileRequest()     //Отправка запроса index-файла
        {
            byte[] toSend = Encoding.Unicode.GetBytes("IFR"+thisUser);     //Массив байт запроса
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
        }

        private void butSend_Click(object sender, EventArgs e)      //Обработчик нажатия кнопки Send
        {
            tbMessage.Text = tbMessage.Text.TrimEnd(' ');       //Удаление пробелов из конца сообщения
            tbMessage.Text = tbMessage.Text.TrimStart(' ');     //Удаление пробелов с начала сообщения
            if (!string.IsNullOrEmpty(tbMessage.Text))      //Если сообщение не пустое
            {
                MessageSend(userName + ": " + tbMessage.Text);      //Отправка сообщения
                tbMessage.Clear();      //Очистка поля ввода
            }
            else return;        //Иначе выйти из функции
        }

        private void MessageSend(string message)       //Отправка сообщения в чат
        {
            byte[] toSend = Encoding.Unicode.GetBytes("MSG" + message);     //Преобразование в массив байт
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {
            //if (rtbChat.Lines.Length > 50) rtbChat.Text = rtbChat.Text.Remove(rtbChat.GetFirstCharIndexFromLine(0), rtbChat.Lines[0].Length + 1);     //Ограничение числа строк rtb
            rtbChat.SelectionStart = rtbChat.Text.Length;       //Автоматическая прокрутка rtb
            rtbChat.ScrollToCaret();        //Автоматическая прокрутка rtb
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;       //Автоматическая прокрутка rtb
            rtbLog.ScrollToCaret();        //Автоматическая прокрутка rtb
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)       //Обработчик выбора пользователя в списке
        {
            StringToForm toLog = LogWrite;
            if (lbUsers.SelectedItem == null) return;       //Если выбранный элемент не существует - выйти из функции
            lbFiles.Items.Clear();      //Очистка списка файлов
            btnDownload.Enabled = false;        //Включение кнопки Download
            try
            {
                FileStream fs = new FileStream("index/" + lbUsers.SelectedItem.ToString() + ".index", FileMode.Open, FileAccess.Read);      //Поток работы с файлом
                StreamReader sr = new StreamReader(fs);     //Поток работы с текстовым файлом
                sr.ReadLine();      //Чтение первой строки
                while (!sr.EndOfStream)     //Чтение всех строк до конца файла
                {
                    string mainstr = sr.ReadLine();     //Общая строка из файла
                    string[] str = mainstr.Split('^');      //Массив с частями общей строки
                    lbFiles.Items.Add(str[1]+ "^" +str[3] + " bytes");        //Добавление файла в lbFiles
                }
                sr.Close();     //Остановка потока
                fs.Close();     //Остановка потока
            }
            catch
            {
                Invoke(toLog, "Ошибка чтения списка файлов");        //вывод сообщения в лог
            }
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDownload.Enabled = true;     //Включение кнопки Download
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            recievingFileName = lbFiles.SelectedItem.ToString().Split('^')[0].TrimEnd();      //Строка с именем файла
            string selectedUser = lbUsers.SelectedItem.ToString().Split('_')[1];        //Строка с выбранным пользователем
            recievingFileSize = Convert.ToInt64(lbFiles.SelectedItem.ToString().Split('^')[1].Split(' ')[0]);       //Размер скачиваемого файла (в байтах)
     
            if (File.Exists("share/" + recievingFileName))       //Если уже существует такой файл
            {
                if (MessageBox.Show("File " + recievingFileName + " exist! Replace it?", "", MessageBoxButtons.YesNo) == DialogResult.No)        //Если результат диалога о замене файла отрицательный
                {
                    return;     //Выйти из функции
                }
            }
            string fileRequest = "UFR" + thisUser + "^" + recievingFileName + "^" + selectedUser;        //Строка с запросом файла
            byte[] toSend = Encoding.Unicode.GetBytes(fileRequest);     //Преобразование в массив байт
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
        }

        private async void TCPListener()      //Приемник TCP
        {
            StringToForm STF = LogWrite;        //Делегт записи в лог
            TCPlistener = new TcpListener(IPAddress.Any, TcpPort);      //Новый приемник TCP
            TCPlistener.Start();        //Запуск приеника TCP
            while (true)        //Бесконечный цикл
            {
                TcpClient client = await TCPlistener.AcceptTcpClientAsync();        //Ожидание подключения
                NetworkStream ns = client.GetStream();      //Класс сетевого потока

                FSwatcher.EnableRaisingEvents = false;      //Запрет прерываний наблюдателя за папкой share

                try
                {
                    long fileLength;        //Длина файла
                    string fileName;        //Строка с именем файла
                    {       //Получение информации о файле
                        byte[] fileNameBytes;
                        byte[] fileNameLengthBytes = new byte[4]; //int32
                        byte[] fileLengthBytes = new byte[8]; //int64

                        await ns.ReadAsync(fileLengthBytes, 0, 8); // int64
                        await ns.ReadAsync(fileNameLengthBytes, 0, 4); // int32
                        fileNameBytes = new byte[BitConverter.ToInt32(fileNameLengthBytes, 0)];
                        await ns.ReadAsync(fileNameBytes, 0, fileNameBytes.Length);

                        fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
                        fileName = "share/" + ASCIIEncoding.Unicode.GetString(fileNameBytes);
                    }

                    FileStream fileStream = File.Open(fileName, FileMode.Create);       //Поток работы с файлом

                    // Прием файла
                    int read;
                    int totalRead = 0;
                    byte[] buffer = new byte[32 * 1024]; // 32k chunks
                    while ((read = await ns.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, read);
                        totalRead += read;
                    }
                    fileStream.Close();     //Закрытие потока
                    Invoke(STF, "File " + Path.GetFileName(fileName) + " has been successfully downloaded!");       //Вывод сообщения в лог
                }
                catch
                {
                    Invoke(STF, "Some trouble with file download!");        //Вывод сообщения в лог
                }
                FSwatcher.EnableRaisingEvents = true;       //Разрешение прерываний наблюдателя за папкой share
                CreateIndexFile();      //Создание index-файла
                SendIndexFile();        //Отправка index-файла
            }
        }

        private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)        //Отправка сообщения по нажатию на Enter
            {
                butSend.PerformClick();     //Программное нажатие на кнопку
                tbMessage.Focus();     //Фокус на строке ввода сообщения
            }
        }      

        private void openShareFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("share");     //Открытие папки share
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageSend("***User " + userName + " disconnected***");        //Отправка сообщения в чат

            string fileRequest = "ULP" + thisUser;     //Отправка команды удаления пользователя
            byte[] toSend = Encoding.Unicode.GetBytes(fileRequest);     //Преобразование в массив байт
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов

            //Остановка всех потоков
            receivingUdpThread.Abort();     
            listenerTcpThread.Abort();
            receivingUdpClient.Close();
            sendingUdpClient.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
