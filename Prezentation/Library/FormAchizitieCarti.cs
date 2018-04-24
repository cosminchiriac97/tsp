using System;
using System.Windows.Forms;
using Library.ServiceReference;


namespace Library
{
    public partial class FormAchizitieCarti : Form
    {
        public FormAchizitieCarti()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            
            string caption = "Library";
            string message = "";
            if (string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text) ||
                string.IsNullOrEmpty(this.textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                message = "Toate campurile trebuie completate!";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (this.numericUpDown1.Value == 0)
            {
                message = "Trebuie sa adaugi cel putin o carte in bibioteca";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            AchizitieCarte carti = new AchizitieCarte
            {
                Titlu = this.textBox1.Text,
                NumeAutor = this.textBox2.Text,
                PrenumeAutor = this.textBox3.Text,
                Descriere = this.textBox4.Text,
                NumarCarti = Decimal.ToInt32(Math.Truncate(this.numericUpDown1.Value))
            };
          
            var dbResult = WcfClient.GetInstance().AchizitieCarte(carti);
            if (dbResult)
                message = "Ati adaugat cu succes cartile in biblioteca. Doriti o noua tranzactie?";
            else
            {
                message = "Din pacate cartile nu au fost adaugate in biblioteca. Doriti o noua tranzactie?";
            }       
            var result = MessageBox.Show(message, caption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.numericUpDown1.Value = 0;
            if (result == DialogResult.No)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
