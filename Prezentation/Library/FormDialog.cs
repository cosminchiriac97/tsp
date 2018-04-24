using System;
using System.Windows.Forms;

using Library.ServiceReference;

namespace Library
{
    public partial class FormDialog : Form
    {
        private Form startPage;
        public FormDialog(Form start)
        {
            startPage = start;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var nume = this.textBox1.Text;
            var prenume = this.textBox2.Text;
            var email = this.textBox3.Text;
            var adresa = this.textBox4.Text;
            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(prenume) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(adresa))
            {
                MessageBox.Show("Toate campurile trebuie completate", "Mesaj de eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            var cititor = new InregistrareCititor
            {
                Nume = nume,
                Prenume = prenume,
                Email = email,
                Adresa = adresa
            };
            var reader = WcfClient.GetInstance().AddCititor(cititor);

            if (reader != null)
            {
             
                this.Hide();
                startPage.Hide();
                FormImprumutaCarte form = new FormImprumutaCarte(reader);
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Something went wrong!", "Mesaj de eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
