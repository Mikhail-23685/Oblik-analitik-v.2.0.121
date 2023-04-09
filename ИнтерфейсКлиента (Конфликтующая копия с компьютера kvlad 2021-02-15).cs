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
    public partial class ИнтерфейсКлиента : Form
    {
        SqlConnection sqlConnection;
        public ИнтерфейсКлиента()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ИнтерфейсКлиента_Load(object sender, EventArgs e)
        {
            
            string connect = @"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            sqlConnection = new SqlConnection(connect);
            sqlConnection.Open();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buy bu = new buy();
            bu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sell sel = new Sell();
            sel.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
