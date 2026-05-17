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
    public partial class BrowseForm : Form
    {
        public BrowseForm()
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

                string query = "SELECT * FROM ExchangePosts";

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

                int receiverID = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["UserID"].Value);

                string offeredItem =
                dataGridView1.SelectedRows[0].Cells["HaveItem"].Value.ToString();

                int senderID = 1; // temporary logged in user

                string query =
                "INSERT INTO ExchangeRequests(SenderID, ReceiverID, OfferedItem, Status) VALUES(@s,@r,@o,@st)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@s", senderID);
                cmd.Parameters.AddWithValue("@r", receiverID);
                cmd.Parameters.AddWithValue("@o", offeredItem);
                cmd.Parameters.AddWithValue("@st", "Pending");

                cmd.ExecuteNonQuery();

                MessageBox.Show("Request Sent Successfully 🎉");
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

            conn.Open();

            int id = Convert.ToInt32(
            dataGridView1.SelectedRows[0].Cells["PostID"].Value);

            string query =
            "DELETE FROM ExchangePosts WHERE PostID=@id";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Post Deleted");

            conn.Close();
        }

    }
    }
    
    
    

