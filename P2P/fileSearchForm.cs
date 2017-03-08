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

using MetroFramework.Forms;
using MetroFramework.Components;

namespace P2P
{
    public partial class fileSearchForm : MetroForm
    {
        string searchFileName;
        bool fileFound = false;
        int selectedRowIndex;
        public string fFName,
            fFUser,
            fFIP,
            fFSize,
            fFCheckSum;

        public fileSearchForm()
        {
            InitializeComponent();
        }

        private void fileSearchForm_Load(object sender, EventArgs e)
        {
            
        }

        private void mbtnDownoad_Click(object sender, EventArgs e)
        {
            selectedRowIndex = mgFoundFiles.SelectedRows[0].Index;

            fFName = mgFoundFiles.SelectedRows[0].Cells[0].Value.ToString();
            fFUser = mgFoundFiles.SelectedRows[0].Cells[1].Value.ToString();
            fFIP = mgFoundFiles.SelectedRows[0].Cells[2].Value.ToString();
            fFSize = mgFoundFiles.SelectedRows[0].Cells[3].Value.ToString();
            fFCheckSum = mgFoundFiles.SelectedRows[0].Cells[4].Value.ToString();
            this.Close();
        }

        private void cbFileName_TextUpdate(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbFileName.Text.TrimEnd(' ').TrimStart(' '))) mbFind.Enabled = false;
            else mbFind.Enabled = true;
        }

        private void mbFind_Click(object sender, EventArgs e)
        {
            searchFileName = cbFileName.Text.TrimEnd(' ').TrimStart(' ');
            mgFoundFiles.Rows.Clear();

            foreach (string file in Directory.GetFiles("index"))        //Для каждого файла из папки share
            {
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);      //Поток работы с файлом
                StreamReader sr = new StreamReader(fs);     //Поток работы с текстовым файлом
                string [] userInfoTemp = sr.ReadLine().Split('_');

                while (!sr.EndOfStream)     //Чтение всех строк до конца файла
                {
                    string strFromFile = sr.ReadLine();     //Общая строка из файла
                    string[] fileInfoTemp = strFromFile.Split('^');      //Массив с частями общей строки

                    if (fileInfoTemp[0] == searchFileName)
                    {
                        mgFoundFiles.Rows.Add();
                        mgFoundFiles.Rows[mgFoundFiles.Rows.Count - 1].Cells[0].Value = fileInfoTemp[0];
                        mgFoundFiles.Rows[mgFoundFiles.Rows.Count - 1].Cells[1].Value = userInfoTemp[0];
                        mgFoundFiles.Rows[mgFoundFiles.Rows.Count - 1].Cells[2].Value = userInfoTemp[1];
                        mgFoundFiles.Rows[mgFoundFiles.Rows.Count - 1].Cells[3].Value = fileInfoTemp[1];
                        mgFoundFiles.Rows[mgFoundFiles.Rows.Count - 1].Cells[4].Value = fileInfoTemp[2];

                        fileFound = true;
                    }
                }
                sr.Close();     //Остановка потока
                fs.Close();     //Остановка потока
            }

            if (mgFoundFiles.RowCount == 0)
            {
                mgFoundFiles.Rows.Add();
                mgFoundFiles.Rows[mgFoundFiles.Rows.Count - 1].Cells[0].Value = "File " + searchFileName + " not found!";
                fileFound = false;
                mbtnDownoad.Enabled = false;
            }
        }

        private void mgFoundFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fileFound)
            {
                mbtnDownoad.Enabled = true;
            }
        }

        private void cbFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)        //Если нажата клавиша Enter
            {
                mbFind.PerformClick();     //Программное нажатие на кнопку
            }
        }
    }
}
