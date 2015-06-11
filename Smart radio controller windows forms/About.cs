using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_radio_controller_windows_forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// sluit het venster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void about_github_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/RineshRamadhin/Smart-babyroom");
        }

        private void about_github_MouseEnter(object sender, EventArgs e)
        {

        }

        private void about_github_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
