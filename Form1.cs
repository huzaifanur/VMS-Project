using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS
{
    public partial class Form1 : Form

    {
        Graphics drawArea;

        public Form1()
        {
            InitializeComponent();
            drawArea = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Font myFont = new Font("Helvetica", 20, FontStyle.Italic);
            Brush myBrush = new SolidBrush(Color.Black);
            Font valFont = new Font("Helvetica", 50, FontStyle.Italic);
            Brush valBrush = new SolidBrush(Color.Orange);
            string str = textBox1.Text;

            //-----------------------making queue------------------------
            Queue q = new Queue();
            char[] delimiterChars = { ' ', '\'' };

            string text = str;
            string[] words = text.Split(delimiterChars);
            foreach (string s in words)
            {
                q.Enqueue(s);
            }

            //----------------------check for int and char----------------
            int search = 0;

            foreach (string s in words)
            {
                if ("int" == s) { search = 1; break; }
                else if ("char" == s) { search = 2; break; }
                else { search = 90; break; }
           
            }
            if(search==90) {
                    MessageBox.Show("Syntax Error. The sentence is expected to start with <int> or <char>", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //----------------Run the code for int-----------------------
            if (search == 1)
            {
                int l = 100, w = 100, v = 100, h = 100;

                //make a box for int
                Pen myPen = new Pen(Color.LightCoral, 5);
                Rectangle myRectangle = new Rectangle(v, h, l, w);
                drawArea.DrawRectangle(myPen, myRectangle);

                //Remove "int"
                q.Dequeue();

                // to obtain variable name
                Object obj = q.Peek();
                string display = obj.ToString();
                
                //Remove "variable name"
                q.Dequeue();

                //check whether it is int array or only int
                foreach (string s in words)
                {
                    if ("[" == s) { search = 3; break; }

                    else { search = 4; }
                }

                //for int
                if (search == 4)
                {
                    //Write variable name
                    drawArea.DrawString(display, myFont, myBrush, (l + v) * 325 / 400, (w + h) * 325 / 400);

                    //check for = sign
                    foreach (string sp in words)
                    {

                        if ("=" == sp) { search = 5; break; }

                        else { search = 0; }
                    }

                    if (search == 0)
                    {
                            MessageBox.Show("Syntax Error. Equal '=' sign is expected.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //if = sign is present, then...
                    if (search == 5)
                    {
                        //Remove "=" sign
                        q.Dequeue();

                        //Display the number(assigned number)
                        Object obj1 = q.Peek();
                        string display_no = obj1.ToString();
                        drawArea.DrawString(display_no, valFont, valBrush, l, w);
                    }

                }//search for int

     //-----------------------------------for array---------------------------------------
     
                
                else if (search == 3)
                {
                 
                    //Remove "["
                    q.Dequeue();

                    //Display the number(assigned number)
                    Object obj1 = q.Peek();
                    string display_no = obj1.ToString();
                    int num = Convert.ToInt32(obj1);

                    //Remove "number"
                    q.Dequeue();
                    //Remove "]"
                    q.Dequeue();
                    //Remove "="
                    q.Dequeue();

                    Object obj2 = q.Peek();
                    string assigned_no = obj2.ToString();
                    int num_assigned = Convert.ToInt32(obj2);

                    //Remove "assigned number"
                    q.Dequeue();

                    Pen pen = new Pen(Color.BlanchedAlmond, 3);
                    int temp = 100* 325 / 400;
                    int tem = 100;
                    for (int x = 0; x < num; x++)
                    {
                            drawArea.DrawRectangle(myPen, x * 100, 100, 100, 100);
                            drawArea.DrawString(display, myFont, myBrush, temp+(x*100), (w + h) * 325 / 400);
                            drawArea.DrawString(assigned_no, valFont, valBrush, (x * 100), tem);            
                     }
                   
                }

            }
    //-------------------------------------------for char-----------------------------------------
 
            else if (search == 2)
            {
                int l = 100, w = 100, v = 100, h = 100;

                //make a box for char
                Pen myPen = new Pen(Color.LightCoral, 5);
                Rectangle myRectangle = new Rectangle(v, h, l, w);
                drawArea.DrawRectangle(myPen, myRectangle);

                //Remove "char"
                q.Dequeue();

                // to display variable name
                Object obj = q.Peek();
                string display = obj.ToString();
                drawArea.DrawString(display, myFont, myBrush, (l + v) * 325 / 400, (w + h) * 325 / 400);

                //Remove "variable name"
                q.Dequeue();

                //check whether it is char array or only char
                foreach (string s in words)
                {
                    if ("[" == s) { search = 3; }

                    else { search = 4; }
                }

                //for char
                if (search == 4)
                {
                    //check for = sign
                    foreach (string sp in words)
                    {

                        if ("=" != sp) { /*Syntax error and break*/  }

                        else { search = 5; }
                    }

                    //if = sign is present, then...
                    if (search == 5)
                    {
                        //Remove "=" sign
                        q.Dequeue();

                        //Display the number(assigned number)
                        Object obj1 = q.Peek();
                        string display_no = obj1.ToString();
                        drawArea.DrawString(display_no, valFont, valBrush, l, w);
                    }

                }//search for int
            }

            


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear the screen to white colour every time the code executes
            drawArea.Clear(Color.White);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.BlanchedAlmond, 3);
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    drawArea.DrawRectangle(myPen, x * 100, y * 100, 100, 100);
                }
            }
        }


    }
}
//   Pen pen = new Pen(Color.Black);
//  drawArea.DrawLine(pen, 10,10,50,50);

/*            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            drawArea.FillEllipse(blueBrush, 50, 50, 200, 200);
 */
/*string str1 = "Equals";
string str2 = "Equals";

if (string.Equals(str1, str2))
{
Console.WriteLine("Strings are Equal() ");
}
else
{
Console.WriteLine("Strings are not Equal() ");
}
Console.ReadLine();*/