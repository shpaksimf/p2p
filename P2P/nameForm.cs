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

namespace P2P
{
    public partial class nameForm : Form
    {
        public bool itClose = false;

        public nameForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Please select a user name up to 32 characters.");
                return;
            }
            else
            {
                FileStream fs = new FileStream("name.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(tbName.Text);
                sw.Close();
                fs.Close();
                this.Close();
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)        //Отправка сообщения по нажатию на Enter
            {
                btnAccept.PerformClick();     //Программное нажатие на кнопку
            }
        }

        private void nameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)) itClose = true;
        }
    }
}
