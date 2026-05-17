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
    public partial class CreatePostForm : Form
    {
        public CreatePostForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";





            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query =
                "INSERT INTO ExchangePosts (HaveItem, WantItem, UserID) VALUES (@h,@w,@u)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@h", txtHaveItem.Text);
                cmd.Parameters.AddWithValue("@w", txtWantItem.Text);

                // Temporary UserID
                cmd.Parameters.AddWithValue("@u", 1);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Post Created Successfully 🎉");

                txtHaveItem.Clear();
                txtWantItem.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        
    }
    }
    }

