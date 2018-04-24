using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Library
{
    public partial class FormStatistici : Form
    {
        public FormStatistici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime deLa = this.dateTimePicker1.Value;
            DateTime panaLa = this.dateTimePicker2.Value;
            var cititoriList = WcfClient.GetInstance().ArataCititoriDeLaPanaLa(deLa, panaLa);
            if (cititoriList == null)
            {
                MessageBox.Show("A aparut o eroare neprevazuta", "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            this.label6.Text = cititoriList.Length.ToString();
            List<string> cititoriString = new List<string>();
            foreach (var cititor in cititoriList)
            {
                cititoriString.Add(cititor.Nume + " " + cititor.Prenume);
            }
            this.listBox1.DataSource = cititoriString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cartiSolicitate = WcfClient.GetInstance().CeleMaiSolicitateCarti();
            List<string> topListCarti = new List<string>();
            foreach (var carte in cartiSolicitate)
            {
                topListCarti.Add(carte.Titlu + " " + carte.Count);
            }
            this.listBox2.DataSource = topListCarti;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var autoriiCeiMaiSolicitati = WcfClient.GetInstance().AutoriiCeiMaiCautati();
            List<string> topList = new List<string>();
            foreach (var autor in autoriiCeiMaiSolicitati)
            {
                topList.Add(autor.Nume+ " " + autor.Prenume + " "+ autor.Scor);
            }
            this.listBox3.DataSource = topList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var genuri = WcfClient.GetInstance().GenurileCeleMaiCautati();
            List<string> topList = new List<string>();
            foreach (var gen in genuri)
            {
                topList.Add(gen.Name+" " + gen.Scor);
            }
            this.listBox4.DataSource = topList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var titluCarte = this.textBox1.Text;
            if (string.IsNullOrEmpty(titluCarte))
            {
                MessageBox.Show("Nu ati adaugat titlul cartii", "Informatie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            var reviews = WcfClient.GetInstance().GetReviewsForABook(titluCarte);
           
           this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (var review in reviews)
            {
                listView1.Items.Add(new ListViewItem(new string[] {review.Text}));
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
