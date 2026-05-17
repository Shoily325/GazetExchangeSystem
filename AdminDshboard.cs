using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazetExchangeSystem
{
    public partial class AdminDshboard : Form
    {
        public AdminDshboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewUsersForm v = new ViewUsersForm();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrowseForm b = new BrowseForm();
            b.Show();




        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        
            Reviews r = new Reviews();

            r.Show();
        }
    }
    }

