using System;
using System.Windows.Forms;
using Library.ServiceReference;

namespace Library
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAchizitieCarti formAchizitie = new FormAchizitieCarti();
            formAchizitie.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDialog formDialog = new FormDialog(this);
            // Show testDialog as a modal dialog and determine if DialogResult = OK.

            formDialog.ShowDialog(this);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStatistici statistici = new FormStatistici();

            statistici.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
  
        }
    }
}
