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
    public partial class Form1 : Form
    {
        public Form1()
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
                "SELECT * FROM Users WHERE Email=@e AND Password=@p";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@e", maskedTextBox1.Text);

                cmd.Parameters.AddWithValue("@p", maskedTextBox2.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["Role"].ToString();

                    if (role == "User")
                    {
                        Dashboard d = new Dashboard();
                        d.Show();
                    }

                    else if (role == "Admin")
                    {
                        AdminDshboard a = new AdminDshboard();
                        a.Show();
                    }

                    else if (role == "Super Admin")

                    {
                        SuperAdminDashboard s = new SuperAdminDashboard();
                        s.Show();
                    }

                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid Login");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }

    
    


                     
                    
           
   
            

           
        

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm r = new RegisterForm();
            r.Show();
            this.Hide();
        }
    }
}
