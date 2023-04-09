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
    public partial class ObjectNedv : Form
    {
        SqlConnection SqlConnection;
        public ObjectNedv()
        {
            InitializeComponent();
        }

      

        private void ObjectNedv_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(@"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
            SqlConnection.Open();
            comboBox1.Items.Add("Дом");
            comboBox1.Items.Add("Квартира");
            comboBox1.Items.Add("Земля");

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            tabPage1.Parent = null;
            tabPage2.Parent = null;
            tabPage3.Parent = null;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Дом")
            {
                tabPage1.Parent = null;
                tabPage2.Parent = tabControl1;
                tabPage3.Parent = null;
            }
            if (comboBox1.Text == "Квартира")
            {
                tabPage1.Parent = tabControl1;
                tabPage2.Parent = null;
                tabPage3.Parent = null;
            }
            if (comboBox1.Text == "Земля")
            {
                tabPage1.Parent = null;
                tabPage2.Parent = null;
                tabPage3.Parent = tabControl1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [apartments] (Address_City,Address_Street,Address_House,Address_Number,Coordinate_latitude,Coordinate_longitude,TotalArea,Rooms,Floor) VALUES (@Address_City,@Address_Street,@Address_House,@Address_Number,@Coordinate_latitude,@Coordinate_longitude,@TotalArea,@Rooms,@Floor)", SqlConnection);
            command.Parameters.AddWithValue("Address_City", textBox1.Text);
            command.Parameters.AddWithValue("Address_Street", textBox2.Text);
            command.Parameters.AddWithValue("Address_House", textBox3.Text);
            command.Parameters.AddWithValue("Address_Number", textBox4.Text);
            command.Parameters.AddWithValue("Floor", textBox5.Text);
            command.Parameters.AddWithValue("Rooms", textBox6.Text);
            command.Parameters.AddWithValue("TotalArea", textBox7.Text);
            command.Parameters.AddWithValue("Coordinate_latitude", textBox8.Text);
            command.Parameters.AddWithValue("Coordinate_longitude", textBox9.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Вы добавили объект недвижимости");
            string id_apart;
            string myselectquery = "SELECT [id] FROM [dbo].[apartments]";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, SqlConnection))
            {
                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                id_apart = table.Rows[0][0].ToString();

            }

            SqlCommand command1 = new SqlCommand("INSERT INTO [ObjectNedv] (id_clints,id_apartments) VALUES (@id_clints,@id_apartments)", SqlConnection);
            command1.Parameters.AddWithValue("id_clints", Program.id);
            command1.Parameters.AddWithValue("id_apartments", id_apart);
            command1.ExecuteNonQuery();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [houses] (Address_City,Address_Street,Address_House,Address_Number,Coordinate_latitude,Coordinate_longitude,TotalFloors,TotalArea) VALUES (@Address_City,@Address_Street,@Address_House,@Address_Number,@Coordinate_latitude,@Coordinate_longitude,@TotalFloors , @TotalArea)", SqlConnection);
            command.Parameters.AddWithValue("Address_City", textBox13.Text);
            command.Parameters.AddWithValue("Address_Street", textBox12.Text);
            command.Parameters.AddWithValue("Address_House", textBox11.Text);
            command.Parameters.AddWithValue("Address_Number", textBox10.Text);
            command.Parameters.AddWithValue("TotalFloors", textBox14.Text);
           
            command.Parameters.AddWithValue("TotalArea", textBox16.Text);
            command.Parameters.AddWithValue("Coordinate_latitude", textBox18.Text);
            command.Parameters.AddWithValue("Coordinate_longitude", textBox17.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Вы добавили объект недвижимости");

            string id_apart;
            
            string myselectquery = "SELECT [id] FROM [dbo].[houses]";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, SqlConnection))
            {
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                var id_home = table.AsEnumerable().Last();

                id_apart = table.Rows[0][0].ToString();



            }
            int id;
            using (var con = new SqlConnection(@"Data Source=PAVEL-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"))
            {
                var sql = "SELECT Max(id) + 1 FROM [houses] WHERE id = @id";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", Int32.Parse(id_apart));
                    con.Open();
                    id = (int)cmd.ExecuteScalar();
                }
            }
           
            SqlCommand command1 = new SqlCommand("INSERT INTO [ObjectNedv] (id_clints,id_houses) VALUES (@id_clints,@id_houses)", SqlConnection);
            command1.Parameters.AddWithValue("id_clints", Program.id);
            command1.Parameters.AddWithValue("id_houses", id_apart.ToString());
            command1.ExecuteNonQuery();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sell prod = new Sell();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sell prod = new Sell();
            prod.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [lands] (Address_City,Address_Street,Address_House,Address_Number,Coordinate_latitude,Coordinate_longitude,TotalArea) VALUES (@Address_City,@Address_Street,@Address_House,@Address_Number,@Coordinate_latitude,@Coordinate_longitude,@TotalArea)", SqlConnection);
            command.Parameters.AddWithValue("Address_City", textBox23.Text);
            command.Parameters.AddWithValue("Address_Street", textBox22.Text);
            command.Parameters.AddWithValue("Address_House", textBox21.Text);
            command.Parameters.AddWithValue("Address_Number", textBox20.Text);

            command.Parameters.AddWithValue("TotalArea", textBox19.Text);
            command.Parameters.AddWithValue("Coordinate_latitude", textBox25.Text);
            command.Parameters.AddWithValue("Coordinate_longitude", textBox24.Text);

            command.ExecuteNonQuery();

            string id_apart;
            string myselectquery = "SELECT [id] FROM [dbo].[lands]";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myselectquery, SqlConnection))
            {
                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                id_apart = table.Rows[0][0].ToString();

            }

            SqlCommand command1 = new SqlCommand("INSERT INTO [ObjectNedv] (id_clints,id_lands) VALUES (@id_clints,@id_lands)", SqlConnection);
            command1.Parameters.AddWithValue("id_clints", Program.id);
            command1.Parameters.AddWithValue("id_lands", id_apart);
            command1.ExecuteNonQuery();
        }
    }
}
