using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazetExchangeSystem
{
    public partial class ViewUsersForm : Form
    {
        public string roleFilter = "";
        public ViewUsersForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        
            string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string query;
            if(roleFilter=="Admin")
            {
                query = "Select*From Users WHERE ROLE='Admin'";
                
            }
            else
            {
                query = "SELECT*FROM Users";
            }
            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            int id = Convert.ToInt32(
            dataGridView1.SelectedRows[0].Cells["ID"].Value);

            string query =
            "DELETE FROM Users WHERE ID=@id";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            MessageBox.Show("User Deleted");

            conn.Close();
        
    }
    }
    }

