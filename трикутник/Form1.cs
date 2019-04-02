using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace трикутник
{
    

    public partial class Form1 : Form
       
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        public int level = 0;
        public Pen pen = new Pen(Color.Red, 3);

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: {  pen = new Pen(Color.Red); } break;
                case 1: {  pen = new Pen(Color.Black); } break;
                case 2: {  pen = new Pen(Color.Green); } break;
                case 3: {  pen = new Pen(Color.Blue); } break;
                case 4: {  pen = new Pen(Color.Yellow); } break;
                case 5: {  pen = new Pen(Color.Pink); } break;


            }
        }


        private void DrawTriangle(Graphics g, int level, PointF A, PointF B, PointF C)
        {
           
            if (level == 0)
            {
                
                PointF[] points =  { A, C, B};
                g.DrawPolygon(pen, points);
            }
            else
            {
               
                PointF a = new PointF(
                    (A.X + B.X) / 2f,
                    (A.Y + B.Y) / 2f);

                PointF b = new PointF(
                    (A.X + C.X) / 2f,
                    (A.Y + C.Y) / 2f);

                PointF c = new PointF(
                    (B.X + C.X) / 2f,
                    (B.Y + C.Y) / 2f);

               
                DrawTriangle(g, level - 1,  A, a, b);
                DrawTriangle(g, level - 1, a, B, c);
                DrawTriangle(g, level - 1, b, c, C);
            }
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(bitmap);
              
            float x1 = 100;
            float y1 = 500;
            float x2 = 600;
            float y2 = 500;
            float x3 = 350;
            float y3 = 100;
      
           
            PointF A = new PointF(x1, y1);
            PointF B = new PointF(x2, y2);
            PointF C = new PointF(x3, y3);

           
            DrawTriangle(g, level, A, B, C);

            level++;
            textBox1.Text = Convert.ToString(level);
            

            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
