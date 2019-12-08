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
    public partial class Form4 : Form
    {
        OleDbCommand cmd = new OleDbCommand();
        OleDbConnection cn = new OleDbConnection();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=auto.accdb";
            cmd.Connection = cn;
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            if (i == 0)
            {
                // "Легковий"
                if ((textBox1.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                {
                    string q = "insert into auto([Марка автомобіля],[Тип],[Номерний знак],[Строк служби],[Особливість]) values('" + textBox1.Text.ToString() + "','Легковий','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')";
                    dou(q);
                    textBox1.Text = null; textBox3.Text = null; textBox4.Text = null;textBox5.Text = null;
                }
                else
                {
                    MessageBox.Show("Заповніть всі поля!!!");
                }
            }
            else if (i == 1)
            {                
                if ((textBox1.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                {
                    string q = "insert into Auto([Марка автомобіля],[Тип],[Номерний знак],[Строк служби],[Особливість]) values('" + textBox1.Text.ToString() + "','Вантажний','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')";
                    dou(q);
                    textBox1.Text = null; textBox3.Text = null; textBox4.Text = null; textBox5.Text = null;
                }
                else
                {
                    MessageBox.Show("Заповніть всі поля!!!");
                }
            }
        }

        private void dou(String q)
        {
            try
            {
                cn.Open();
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                cn.Close();
                loaddata();
            }
            catch (Exception e)
            {
                cn.Close();
                MessageBox.Show(e.Message.ToString());
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            { 
                string q = "DELETE FROM Auto where Код= " + Convert.ToInt32(textBox2.Text);
                dou(q);
            }
            else
            {
                MessageBox.Show("введіть значення у полі Код");
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i=dataGridView1.CurrentCell.RowIndex;
            if (textBox3.Text != "" & i != -1)
            {
                string q = "update auto set [Марка автомобіля]='" + textBox1.Text.ToString() + "',[Тип]='" + comboBox1.Text.ToString() + "',[Номерний знак]='" + textBox3.Text.ToString() + "',[Строк служби] ='" + textBox4.Text.ToString() + "',[Особливість] ='" + textBox5.Text.ToString() + "'where Код=" + textBox2.Text;
                dou(q);
                textBox1.Text = null; textBox2.Text = null; textBox3.Text = null; textBox4.Text = null; textBox5.Text = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = null; textBox2.Text = null; textBox3.Text = null; textBox4.Text = null; textBox5.Text = null;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            textBox2.Text = Convert.ToString(dataGridView1[0, i].Value);
            textBox1.Text = Convert.ToString(dataGridView1[1, i].Value);
            comboBox1.Text = Convert.ToString(dataGridView1[2, i].Value);
            textBox3.Text = Convert.ToString(dataGridView1[3, i].Value);
            textBox4.Text = Convert.ToString(dataGridView1[4, i].Value);
            textBox5.Text = Convert.ToString(dataGridView1[5, i].Value);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
