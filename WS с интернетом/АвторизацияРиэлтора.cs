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
    public partial class АвторизацияРиэлтора : Form
    {
        SqlConnection sqlConnection;
        public АвторизацияРиэлтора()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string ConnectString = @"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text)&
                !string.IsNullOrEmpty(textBox2.Text)& !string.IsNullOrWhiteSpace(textBox2.Text)&
                !string.IsNullOrEmpty(textBox3.Text)& !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                string name = textBox1.Text;
                string middlename = textBox2.Text;
                string lastname = textBox3.Text;
                string myselectquery = "SELECT [FirstName], [MiddleName], [LastName] FROM [dbo].[agents] WHERE [FirstName]='" + name + "' and [MiddleName]='" + middlename + "' and [LastName]='" + lastname + "'";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlConnection))
                {
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    if(table.Rows.Count == 0)
                    {
                        MessageBox.Show("Ошибка, вы ввели неправильное имя, либо фамиилию, либо отчество");
                    }
                    else
                    {
                        ИнтерфейсРиэлтора interf = new ИнтерфейсРиэлтора();
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
            РегистрацияРиэлтора reg = new РегистрацияРиэлтора();
            reg.Show();
            this.Hide();
        }
    }
}
