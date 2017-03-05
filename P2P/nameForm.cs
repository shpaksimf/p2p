using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MetroFramework.Forms;
using MetroFramework.Components;

namespace P2P
{
    public partial class nameForm : MetroForm
    {
        public string name = null;

        public nameForm()
        {
            InitializeComponent();
        }

        private void mbtnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtbName.Text))
            {
                MessageBox.Show("Please select a user name up to 32 characters.");
                mtbName.Clear();
                return;
            }
            else
            {
                FileStream fs = new FileStream("name.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(mtbName.Text);
                sw.Close();
                fs.Close();
                name = mtbName.Text;
                this.Close();
            }
        }

        private void mtbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ' ') || (e.KeyChar == '_'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)        //Отправка сообщения по нажатию на Enter
            {
                mbtnAccept.PerformClick();     //Программное нажатие на кнопку
            }
        }
    }
}
