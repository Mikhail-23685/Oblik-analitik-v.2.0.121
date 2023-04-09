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
    public partial class buy : Form
    {
        SqlConnection sqlConnection;
        public buy()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buy_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.agents". При необходимости она может быть перемещена или удалена.
            this.agentsTableAdapter.Fill(this.testDataSet.agents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.agents". При необходимости она может быть перемещена или удалена.
           
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet11.agents". При необходимости она может быть перемещена или удалена.
          
            sqlConnection = new SqlConnection(@"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"); 
            
            sqlConnection.Open();

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            comboBox2.Items.Add("Квартира");
            comboBox2.Items.Add("Дом");
            comboBox2.Items.Add("Земля");
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            tabPage3.Parent = null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Квартира")
            {
                tabPage1.Parent = tabControl1;
                tabPage2.Parent = null;
                tabPage3.Parent = null;
            }

            if (comboBox2.Text == "Дом")
            {
                tabPage2.Parent = tabControl1;
                tabPage1.Parent = null;
                tabPage3.Parent = null;
            }

            if (comboBox2.Text == "Земля")
            {
                tabPage3.Parent = tabControl1;
                tabPage2.Parent = null;
                tabPage1.Parent = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ИнтерфейсКлиента klint = new ИнтерфейсКлиента();
            klint.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ИнтерфейсКлиента klint = new ИнтерфейсКлиента();
            klint.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ИнтерфейсКлиента klint = new ИнтерфейсКлиента();
            klint.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(comboBox1.Text) & !string.IsNullOrWhiteSpace(comboBox1.Text)&
               !string.IsNullOrEmpty(comboBox2.Text) & !string.IsNullOrWhiteSpace(comboBox2.Text)&
               !string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text)&
               !string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrWhiteSpace(textBox2.Text)&
               !string.IsNullOrEmpty(textBox17.Text) & !string.IsNullOrWhiteSpace(textBox17.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [apartment-demands] (Address_City,Address_Street,Address_House,Address_Number,MinPrice,MaxPrice,AgentId,ClientId,MinArea,MaxArea,MinRooms,MaxRooms,MinFloor,MaxFloor) VALUES (@Address_City, @Address_Street,@Address_House,@Address_Number,@MinPrice,@MaxPrice,@AgentId,@ClientId,@MinArea,@MaxArea,@MinRooms,@MaxRooms,@MinFloor,@MaxFloor)", sqlConnection);
                command.Parameters.AddWithValue("Address_City", textBox1.Text);
                command.Parameters.AddWithValue("Address_Street", textBox18.Text);
                command.Parameters.AddWithValue("Address_House", textBox19.Text);
                command.Parameters.AddWithValue("Address_Number", textBox20.Text);
                command.Parameters.AddWithValue("MinPrice", textBox2.Text);
                command.Parameters.AddWithValue("MaxPrice", textBox17.Text);
                command.Parameters.AddWithValue("AgentId", idag);
                command.Parameters.AddWithValue("ClientId", Program.id);
                command.Parameters.AddWithValue("MinArea", textBox3.Text);
                command.Parameters.AddWithValue("MaxArea", textBox4.Text);
                command.Parameters.AddWithValue("MinRooms", textBox6.Text);
                command.Parameters.AddWithValue("MaxRooms", textBox8.Text);
                command.Parameters.AddWithValue("MinFloor", textBox5.Text);
                command.Parameters.AddWithValue("MaxFloor", textBox7.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Вы создали предложение");
            }
            else
            {
                MessageBox.Show("Вы не заполнили выделенные поля!!");
            }

        }
        string idag;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idrealt = "SELECT [id] from [agents] WHERE [FirstName] = '"+ comboBox1.Text+"'";
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(idrealt, sqlConnection))
            {
                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                idag = table.Rows[0][0].ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) & !string.IsNullOrWhiteSpace(comboBox1.Text) &
               !string.IsNullOrEmpty(comboBox2.Text) & !string.IsNullOrWhiteSpace(comboBox2.Text) &
               !string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text) &
               !string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrWhiteSpace(textBox2.Text) &
               !string.IsNullOrEmpty(textBox17.Text) & !string.IsNullOrWhiteSpace(textBox17.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [house-demands] (Address_City,Address_Street,Address_House,Address_Number,MinPrice,MaxPrice,AgentId,ClientId,MinArea,MaxArea,MinRooms,MaxRooms,MinFloors,MaxFloors) VALUES (@Address_City, @Address_Street,@Address_House,@Address_Number,@MinPrice,@MaxPrice,@AgentId,@ClientId,@MinArea,@MaxArea,@MinRooms,@MaxRooms,@MinFloors,@MaxFloors)", sqlConnection);
                command.Parameters.AddWithValue("Address_City", textBox1.Text);
                command.Parameters.AddWithValue("Address_Street", textBox23.Text);
                command.Parameters.AddWithValue("Address_House", textBox22.Text);
                command.Parameters.AddWithValue("Address_Number", textBox21.Text);
                command.Parameters.AddWithValue("MinPrice", textBox2.Text);
                command.Parameters.AddWithValue("MaxPrice", textBox17.Text);
                command.Parameters.AddWithValue("AgentId", idag);
                command.Parameters.AddWithValue("ClientId", Program.id);
                command.Parameters.AddWithValue("MinArea", textBox14.Text);
                command.Parameters.AddWithValue("MaxArea", textBox13.Text);
                command.Parameters.AddWithValue("MinRooms", textBox12.Text);
                command.Parameters.AddWithValue("MaxRooms", textBox10.Text);
                command.Parameters.AddWithValue("MinFloors", textBox11.Text);
                command.Parameters.AddWithValue("MaxFloors", textBox9.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Вы создали предложение");
            }
            else
            {
                MessageBox.Show("Вы не заполнили выделенные поля!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) & !string.IsNullOrWhiteSpace(comboBox1.Text) &
              !string.IsNullOrEmpty(comboBox2.Text) & !string.IsNullOrWhiteSpace(comboBox2.Text) &
              !string.IsNullOrEmpty(textBox1.Text) & !string.IsNullOrWhiteSpace(textBox1.Text) &
              !string.IsNullOrEmpty(textBox2.Text) & !string.IsNullOrWhiteSpace(textBox2.Text) &
              !string.IsNullOrEmpty(textBox17.Text) & !string.IsNullOrWhiteSpace(textBox17.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [land-demands] (Address_City,Address_Street,Address_House,Address_Number,MinPrice,MaxPrice,AgentId,ClientId,MinArea,MaxArea) VALUES (@Address_City, @Address_Street,@Address_House,@Address_Number,@MinPrice,@MaxPrice,@AgentId,@ClientId,@MinArea,@MaxArea)", sqlConnection);
                command.Parameters.AddWithValue("Address_City", textBox1.Text);
                command.Parameters.AddWithValue("Address_Street", textBox26.Text);
                command.Parameters.AddWithValue("Address_House", textBox25.Text);
                command.Parameters.AddWithValue("Address_Number", textBox24.Text);
                command.Parameters.AddWithValue("MinPrice", textBox2.Text);
                command.Parameters.AddWithValue("MaxPrice", textBox17.Text);
                command.Parameters.AddWithValue("AgentId", idag);
                command.Parameters.AddWithValue("ClientId", Program.id);
                command.Parameters.AddWithValue("MinArea", textBox15.Text);
                command.Parameters.AddWithValue("MaxArea", textBox16.Text);
                

                command.ExecuteNonQuery();
                MessageBox.Show("Вы создали предложение");
            }
            else
            {
                MessageBox.Show("Вы не заполнили выделенные поля!!");
            }
        }
    }
    
}
