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
    public partial class АвторизацияКлиента : Form
    {
        SqlConnection SqlConnection;
        public АвторизацияКлиента()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string ConnectString = @"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            SqlConnection = new SqlConnection(ConnectString);
            SqlConnection.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text)&
                !string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                string email = textBox1.Text;
                string Phone = textBox2.Text;
                string myselectquery = "SELECT [id] FROM [dbo].[clients] WHERE [Email]= '" + email + "' OR [Phone]='"+ Phone +"'";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, SqlConnection))
                {
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
    
                    if(table.Rows.Count == 0)
                    {
                        MessageBox.Show("Ошибка, вы ввели неправильный адрес электронной почты или номер телефона");
                    }
                    else
                    {
                        Program.id = table.Rows[0][0].ToString();
                        ИнтерфейсКлиента interf = new ИнтерфейсКлиента();
                        interf.Show();
                        this.Hide();
                    }
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            РегистрацияКлиента reg = new РегистрацияКлиента();
            reg.Show();
            this.Hide();
        }
    }
}
