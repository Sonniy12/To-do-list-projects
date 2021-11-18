using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Do_List
{
    [Serializable]
    public class Do_list
    {

        DateTime date_t;
        private string mess;
        private string prior;

        public string Mess_g { get => mess; set => mess = value; }
        public string Prioritet { get => prior; set => prior = value; }
        public DateTime Date_t { get => date_t; set => date_t = value; }
        Dictionary<DateTime, string> _list;
        public Do_list()
        {
            _list = new Dictionary<DateTime, string>();
        }

        public void Add(DateTime d, string m, string p)
        {
            Date_t = d;
            Mess_g = m;
            Prioritet = p;
            _list.Add(Date_t, " *Messege* - " + Mess_g + "*Prioritet* -" + Prioritet);
           
               
            
            
        }

        public string Save()
        {
            return "Date " + Date_t + "  *Messege* - " + Mess_g + "  *Prioritet* - " + Prioritet + "\n";
        }


        public Do_list Return_q()
        {
            return this;
        }

        public void Show2(Label l)
        {
            // MessageBox.Show("Date " + Date_t + "  *Messege* - " + Mess_g + "  *Prioritet* - " + Prioritet + "\n");
            foreach (var item in _list)
            {
                l.Text += "" + item + "\n";
            }
            
        }

        public void Search_prioritet(Label l, string pr)
        {
            string  res = "";
            foreach (var i in _list)
            {
                

                if (i.Value.Contains(pr) )
                {

                    l.Text += i.Value+i.Key + "\n";
                }
                else if (res.Contains(pr) )
                {
                    l.Text += i.Value + i.Key + "\n";
                }
                else if (res.Contains(pr) )
                {
                    l.Text += i.Value + i.Key + "\n";
                }
               
                  
                
            }

            

            // res += i.Value;



        }
        public void Search_Message(Label l, string message)
        {


            foreach (var i in _list)
            {


                if (i.Value.Contains(message))
                {

                    l.Text += i.Value + i.Key + "\n";
                }
               


            }
                   
           



        }

        public void Search_DateTime(Label l, string dt)
        {

            foreach (var i in _list)
            {
                if (i.Key.Date.Equals(DateTime.Parse(dt)))
                {
                    l.Text = "";
                    l.Text += i.Value + "\n";
                }
               
              
                                 
            }


        }
    }
}
