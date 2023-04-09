using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS_с_интернетом
{
    public partial class buy : Form
    {
        public buy()
        {
            InitializeComponent();
        }

        private void buy_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet1.ObjectNedv". При необходимости она может быть перемещена или удалена.
            this.objectNedvTableAdapter.Fill(this.testDataSet1.ObjectNedv);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet1.agents". При необходимости она может быть перемещена или удалена.
            this.agentsTableAdapter.Fill(this.testDataSet1.agents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet1.lands". При необходимости она может быть перемещена или удалена.

            //comboBox2.Items.Add("Квартира");
            //comboBox2.Items.Add("Дом");
            //comboBox2.Items.Add("Земля");

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

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
    }
}
