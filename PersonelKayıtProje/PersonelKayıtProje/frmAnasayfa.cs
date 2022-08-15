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

namespace PersonelKayıtProje
{
    public partial class frmAnasayfa : Form
    {
        public frmAnasayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-SBTQ48V\\SQLEXPRESS; Initial Catalog = TBL_Personel; Integrated Security = True");

        void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtMeslek.Text = "";
            txtSoyad.Text = "";
            msktxtMaas.Text = "";
            cmbSehir.Text = "";
            label8.Text = "";
            rdbtnBekar.Checked = false;
            rdbtnEvli.Checked = false;
            txtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.personelTBLTableAdapter.Fill(this.tBL_PersonelDataSet.PersonelTBL);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.personelTBLTableAdapter.Fill(this.tBL_PersonelDataSet.PersonelTBL);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into PersonelTBL (PerAdi,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", msktxtMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();  //Sorguyu çalıştır ekle-sil-güncelle de kullanılır.
            baglanti.Close();
            MessageBox.Show("Başarıyla kaydedildi.");

        }

        private void rdbtnEvli_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnEvli.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void rdbtnBekar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnBekar.Checked == true)
            {
                label8.Text ="False";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktxtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="True")
            {
                rdbtnEvli.Checked = true;
            }
            if (label8.Text == "False")
            {
                rdbtnBekar.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From PersonelTBL Where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutgüncelle = new SqlCommand("Update  PersonelTBL Set PerAdi=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", baglanti);
            komutgüncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            komutgüncelle.Parameters.AddWithValue("@a2", txtSoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@a3", cmbSehir.Text);
            komutgüncelle.Parameters.AddWithValue("@a4", msktxtMaas.Text);
            komutgüncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutgüncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutgüncelle.Parameters.AddWithValue("@a7", txtID.Text);
            komutgüncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgi Güncellendi");
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            frmİstatistik frm = new frmİstatistik();
            frm.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            frmGrafikler frm = new frmGrafikler();
            frm.Show();
        }
    }
}
