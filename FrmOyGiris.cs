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

namespace VeriTabanliPartiSecimGrafikİstatistik
{
    public partial class FrmOyGiris : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-I94IGVVP\SQLEXPRESS;Initial Catalog=SecimProje;Integrated Security=True");
        public FrmOyGiris()
        {
            InitializeComponent();
        }

        private void btnOyGris_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Ilce (IlceAd,AParti,BParti,CParti,DParti,EParti) values (@P1,@P2,@P3,@P4,@P5,@P6)", con);
            cmd.Parameters.AddWithValue("@P1", txtIlceAd.Text);
            cmd.Parameters.AddWithValue("@P2", txtAParti.Text);
            cmd.Parameters.AddWithValue("@P3", txtBParti.Text);
            cmd.Parameters.AddWithValue("@P4", txtCParti.Text);
            cmd.Parameters.AddWithValue("@P5", txtDParti.Text);
            cmd.Parameters.AddWithValue("@P6", txtEParti.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti.");
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();
        }
    }
}
