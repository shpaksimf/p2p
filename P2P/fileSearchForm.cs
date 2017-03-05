using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework.Components;

namespace P2P
{
    public partial class fileSearchForm : MetroForm
    {
        public fileSearchForm()
        {
            InitializeComponent();
        }

        private void mbtnDownoad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
