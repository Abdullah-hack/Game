using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class MainForm : Form
    {
        FileHelper fileHelper = new FileHelper();
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(true);
            gameForm.Show();
            this.Hide();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(false);
            gameForm.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
