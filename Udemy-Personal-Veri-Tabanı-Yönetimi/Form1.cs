using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Udemy_Personal_Veri_Tabanı_Yönetimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection ("Data Source=DESKTOP-1CU8DQ5;Initial Catalog=personalveritabani;Integrated Security=True");
        public void temizle()
        {
            txtİd.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            cmbSehir.Text = "";
            mskMaas.Text = "";
            txtMeslek.Text = "";
            radioButton1.Checked = false;
            radioButton1.Checked = false;
            txtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
        }

        

        public void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonalTableAdapter.Fill(this.personalveritabaniDataSet.Tbl_Personal);
        }

        public void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personal (PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", mskMaas.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", txtMeslek.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı");
        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }

        }

        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }

        }

        public void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Delete from Tbl_Personal Where Perid=@k1", baglanti);
            komut2.Parameters.AddWithValue("@k1", txtİd.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            baglanti.Close();
        }

        public void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; 
            txtİd.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        public void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        public void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutupdate = new SqlCommand("update Tbl_Personal Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 Where Perid=@a7", baglanti);
            komutupdate.Parameters.AddWithValue("@a1", txtAd.Text);
            komutupdate.Parameters.AddWithValue("@a2", txtSoyad.Text);
            komutupdate.Parameters.AddWithValue("@a3", cmbSehir.Text);
            komutupdate.Parameters.AddWithValue("@a4", mskMaas.Text);
            komutupdate.Parameters.AddWithValue("@a5", label8.Text);
            komutupdate.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutupdate.Parameters.AddWithValue("@a7", txtİd.Text);
            komutupdate.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }
    }
}
