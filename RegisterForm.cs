using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazetExchangeSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=GazetExchangeDB;Trusted_Connection=True;";
            using(SqlConnection conn=new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Name,Email,Password,Role)VALUES(@n,@e,@p,@r)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@n", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@e", maskedTextBox2.Text);
                    cmd.Parameters.AddWithValue("@p", maskedTextBox3.Text);
                    cmd.Parameters.AddWithValue("@r", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
                
            }
        }
    }
}
