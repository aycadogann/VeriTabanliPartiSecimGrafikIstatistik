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

namespace VeriTabanliPartiSecimGrafikİstatistik
{
    public partial class FrmGrafikler : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-I94IGVVP\SQLEXPRESS;Initial Catalog=SecimProje;Integrated Security=True");
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select IlceAd from Ilce",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select Sum(AParti),Sum(BParti), Sum(CParti),Sum(DParti), Sum(EParti) from Ilce", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", reader2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", reader2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", reader2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", reader2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", reader2[4]);
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Ilce where IlceAd=@P1", con);
            cmd.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                progressBar1.Value = int.Parse(reader[2].ToString());
                progressBar2.Value = int.Parse(reader[3].ToString());
                progressBar3.Value = int.Parse(reader[4].ToString());
                progressBar4.Value = int.Parse(reader[5].ToString());
                progressBar5.Value = int.Parse(reader[6].ToString());

                lblA.Text = reader[2].ToString();
                lblB.Text = reader[3].ToString();
                lblC.Text = reader[4].ToString();
                lblD.Text = reader[5].ToString();
                lblE.Text = reader[6].ToString();
            }
            con.Close();

           
        }
    }
}
