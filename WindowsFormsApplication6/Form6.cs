using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication6
{
    public partial class Form6 : Form
    {
        OleDbCommand cmd = new OleDbCommand();
        OleDbConnection cn = new OleDbConnection();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=auto.accdb";
            cmd.Connection = cn;
            loaddata();
        }

        private void loaddata()
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cn.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Auto", cn);
            cn.Close();

            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metLoad();
        }

        public void metLoad()
        {
            string comStr1 = "";
            string comStr2 = "";
            string comStr3 = "";
            string comStr4 = "";
            string comStr5 = "";
            string comStr6 = "";
            string comStr7 = "";
            if (textBox1.Text != "")
            { comStr1 = " where ( [Марка автомобіля] = '" + textBox1.Text.ToString() + "' ) "; }

            if (comboBox1.Text != "")
            {
                if (comStr1 == "")
                    comStr2 = " where ( [Тип] = '" + comboBox1.Text.ToString() + "' ) ";
                else
                    comStr2 = " and ( [Тип] = '" + comboBox1.Text.ToString() + "' ) ";
            }

            if (textBox3.Text != "")
            {
                if (comStr1 == "" && comStr2 == "")
                    comStr3 = " where ( [Номерний знак] = '" + textBox3.Text.ToString() + "' ) ";
                else
                    comStr3 = " and ( [Номерний знак] = '" + textBox3.Text.ToString() + "' ) ";
            }

            if (textBox4.Text != "")
            {
                if (comStr1 == "" && comStr2 == "" && comStr3 == "")
                    comStr4 = " where ( [Строк служби] = '" + textBox4.Text.ToString() + "' ) ";
                else
                    comStr4 = " and ( [Строк служби] = '" + textBox4.Text.ToString() + "' ) ";
            }

            if (textBox5.Text != "")
            {
                if (comStr1 == "" && comStr2 == "" && comStr3 == "" && comStr4 == "")
                    comStr5 = " where ( [Особливість] = '" + textBox5.Text.ToString() + "' ) ";
                else
                    comStr5 = " and ( [Особливість] = '" + textBox5.Text.ToString() + "' ) ";
            }



            if (textBox2.Text != "")
            {
                if (comStr1 == "" && comStr2 == "" && comStr3 == "" && comStr4 == "" && comStr5 == "")
                    comStr6 = " where ( [Ціна за годину] = '" + textBox5.Text.ToString() + "' ) ";
                else
                    comStr6 = " and ( [Ціна за годину] = '" + textBox5.Text.ToString() + "' ) ";
            }


            if (textBox6.Text != "")
            {
                if (comStr1 == "" && comStr2 == "" && comStr3 == "" && comStr4 == "" && comStr5 == "" && comStr6 == "")
                    comStr7 = " where ( [Ціна за годину з водієм] = '" + textBox5.Text.ToString() + "' ) ";
                else
                    comStr7 = " and ( [Ціна за годину з водієм] = '" + textBox5.Text.ToString() + "' ) ";

            }



                String q = "SELECT * FROM auto " + comStr1 + comStr2 + comStr3 + comStr4 + comStr5 + comStr6 + comStr7;

                OleDbDataAdapter adapter = new OleDbDataAdapter();

                cn.Open();
                OleDbCommand command = new OleDbCommand(q, cn);//("SELECT * FROM Auto", cn);
                cn.Close();

                adapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                adapter.Update(dataSet);
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;

            if (i == 0)
            {
                label5.Text = "Колір";
            }
            else
            {
                label5.Text = "Вантажність";
            }
        }

    }
}
