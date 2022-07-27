using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Udemy_Personal_Veri_Tabanı_Yönetimi
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-1CU8DQ5;Initial Catalog=personalveritabani;Integrated Security=True");

        private void frmistatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel
            baglanti.Open();
            SqlCommand komutistatiski = new SqlCommand("Select Count(*) From Tbl_Personal",baglanti);
            SqlDataReader dr1 = komutistatiski.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();
            //Evli Personel
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personal where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();
            //Bekar Personel
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(*) From Tbl_Personal where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut4.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();
            //Sehir Sayısı
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personal where PerDurum=1", baglanti);
            SqlDataReader dr4 = komut5.ExecuteReader();
            while (dr4.Read())
            {
                lblsehir.Text = dr4[0].ToString();
            }
            baglanti.Close();
            //Toplam Maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select sum(PerMaas) From Tbl_Personal", baglanti);
            SqlDataReader dr5 = komut6.ExecuteReader();
            while (dr5.Read())
            {
                lbltotalmaas.Text = dr5[0].ToString();
            }
            baglanti.Close();
            //Ortalama Maaş
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personal", baglanti);
            SqlDataReader dr6 = komut7.ExecuteReader();
            while (dr6.Read())
            {
                lblortalamamaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
