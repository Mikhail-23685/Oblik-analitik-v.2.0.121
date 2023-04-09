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
    public partial class Sell : Form
    {
        SqlConnection sqlConnection;
        string nedv;
        public Sell()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.agents". При необходимости она может быть перемещена или удалена.
            this.agentsTableAdapter.Fill(this.testDataSet.agents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet1.agents". При необходимости она может быть перемещена или удалена.
           
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.agents". При необходимости она может быть перемещена или удалена.

            // TODO: данная строка кода позволяет загрузить данные в таблицу "apartSet._apartment_demands". При необходимости она может быть перемещена или удалена.
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sqlConnection = new SqlConnection(@"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");

            comboBox3.Items.Add("Квартира");
            comboBox3.Items.Add("Дом");
            comboBox3.Items.Add("Земля");

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox3.Text == "Квартира")
            {
                nedv = "apartment-demands";
            }
            if (comboBox3.Text == "Дом")
            {
                nedv = "house-demands";
            }
            if (comboBox3.Text == "Земля")
            {
                nedv = "land-demands";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ИнтерфейсКлиента klint = new ИнтерфейсКлиента();
            klint.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjectNedv nedv = new ObjectNedv();
            nedv.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string reff;
            //string myselectquery = "SELECT ['"+nedv+"'] FROM [dbo].[ObjectNedv]";
            //using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlConnection))
            //{
            //    DataTable table = new DataTable();
            //    dataAdapter.Fill(table);

            //    reff = table.Rows[0][0].ToString();
            //    MessageBox.Show(reff);

            //}
            if(comboBox3.Text == "Квартира")
            {
                label2.Text = (36000 + int.Parse(textBox17.Text)).ToString();

            }
            
            //string apart;
            //string myselectquery = "SELECT Address_City FROM [dbo].[apartments] WHERE (id = id_apartments from [ObjectNedv]) and (id_clients from [ObjectNedv] = '" +Program.id + "') ";
            //using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlConnection))
            //{
            //    DataTable table = new DataTable();
            //    dataAdapter.Fill(table);
              
            //    apart = table.Rows[0][0].ToString();


            //}
            //if (apart != dataGridView1.CurrentRow.Cells[1].Value.ToString())
            //{
            //    MessageBox.Show("Адрес города товара не совпадает с адресом города вашего объекта недвижимисоти");
            //}
            Program.Tower = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.idagents = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            Program.idclients = dataGridView1.CurrentRow.Cells[8].Value.ToString();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string myselectquery = "select* FROM[dbo].["+nedv+"] WHERE('" + textBox17.Text + "' >= MinPrice and MaxPrice >= '" + textBox17.Text + "')";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlConnection))
            {
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }
    }
}
