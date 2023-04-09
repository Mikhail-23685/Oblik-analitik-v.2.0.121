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

namespace WS_с_интернетом
{
    public partial class РегистрацияКлиента : Form
    {
        SqlConnection SqlConnection;
        public РегистрацияКлиента()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void РегистрацияКлиента_Load(object sender, EventArgs e)
        {
            string ConnectString = @"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            SqlConnection = new SqlConnection(ConnectString);
            SqlConnection.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) & !string.IsNullOrWhiteSpace(textBox4.Text) ||
                !string.IsNullOrEmpty(textBox5.Text) & !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [clients] (FirstName, MiddleName, LastName, Phone, Email) VALUES(@FirstName, @MiddleName, @LastName, @Phone, @Email)", SqlConnection);
                command.Parameters.AddWithValue("FirstName", textBox1.Text);
                command.Parameters.AddWithValue("MiddleName", textBox2.Text);
                command.Parameters.AddWithValue("LastName", textBox3.Text);
                command.Parameters.AddWithValue("Phone", textBox4.Text);
                command.Parameters.AddWithValue("Email", textBox5.Text);

                command.ExecuteNonQuery();

                ИнтерфейсКлиента inter = new ИнтерфейсКлиента();
                inter.Show();
                this.Hide();
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char numb = e.KeyChar;
            if((e.KeyChar<=47 || e.KeyChar >= 58)&& numb!=8  && (e.KeyChar <=39 || e.KeyChar >=46)) 
            {
                e.Handled = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 avt = new Form1();
            avt.Show();
            this.Hide();
        }
    }
}
