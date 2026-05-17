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

namespace GazetExchangeSystem
{
    public partial class Reviews : Form
    {
        public Reviews()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        
            string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query =
                "INSERT INTO Reviews(UserID, Rating, Comment) VALUES(@u,@r,@c)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", 1);

                cmd.Parameters.AddWithValue("@r", txtRating.Text);

                cmd.Parameters.AddWithValue("@c", txtComment.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Review Submitted Successfully ⭐");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        
            string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            int id = Convert.ToInt32(
            dataGridView1.SelectedRows[0].Cells["ReviewID"].Value);

            string query =
            "DELETE FROM Reviews WHERE ReviewID=@id";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Review Deleted");

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "SELECT * FROM Reviews";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }
    }
    }
    
    

