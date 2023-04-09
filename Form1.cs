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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.clients". При необходимости она может быть перемещена или удалена.
            
            string ConnectString = @"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectString);
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            comboBox1.Items.Add("Клиент");
            comboBox1.Items.Add("Риэлтор");
            



            tabPage1.Parent = null;
            tabPage2.Parent = null;

        }

       

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Клиент")
            {
                tabPage1.Parent = tabControl1;
                tabPage2.Parent = null;

            }
            if (comboBox1.Text == "Риэлтор")
            {
                tabPage2.Parent = tabControl1;
                tabPage1.Parent = null;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       

        

        private void button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text) &
               !string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrWhiteSpace(textBox2.Text) &
               !string.IsNullOrEmpty(textBox3.Text) & !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                string name = textBox1.Text;
                string middlename = textBox2.Text;
                string lastname = textBox3.Text;
                string myselectquery = "SELECT [FirstName], [MiddleName], [LastName] FROM [dbo].[agents] WHERE [FirstName]='" + name + "' and [MiddleName]='" + middlename + "' and [LastName]='" + lastname + "'";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlConnection))
                {
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    if (table.Rows.Count == 0)
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

        private void button5_Click(object sender, EventArgs e)
        {
            РегистрацияРиэлтора reg = new РегистрацияРиэлтора();
            reg.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            РегистрацияКлиента reg = new РегистрацияКлиента();
            reg.Show();
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text) &
   !string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                string email = textBox1.Text;
                string Phone = textBox2.Text;
                string myselectquery = "SELECT [id] FROM [dbo].[clients] WHERE [Email]= '" + email + "' OR [Phone]='" + Phone + "'";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlConnection))
                {
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    if (table.Rows.Count == 0)
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

        private void button2_Click_2(object sender, EventArgs e)
        {

        }
    }
}
