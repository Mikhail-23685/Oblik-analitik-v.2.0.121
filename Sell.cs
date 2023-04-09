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
        public Sell()
        {
            InitializeComponent();
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            
            sqlConnection = new SqlConnection(@"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
            string reff;
            string myselectquery = "SELECT [id_apartments] FROM [dbo].[ObjectNedv]";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, sqlConnection))
            {
                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                reff = table.Rows[0][0].ToString();
                MessageBox.Show(reff);

            }
        }
    }
}
