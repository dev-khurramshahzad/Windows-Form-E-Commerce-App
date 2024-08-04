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

namespace E_Coomerce_App
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=KHURRAM-LAPTOP;Initial Catalog=dbE_Electronics;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
            ShowCategories();
        }

        void ShowCategories()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", con);
            SqlDataAdapter da  = new SqlDataAdapter(cmd);   
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewCats.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Categories VALUES ('" + txtCatName.Text + "','" + txtDetail.Text + "','" + txtImage.Text + "','" + txtStatus.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ShowCategories();

                MessageBox.Show("A New Category is Created");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something Went Wrong\n"+ex.Message,"Error Details");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            
        }
    }
}
