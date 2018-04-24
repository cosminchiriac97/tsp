using System;
using System.Windows.Forms;
using Library.ServiceReference;

namespace Library
{
    public partial class FormImprumutaCarte : Form
    {
        private CITITOR _cititor;
        public FormImprumutaCarte(CITITOR cititor)
        {
            InitializeComponent();
            _cititor = cititor;
            this.label1.Text = cititor.Nume;
            this.label2.Text = cititor.Prenume;
            this.label3.Text = cititor.Stare.ToString();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bookList = WcfClient.GetInstance().GetCarti(this.textBox1.Text);
            this.textBox2.Text = "";
            if (bookList != null)
            {
                foreach (var book in bookList)
                {
                    this.textBox2.Text = this.textBox2.Text + book.Titlu + "@";

                }
            }
            else
            {
                this.textBox2.Text = "Nu exista nici o carte de acest gen!";
            }
            this.textBox2.Text = this.textBox2.Text.Replace("@", System.Environment.NewLine);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var autorNume = this.textBox3.Text;
            var autorPrenume = this.textBox8.Text;
            var titluCarte = this.textBox4.Text;
            int numarZile = Decimal.ToInt32(Math.Truncate(this.numericUpDown1.Value));

            if (string.IsNullOrEmpty(autorPrenume) || string.IsNullOrEmpty(autorNume) ||
                string.IsNullOrEmpty(titluCarte))
            {
                MessageBox.Show("Toate campurile trebuie completate corect", "Mesaj de eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (numarZile < 1)
            {
                MessageBox.Show("Poti imprumuta cel putin pentru o zi", "Mesaj de eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (WcfClient.GetInstance().ExistaCartea(titluCarte, autorNume, autorPrenume))
            {
                MessageBox.Show("Cartea nu exista", "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            var dataScadenta = WcfClient.GetInstance().EsteCarteaDisponibila(autorNume, autorPrenume, titluCarte);
            if (dataScadenta != null)
            {
                MessageBox.Show("Cartea nu este disponibila momentan, reveniti pe " + dataScadenta, "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var result = WcfClient.GetInstance().ImprumutaCartea(_cititor, titluCarte, autorNume, autorPrenume, numarZile);
            if (result)
            {
                MessageBox.Show("Ati imprumutat cartea cu succes", "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("A aparut o eroare neprevazuta", "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var idCarte = Decimal.ToInt32(Math.Truncate(this.numericUpDown2.Value));
            var textReview = this.textBox7.Text;
            if (string.IsNullOrEmpty(textReview))
            {
                MessageBox.Show("Un review este obligatoriu la restituirea unei carti", "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (!WcfClient.GetInstance().PotRestituiiCartea(_cititor, idCarte))
            {
                MessageBox.Show("Nu poti restituii cartea imprumutata de alta persoana", "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (WcfClient.GetInstance().RestituieCarte(_cititor, idCarte, textReview))
            {
                MessageBox.Show("Ati restituit cu succes cartea", "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("A aparut o eroare neprevazuta", "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog(this);
        }
    }
}
