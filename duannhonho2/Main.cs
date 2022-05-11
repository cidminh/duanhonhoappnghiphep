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
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
            textBox2.MaxLength = 6;
            dateTimePicker1.MinDate = DateTime.Today.AddDays(1);
            dateTimePicker2.MinDate = DateTime.Today.AddDays(1);
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = String.Format("server=localhost;port=3306;uid=root;pwd=123456789;database=datanhanvien");
            using (MySqlConnection con = new MySqlConnection(cs)) 
            {

                MySqlCommand cmd = new MySqlCommand("select MSNV from nhanvien where MSNV = '" + textBox2.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                {
                    if (dr.Read())
                    {
                        if (comboBox2.Text != "")
                        {
                            if(textBox5.Text != "")
                            {
                                if (pictureBox1.Image != null)
                                {
                                        con.Close();
                                        con.Open();
                                        string query = "INSERT INTO dulieunghiphep(ngaylamdon,hoten,bophan,msnv,loainghiphep,nghitungay,denngay,lydo,chuky) VALUES ('" + textBox6.Text + "','"+textBox3.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+comboBox2.Text+"','"+dateTimePicker1.Text+"','"+dateTimePicker2.Text+"','"+textBox5.Text+"','"+pictureBox1.Image+"')";
                                        MySqlCommand cmd1 = new MySqlCommand(query, con);
                                        cmd1.ExecuteReader();
                                
                                    
                                }
                                else
                                {
                                    MessageBox.Show("vui lòng nhập chữ ký");
                                }
                            }
                            else
                            {
                                MessageBox.Show("vui lòng nhập lý do");
                            }
                        }
                        else
                        {
                            MessageBox.Show("vui chọn loại nghỉ phép");
                        }
                    }
                    else
                    {
                        MessageBox.Show("mã số nhân viên không tồn tại");
                    }

                }
            }
        }
   

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotSupportedException();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            throw new NotSupportedException();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string cs = string.Format("server=localhost;port=3306;uid=root;pwd=123456789;database=datanhanvien");
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                
                MySqlCommand cmd = new MySqlCommand("select Hoten,Bophan,Chucvu from nhanvien where MSNV = '" +textBox2.Text+ "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                {
                    if (dr.Read())
                    {
                        textBox3.Text = dr.GetValue(0).ToString();
                        textBox1.Text = dr.GetValue(1).ToString();
                        textBox4.Text = dr.GetValue(2).ToString();
                        _ = new DateTime();
                        DateTime tg = DateTime.Now;
                        textBox6.Text = tg.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        textBox3.Text = " ";
                        textBox1.Text = " ";
                        textBox4.Text = " ";
                    }
                }

            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileImage = new OpenFileDialog();
            if (fileImage.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(fileImage.FileName);
            }
      
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (comboBox2.SelectedItem.ToString().Trim())
            //{
            //    case "Nghỉ phép có lương (nguyên ngày)":
            //    dateTimePicker1.MinDate = DateTime.Today.AddDays(1);
            //    dateTimePicker2.MinDate = DateTime.Today.AddDays(1);
            //    break;
            //    case "Nghỉ không lương (nguyên ngày)":
            //    dateTimePicker1.MinDate = DateTime.Today.AddDays(1);
            //    dateTimePicker2.MinDate = DateTime.Today.AddDays(1);
            //    break ;
            //    case "Nghỉ phép có lương buổi sáng":

            //}
            
        }
    }

}
