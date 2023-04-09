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
    public partial class РегистрацияРиэлтора : Form
    {
        SqlConnection sqlConnection;
        public РегистрацияРиэлтора()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void РегистрацияРиэлтора_Load(object sender, EventArgs e)
        {
            string ConnectString = @"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectString);
            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) || (int.Parse(textBox5.Text) < 100 & int.Parse(textBox5.Text) >= 0)) 
            {
                if (!string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text) &
              !string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrWhiteSpace(textBox2.Text) &
              !string.IsNullOrEmpty(textBox3.Text) & !string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [agents] (FirstName, MiddleName, LastName, DealShare) VALUES(@FirstName, @MiddleName, @LastName, @DealShare)", sqlConnection);
                    command.Parameters.AddWithValue("FirstName", textBox1.Text);
                    command.Parameters.AddWithValue("MiddleName", textBox2.Text);
                    command.Parameters.AddWithValue("LastName", textBox3.Text);
                    command.Parameters.AddWithValue("DealShare", textBox5.Text);

                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Значения ФИО должны обязательно заполнены");
                }
            }
            else
            {
                MessageBox.Show("Доля от комиссии либо меньше 0, либо больше 100");
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
