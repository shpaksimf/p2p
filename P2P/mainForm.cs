using System;
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
        delegate void StringToForm(string message);       //Делегат принимаемого сообщения

        const int UdpPort = 58623;     //Номер порта
        const int TcpPort = 1800;
        const string broadcastUdpAddress = "192.168.0.255";      //IP-адрес вещания

        UdpClient receivingUdpClient;      //Передатчик инф.
        UdpClient sendingUdpClient;        //Приемник инф.

        Thread receivingUdpThread;     //Поток отправления инф.
        Thread listenerTcpThread;

        TcpListener TCPlistener;

        FileSystemWatcher FSwatcher;

        string userName;    //Имя пользователя чата
        string localIP;     //IP текущего пользователя
        string thisUser;        //Строка с именем и IP текущего пользователя

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

            localIP = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
            thisUser = userName + "_" + localIP;        //Строка с именем и IP текущего пользователя

            if (Directory.Exists("index")) Directory.Delete("index", true);      //Удаление папки index (для ее очистки)
            Directory.CreateDirectory("index");     //Создание папки index

            if (!Directory.Exists("share"))     //Если не существует папка share
            {
                Directory.CreateDirectory("share");     //Создать папку share
            }

            InitializeUdpSender();     //Инициализация передатчика
            InitializeUdpReciever();       //Инициализация приемника
            InitializeShareFolderCheck();       //Инициализация провеки расшаренной папки

            FSwatcher = new FileSystemWatcher("share");
            FSwatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            FSwatcher.Changed += new FileSystemEventHandler(ShareFolderChanged);
            FSwatcher.Created += new FileSystemEventHandler(ShareFolderChanged);
            FSwatcher.Deleted += new FileSystemEventHandler(ShareFolderChanged);
            FSwatcher.EnableRaisingEvents = true;


            CreateIndexFile();      //Создать index-файл текущего пользователя
            SendIndexFile();        //Отправить index-файл всем пользователям
            SendIndexFileRequest();


            //////////////////////////////////////////////////////////////////////
            ThreadStart start = new ThreadStart(TCPListener);
            listenerTcpThread = new Thread(start);
            listenerTcpThread.IsBackground = true;
            listenerTcpThread.Start();
            //////////////////////////////////////////////////////////

            MessageSend("***User " + userName + " is connected***");
        }

        private void GetUserNameFromFile()      //Получить имя пользователя из файла
        {
            FileStream fs = new FileStream("name.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            userName = sr.ReadLine();
            sr.Close();
            fs.Close();
            this.Text = "Hello, " + userName + "!";
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
            StringToForm messageDelegate = RecievedMessageAdd;       //Создание делегата принимаемого сообщения
            StringToForm leftingUserDelegate = DeleteUserFromLb;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, UdpPort);      //Сетевая конечная точка

            while (true)
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
                            break;      //Выход из switch
                        }
                    case "UFR":
                        {
                            ProcessingUserFileRequest(data);
                            break;
                        }
                    case "MSG":
                        {
                            string message = Encoding.Unicode.GetString(data);
                            Invoke(messageDelegate, message);
                            break;
                        }
                    case "IFR":     //Команда запроса index-файла (IndexFileRequest)
                        {
                            if (Encoding.Unicode.GetString(data) != thisUser) SendIndexFile();
                            break;
                        }
                    case "ULP":    //Команда выхода пользователя из программы (UserLeftProgram) 
                        {
                            string leftingUser = Encoding.Unicode.GetString(data);
                            Invoke(leftingUserDelegate, leftingUser);
                            break;
                        }
                    default: return;        //Если неопознанная команда - ничего не предпринимать
                }
            }
        }

        private void RecievedMessageAdd(string message)        //Ф-я добавления сообщения в rtb
        {
            rtbChat.Text += "(" + DateTime.Now.ToLongTimeString() + ") " + message + "\n";       //Добавление в rtb принятого текста
        }

        private void ProcessingIndexFile(byte[] data)       //Обработка принятяного index-файла
        {
            StringToForm newUser = UserAdd;     //Создание делегата подключившегося пользовалетя

            FileStream fs = new FileStream("index/index.temp", FileMode.Create, FileAccess.Write);      //Поток зааписи временного файла
            fs.Write(data, 0, data.Length);     //Запись данных во временный файл
            fs.Close();     //Закрытие потока

            FileStream readTempFile = new FileStream("index/index.temp", FileMode.Open, FileAccess.Read);       //Поток чтения временного файла
            StreamReader sr = new StreamReader(readTempFile);   
            string userInfo = sr.ReadLine();        //Чтение первой строки временного файла
            sr.Close();
            readTempFile.Close();

            if (userInfo != thisUser)       ///Если присоеденившийся пользователь не текущий
            {
                File.Copy("index/index.temp", "index/" + userInfo + ".index", true);        //Копирование временного файла в index-файл пользователя
                Invoke(newUser, userInfo);       //Выполнение делегата в потоке, которому принадлежит базовый дескриптор управления
            }

            File.Delete("index/index.temp");        //Удаление временного файла
        }

        private void UserAdd(string connectedUser)      //Ф-я добавления пользователя в чат
        {
            lbUsers.Items.Add(connectedUser);        //добавление в lb нового пользователя
        }

        private async void ProcessingUserFileRequest(byte[] data)
        {
            StringToForm logWriteDelegate = LogWrite;
            string fullRequest = Encoding.Unicode.GetString(data);
            string[] request = fullRequest.Split('^');
            if (request[0] == thisUser)
            {
                return;
            }
            string fileName = request[1];
            string[] userInfo = request[0].Split('_');
            string userIP = userInfo[1];

            IPAddress address;
            FileInfo file;
            FileStream fileStream;
            if (!IPAddress.TryParse(userIP, out address))
            {
                MessageBox.Show("Error with IP Address");
                return;
            }
            try
            {
                file = new FileInfo("share/"+fileName);
                fileStream = file.OpenRead();
            }
            catch
            {
                MessageBox.Show("Error opening file");
                return;
            }

            // Connecting
            TcpClient client = new TcpClient();
            try
            {
                await client.ConnectAsync(address, TcpPort);
            }
            catch
            {
                MessageBox.Show("Error connecting to destination");
                return;
            }
            NetworkStream ns = client.GetStream();

            // Send file info
            { // This syntax sugar is awesome
                byte[] fileName1 = ASCIIEncoding.Unicode.GetBytes(file.Name);
                byte[] fileNameLength = BitConverter.GetBytes(fileName1.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                await ns.WriteAsync(fileLength, 0, fileLength.Length);
                await ns.WriteAsync(fileNameLength, 0, fileNameLength.Length);
                await ns.WriteAsync(fileName1, 0, fileName1.Length);
            }

            // Sending
            int read;
            int totalWritten = 0;
            byte[] buffer = new byte[32 * 1024]; // 32k chunks
            while ((read = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await ns.WriteAsync(buffer, 0, read);
                totalWritten += read;
            }

            fileStream.Dispose();
            client.Close();
            Invoke(logWriteDelegate, DateTime.Now.ToLongTimeString() + ":" + " The file " + fileName + " was downloaded by user " + userInfo[0]);
            //MessageBox.Show("Sending complete!");
        }

        private void DeleteUserFromLb(string leftingUser)
        {
            lbUsers.Items.Remove(leftingUser);
        }

        private void LogWrite(string message)
        {
            rtbLog.Text += message + "\n";
        }

        private void InitializeShareFolderCheck()       //Запуск мониторинга папки share
        {
            /*FileSystemWatcher watcher = new FileSystemWatcher("share");
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;*/
        }

        private void ShareFolderChanged(object source, FileSystemEventArgs e)        //Если есть изменения в папке share
        {
            CreateIndexFile();      //Создать index-файл
        }

        public void CreateIndexFile()       //Создание index-файла
        {
            FileStream fs = new FileStream(thisUser + ".index", FileMode.Create, FileAccess.Write);     //Поток записи index-файла
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(thisUser);     //Запись в первую строку текущего пользователя
            foreach (string file in Directory.GetFiles("share"))        //Для каждого файла из папки share
            {
                string fileInfo = thisUser + "^" + Path.GetFileName(file) + "^" + ComputeMD5Checksum(file) + "\n";      //Строка с информацией о файле
                sw.Write(fileInfo);     //Запись строки с информацией о файле
            }
            sw.Close();
            fs.Close();     //Закрытие потока
        }

        private string ComputeMD5Checksum(string path)      //Вычисление хеш суммы файла
        {
            //using (FileStream fs = System.IO.File.OpenRead(path))
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
        }

        private void SendIndexFile()        //Отправка index-файла
        {
            FileStream fs = new FileStream(thisUser + ".index", FileMode.Open, FileAccess.Read);        //Поток чтения index-файла текущего пользователя 
            byte[] command = Encoding.Unicode.GetBytes("RIF");     //Массив байт команды
            byte[] indexFile = new byte [fs.Length];        //Массив байт index-файла
            fs.Read(indexFile, 0, indexFile.Length);        //Чтение index-файла в массив байт
            byte[] toSend = command.Concat(indexFile).ToArray();        //Объединение байт команды и index-файла
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
            fs.Close();
        }

        private void SendIndexFileRequest()
        {
            byte[] toSend = Encoding.Unicode.GetBytes("IFR"+thisUser);     //Массив байт запроса
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            tbMessage.Text = tbMessage.Text.TrimEnd(' ');
            tbMessage.Text = tbMessage.Text.TrimStart(' ');
            if (!string.IsNullOrEmpty(tbMessage.Text))
            {
                MessageSend(userName + ": " + tbMessage.Text);
                tbMessage.Clear();
            }
            else return;
        }

        private void MessageSend(string message)
        {
            byte[] toSend = Encoding.Unicode.GetBytes("MSG" + message);
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {
            //if (rtbChat.Lines.Length > 50) rtbChat.Text = rtbChat.Text.Remove(rtbChat.GetFirstCharIndexFromLine(0), rtbChat.Lines[0].Length + 1);     //Ограничение числа строк rtb
            rtbChat.SelectionStart = rtbChat.Text.Length;       //Автоматическая прокрутка rtb
            rtbChat.ScrollToCaret();        //Автоматическая прокрутка rtb
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem == null) return;
            lbFiles.Items.Clear();
            btnDownload.Enabled = false;
            try
            {
                FileStream fs = new FileStream("index/" + lbUsers.SelectedItem.ToString() + ".index", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string mainstr = sr.ReadLine();
                    string[] str = mainstr.Split('^');
                    lbFiles.Items.Add(str[1]);
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDownload.Enabled = true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string fileName = lbFiles.SelectedItem.ToString();
            if (File.Exists("share/" + fileName))
            {
                if (MessageBox.Show("File " + fileName + " exist! Replace it?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            InitializeTcpListener();
            string fileRequest = "UFR" + thisUser + "^" + fileName;
            byte[] toSend = Encoding.Unicode.GetBytes(fileRequest);
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов
        }

        private void InitializeTcpListener()
        {
            //listener = new TcpListener(1732);
            //listener.Start();

            /*ThreadStart start = new ThreadStart(TCPListener);
            listenerThread = new Thread(start);
            listenerThread.IsBackground = true;
            listenerThread.Start();*/
        }

        private async void TCPListener()
        {
            StringToForm STF = LogWrite;
            FSwatcher.EnableRaisingEvents = false;
            TCPlistener = new TcpListener(IPAddress.Any, TcpPort);
            TCPlistener.Start();
            while (true)
            {
                TcpClient client = await TCPlistener.AcceptTcpClientAsync();
                NetworkStream ns = client.GetStream();

                long fileLength;
                string fileName;
                {
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

                FSwatcher.EnableRaisingEvents = false;
                FileStream fileStream = File.Open(fileName, FileMode.Create);

                // Receive
                int read;
                int totalRead = 0;
                byte[] buffer = new byte[32 * 1024]; // 32k chunks
                while ((read = await ns.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, read);
                    totalRead += read;
                }
                fileStream.Close();
                FSwatcher.EnableRaisingEvents = true;
                Invoke(STF,"(" + DateTime.Now.ToLongTimeString() + ") " + "File " + Path.GetFileName(fileName) + " has been successfully downloaded!");
            }
            /*ns.Close();
            client.Close();
            TCPlistener.Stop();*/ //!!!!!!!!!! Поток не закрывается!!!
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
            Process.Start("share");
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageSend("***User " + userName + " disconnected***");

            string fileRequest = "ULP" + thisUser;
            byte[] toSend = Encoding.Unicode.GetBytes(fileRequest);
            sendingUdpClient.Send(toSend, toSend.Length);      //Отправка массива байтов

            receivingUdpThread.Abort();
            listenerTcpThread.Abort();
            receivingUdpClient.Close();
            sendingUdpClient.Close();
        }
    }
}
