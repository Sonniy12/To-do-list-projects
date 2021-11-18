using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;

namespace Do_List
{
    public partial class Form1 : Form
    {
        Do_list _list;
       // Do_list _list2;
        BinaryFormatter bf = new BinaryFormatter();
        public Form1()
        {
            InitializeComponent();

            
            _list = new Do_list();
            label1.Text = "";
            label4.Text += " "+ DateTime.Now.ToString();

            if (File.Exists("Список_дел.txt") )
            {
             
                using (Stream open2 = File.OpenRead("Список_дел.txt"))
                {
                    _list = (Do_list)bf.Deserialize(open2);
                  

                }

            }
            else
            {
                _list = new Do_list();
               
            }

        }

    

        private void button1_Click(object sender, EventArgs e)
        {
          


            if (radioButton1.Checked == true)
            {
                _list.Prioritet = "Высокий";
                

            }

            else if (radioButton2.Checked == true)
            {
                _list.Prioritet = "Средний";
              
            }

            else if (radioButton3.Checked == true)
            {
                _list.Prioritet = "Низкий";
               

            }
            else
            {
                MessageBox.Show("Не выбран приоритет, по умолчание приоритет Низкий");
                _list.Prioritet = "Низкий";



            }
            //_list.Mess_g = textBox1.Text;
            string result = textBox2.Text;
            try
            {
                if (result == "")
                {
                    _list.Add(DateTime.Now, textBox1.Text, _list.Prioritet);
                }
                else
                {
                    _list.Add(DateTime.Parse(result), textBox1.Text, _list.Prioritet);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

               // throw;
            }
          

            Up_f();

           // Up_f();

           // MessageBox.Show("" + _list.Date_t);
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            _list.Show2(label1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            
            // _list.Search_Message(label1, textBox1.Text);
            // _list.Search_DateTime(label1, textBox2.Text);


            try
            {
                _list.Search_prioritet(label6, textBox3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

                // throw;
            }
            Up_f();
        }

   

      

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            //_list.Search_prioritet(label1, textBox1.Text);
            
            // _list.Search_DateTime(label1, textBox2.Text);

            try
            {
                _list.Search_Message(label6, textBox3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

                // throw;
            }
            Up_f();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            //_list.Search_prioritet(label1, textBox1.Text);
            // _list.Search_Message(label1, textBox1.Text);
           

            try
            {
                _list.Search_DateTime(label6, textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

                // throw;
            }
            Up_f();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            using (Stream tw = File.Create("Список_дел.txt"))
            {
               
                bf.Serialize(tw, _list);
            }
        }

        private void Up_f()
        {
            label1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
