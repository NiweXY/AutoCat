using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace WindowsFormsApplication6
{
    public partial class Меню : Form
    {
        public Меню()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

     /*  private void button1_Click(object sender, EventArgs e)
        {

            Form2 secondForm = new Form2();
            secondForm.Show();
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
           // Form3 secondForm = new Form3();
         //  secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Form4 secondForm = new Form4();
           secondForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 secondForm = new Form5();
            secondForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 secondForm = new Form6();
            secondForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"C:\Users\Oksana\Documents\Visual Studio 2010\Projects\kurs\Каталог автомобілів.docx");
            /*Form7 secondForm = new Form7();
            secondForm.Show();*/
        }

        private void Меню_Load(object sender, EventArgs e)
        {

        }

    }
}
