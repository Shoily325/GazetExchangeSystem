using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace GazetExchangeSystem
{
    public partial class RequestForm : Form
    {
        public RequestForm()
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

                string query = "SELECT * FROM ExchangeRequests";

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

        private void button2_Click(object sender, EventArgs e)
        {


            string connectionString =
                @"Server=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                int id = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["ID"].Value);

                string query =
                "UPDATE ExchangeRequests SET Status='Accepted' WHERE ID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Request Accepted ✔");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

                int id = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["ID"].Value);

                string query =
                "UPDATE ExchangeRequests SET Status='Rejected' WHERE ID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Request Rejected ❌");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }
    }
    }

