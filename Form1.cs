using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScannerGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void isKeyword(string bf)
        {
            if (bf == "if" || bf == "then" || bf == "else" || bf == "end" || bf == "repeat" || bf == "until" || bf == "read" || bf == "write")
            {
                richTextBox2.Text += bf + "\tKeyword\n";
                bf = "";

            }
            else if (bf != "")
            {
                richTextBox2.Text += bf + "\tID\n";
                bf = "";
            }
            
        }

        void isNumber(string num)
        {
            if(num != "")
            {
                richTextBox2.Text += num + "\tNumber\n";
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            string ip = richTextBox1.Text;

            char[] ch = ip.ToCharArray();

            char[] operators = { '+', '-', '/', '*', '%' };

            string bf = "";
            string num = "";
            string ass = "";
            string comp = "";

            richTextBox2.Text = "";
            for (int i = 0; i < ip.Length; i++)
                {
                
                if (ch[i] == '{')
                {
                   
                    i = ip.IndexOf('}');
                }

               
                for (int j = 0; j < operators.Length; j++)
                {
                    if (ch[i] == operators[j])
                    {
                        richTextBox2.Text += ch[i] + " \t Operator \n";
                    }

                }



                if (Char.IsLetter(ch[i]))
                    {
                        bf += ch[i];


                    }

                if (Char.IsNumber(ch[i]))
                {
                    if (Char.IsLetter(ch[i + 1]))
                    {
                        richTextBox2.Text = "";
                        MessageBox.Show("Error");
                        i = ip.Length - 1;

                    }
                    else
                    num += ch[i];
                }


                if (ch[i] == ' '|| ch[i] == '+' || ch[i] == ':' || ch[i] == ';' || ch[i] == '}' || ch[i] == '{'
                        || ch[i] == '*' || ch[i] == '/' || ch[i] == '-' || ch[i] == '%' || ch[i] == '<' || ch[i] == '>' 
                        || ch[i] == '=')
                    {

                    isKeyword(bf);
                    bf = "";
                    isNumber(num);
                    num = "";

                }
                if (ch[i] == ':')
                {
                    if (ch[i + 1] == '=')
                    {
                        ass = ":=";
                        richTextBox2.Text += ass + "\tAssignmet\n";
                        i+=2;
                    }
                    else
                        richTextBox2.Text += ch[i] + "\tSpecial character\n";
                }



                if ( ch[i] == ';')
                {
                    richTextBox2.Text += ch[i] + "\tSpecial character\n";

                }

                if (ch[i] == '<' || ch[i] == '>')
                {
                    if (ch[i + 1] == '=')
                    {
                        comp += ch[i] + "=";

                        richTextBox2.Text += comp + "\tCompatison\n";
                        i += 2;
                    }
                    else
                        richTextBox2.Text += ch[i] + "\tComparison\n";
                    
                }

                if (ch[i] == '=' )
                {
                    richTextBox2.Text += ch[i] + "\tComparison\n";
                }

                //end of the loop

               
               
            }

               

            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }
    }
}
    
