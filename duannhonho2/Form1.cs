using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace duannhonho2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = string.Format("server=localhost;port=3306;uid=root;pwd=123456789;database=usernamepass");
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                
                
                    MySqlCommand cmd = new MySqlCommand(string.Format("select * from userpass where MSNVbophan = '{0}' and Pass = '{1}' ", txtusername.Text, txtpassword.Text), con);
                
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        this.Hide();
                        Main m = new Main();
                        m.Show();
                    }
 
                else 
                {
                   MessageBox.Show("Login Fail");
                }
            }
        
        }
    }
}
