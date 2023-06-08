using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        //title of the company
        string companyName;
        Font companyFont;
        Brush companyBrush;
        Color companyColor;
        //revenue of the company
        public string revenueName { get; set; } 
        string fontFamily;//
        int fontSize;//
        public static Font revenueFont { get; set; }
        public Brush revenueBrush { get; set; }
        public static Color revenueColor { get; set; }
        //the table
        Color tableColor;
        Rectangle tableRec;
        Pen tablePen;
        Point topLeftPoint;
        int spanx;
        int spany;
        //table data
        Brush tableDataBrush;
        Color tableDataColor;
        Font tableDataFont;
        int[] Years = { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
        int[] Revenue = { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 };
        //chart structure
        Point cornerPoint;
        //chart data
        HatchStyle chartHatch;
        Color chartForColor;
        Brush chartDataBrush;
        Pen chartPen;
        

        public Form1()
        {
            InitializeComponent();
            //title of the company
            companyName = "ABC Company";
            companyFont = new Font("Times New Roman", 20,FontStyle.Underline);      
            companyColor = Color.Black;
            companyBrush= new SolidBrush(companyColor);
            //revenue title
            revenueName = "Annual Revenue";
            fontFamily = "Times New Roman";
            fontSize = 16;
            revenueColor= Color.Black;
            
            //table
            tableColor= Color.Black;
            tablePen= new Pen(tableColor,3);
            topLeftPoint= new Point(1150,190);
            spany = 50;
            spanx = 150;
            tableRec= new Rectangle(topLeftPoint.X,topLeftPoint.Y,300,550);
            //table data
            tableDataColor= Color.Blue;
            tableDataBrush= new SolidBrush(tableDataColor);
            tableDataFont= new Font("Times New Roman", 20);
            //chart
            cornerPoint = new Point(100,740);
            //char data
            chartHatch = HatchStyle.ForwardDiagonal;
            chartForColor = Color.Red;
            chartPen=new Pen(Color.Blue,3);
            this.MainMenuStrip = menuStrip1;//msh mohma                 

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            displayCompanyTitle();
            displayRevenueTitle();
            displayTable();
            displayTableData() ;
            displayGraph();
            displayChartData();
        }
        public void displayCompanyTitle()
        {
            Graphics g=this.CreateGraphics();
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            g.DrawString(companyName, companyFont, companyBrush, new Point(this.Width/2,50),sf);

        }
        public void displayRevenueTitle()
        {
            
            Graphics g=this.CreateGraphics();
            revenueBrush = new SolidBrush(revenueColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            revenueFont = new Font(fontFamily, fontSize, FontStyle.Underline);
        
            g.DrawString(revenueName, revenueFont, revenueBrush, new Point(this.Width / 2, 100), sf);
        }
        public void displayTable() {
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(tablePen, tableRec);
            int f=0;
            for(int i = 0; i < 11; i++)
            {
                f += 50;
                g.DrawLine(tablePen, new Point(topLeftPoint.X,topLeftPoint.Y+f), new Point(topLeftPoint.X+spanx*2,topLeftPoint.Y+f));
            }
            g.DrawLine(tablePen, new Point(topLeftPoint.X+spanx,topLeftPoint.Y), new Point(topLeftPoint.X+spanx,topLeftPoint.Y+spany*11));
          
        }
        public void displayTableData()
        {
            Graphics g = this.CreateGraphics();          
            int paddingx = 40;
            int paddingy = 10;
            //left table data
            int z = 0;
            g.DrawString("Years", tableDataFont, tableDataBrush, topLeftPoint.X + paddingx, topLeftPoint.Y + paddingy);
            for (int i=0; i < 10; i++)
            {
                z += spany;
                g.DrawString(Years[i].ToString(), tableDataFont, tableDataBrush, topLeftPoint.X + paddingx, topLeftPoint.Y + paddingy+z);
         
            }
            //right table date
             z = 0;
            g.DrawString("Revenue", tableDataFont, tableDataBrush, topLeftPoint.X+spanx + paddingx-10, topLeftPoint.Y + paddingy);
            for (int i = 0; i < 10; i++)
            {
                z += spany;
                g.DrawString(Revenue[i].ToString(), tableDataFont, tableDataBrush, topLeftPoint.X + paddingx+spanx, topLeftPoint.Y + paddingy + z);
            }
        }
        public void displayGraph()
        {
            Graphics g = this.CreateGraphics();
            g.DrawLine(tablePen, cornerPoint.X, cornerPoint.Y,cornerPoint.X+900,cornerPoint.Y);
            g.DrawLine(tablePen, cornerPoint.X, cornerPoint.Y,cornerPoint.X,cornerPoint.Y-650);
            int x = 0;
            int y=0;
            int h = 80;
            for(int i=0;i< 10; i++)
            {
                y += 60;
                x += 80;
                h += 20;
                g.DrawLine(tablePen, cornerPoint.X +x,cornerPoint.Y-5,cornerPoint.X + x, cornerPoint.Y + 5);
                g.DrawLine(tablePen, cornerPoint.X -5,cornerPoint.Y-y,cornerPoint.X + 5, cornerPoint.Y - y);
                g.DrawString(Years[i].ToString(),tableDataFont,tableDataBrush,cornerPoint.X+x-35,cornerPoint.Y+20);
                g.DrawString(h.ToString(),tableDataFont,tableDataBrush,cornerPoint.X-60,cornerPoint.Y-y-15);
            }
            //drawing arrows
            g.DrawLine(tablePen, cornerPoint.X, cornerPoint.Y - 650, cornerPoint.X - 20, cornerPoint.Y - 620);
            g.DrawLine(tablePen, cornerPoint.X, cornerPoint.Y - 650, cornerPoint.X + 20, cornerPoint.Y - 620);
            g.DrawLine(tablePen, cornerPoint.X + 900, cornerPoint.Y, cornerPoint.X + 870, cornerPoint.Y + 20);
            g.DrawLine(tablePen, cornerPoint.X + 900, cornerPoint.Y, cornerPoint.X + 870, cornerPoint.Y - 20);
            //typing years and revenue at the end
            g.DrawString("Years", tableDataFont, tableDataBrush, cornerPoint.X+910 , cornerPoint.Y -15);
            g.DrawString("Revenue", tableDataFont, tableDataBrush, cornerPoint.X-40 , cornerPoint.Y -690);
        }
        public void displayChartData()
        {
            Graphics g = this.CreateGraphics();
            int xoff = 80;
            int yoff = 60;
            //drawing line chart
            g.DrawLine(chartPen, cornerPoint.X + xoff, cornerPoint.Y-3.5f*yoff, cornerPoint.X+2*xoff,cornerPoint.Y - 4.5f*yoff);
            g.DrawLine(chartPen, cornerPoint.X + 2 * xoff, cornerPoint.Y - 4.5f * yoff, cornerPoint.X + 3 * xoff, cornerPoint.Y - 5 * yoff);
            g.DrawLine(chartPen, cornerPoint.X + 3 * xoff, cornerPoint.Y - 5 * yoff, cornerPoint.X + 4 * xoff, cornerPoint.Y - 4.75f * yoff);
            g.DrawLine(chartPen, cornerPoint.X + 4 * xoff, cornerPoint.Y - 4.75f * yoff, cornerPoint.X + 5 * xoff, cornerPoint.Y - 6 * yoff);
            g.DrawLine(chartPen, cornerPoint.X + 5 * xoff, cornerPoint.Y - 6 * yoff, cornerPoint.X + 6 * xoff, cornerPoint.Y - 8.5f * yoff);
            g.DrawLine(chartPen, cornerPoint.X + 6 * xoff, cornerPoint.Y - 8.5f * yoff, cornerPoint.X + 7 * xoff, cornerPoint.Y - 6.5f * yoff);
            g.DrawLine(chartPen, cornerPoint.X + 7 * xoff, cornerPoint.Y - 6.5f * yoff, cornerPoint.X + 8 * xoff, cornerPoint.Y - 8 * yoff);
            g.DrawLine(chartPen, cornerPoint.X + 8 * xoff, cornerPoint.Y - 8 * yoff, cornerPoint.X + 9 * xoff, cornerPoint.Y - 10 * yoff);
            g.DrawLine(chartPen, cornerPoint.X + 9 * xoff, cornerPoint.Y - 10 * yoff, cornerPoint.X + 10 * xoff, cornerPoint.Y - 3 * yoff);
            //drawing barchart
            chartDataBrush = new HatchBrush(chartHatch, chartForColor, Color.Empty);
            g.FillRectangle(chartDataBrush, cornerPoint.X + xoff-40, cornerPoint.Y - 3.5f * yoff,xoff, 3.5f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 2 * xoff-40, cornerPoint.Y - 4.5f * yoff, xoff, 4.5f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 3 * xoff-40, cornerPoint.Y - 5 * yoff, xoff, 5f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 4 * xoff-40, cornerPoint.Y - 4.75f * yoff, xoff, 4.75f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 5 * xoff-40, cornerPoint.Y - 6 * yoff, xoff, 6f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 6 * xoff-40, cornerPoint.Y - 8.5f * yoff, xoff, 8.5f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 7 * xoff-40, cornerPoint.Y - 6.5f * yoff, xoff, 6.5f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 8 * xoff-40, cornerPoint.Y - 8 * yoff, xoff, 8f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 9 * xoff-40, cornerPoint.Y - 10 * yoff, xoff, 10f * yoff);
            g.FillRectangle(chartDataBrush, cornerPoint.X + 10 * xoff-40, cornerPoint.Y - 3 * yoff, xoff, 3f * yoff);
            
        }public void falseColorLine()
        {
            redToolStripMenuItem1.Checked=false;
            blueToolStripMenuItem1.Checked=false;
            greenToolStripMenuItem1.Checked=false;
        }
        public void falseStyleLine()
        {
            solidToolStripMenuItem1.Checked= false;
            dashToolStripMenuItem1.Checked= false;
            dotToolStripMenuItem1.Checked= false;
        }
        public void falseColorChart()
        {
            redToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
        }
        public void falseStyleChart()
        {
            solidToolStripMenuItem.Checked = false;
            dashToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((int)e.KeyChar)
            {
                case 2:
                    chartPen.Color = Color.Blue;
                    break;
                case 7:
                    chartPen.Color = Color.Green;
                    break;
                case 18:
                    chartPen.Color = Color.Red;
                    break;

            }
            Invalidate();


        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.X>=cornerPoint.X && e.X <= cornerPoint.X + 840 && e.Y<=cornerPoint.Y &&e.Y>=cornerPoint.Y-600)
            {
                MessageBox.Show("Year = " + (+(e.X - cornerPoint.X) / 80 +1987) +"  "+ "Revenue= "+(+(cornerPoint.Y - e.Y)/3+80)); // 60px==>20
                                                                                                                                  //  1px ==> ? 
            }
        }

        private void styleToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartHatch = HatchStyle.ForwardDiagonal;
            Invalidate();
            falseStyleChart();
            solidToolStripMenuItem.Checked = true;

        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chartPen.Color = Color.Red;
            Invalidate();
            falseColorLine();
            redToolStripMenuItem1.Checked = true;

        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chartPen.Color = Color.Green;
            Invalidate();
            falseColorLine();
            greenToolStripMenuItem1.Checked = true;
        }

        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chartPen.Color = Color.Blue;
            Invalidate();
            falseColorLine();
            blueToolStripMenuItem1.Checked = true;

        }

        private void solidToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chartPen.DashStyle= DashStyle.Solid;
            Invalidate();
            falseStyleLine();
            solidToolStripMenuItem1.Checked = true;
        }

        private void dashToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chartPen.DashStyle = DashStyle.Dash;
            Invalidate();
            falseStyleLine();
            dashToolStripMenuItem1.Checked = true;
        }

        private void dotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chartPen.DashStyle = DashStyle.Dot;
            Invalidate();
            falseStyleLine();
            dotToolStripMenuItem1.Checked = true;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartForColor = Color.Red;
            Invalidate();
            falseColorChart();
            redToolStripMenuItem.Checked= true;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartForColor = Color.Green;
            Invalidate();
            falseColorChart();
            greenToolStripMenuItem.Checked = true;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartForColor = Color.Blue;
            Invalidate();
            falseColorChart();
            blueToolStripMenuItem.Checked = true;
        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartHatch = HatchStyle.BackwardDiagonal;
            Invalidate();
            falseStyleChart();
            dashToolStripMenuItem.Checked = true;
        }

        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartHatch = HatchStyle.Cross;
            Invalidate();
            falseStyleChart();
            dotToolStripMenuItem.Checked = true;
        }

        private void colorToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >=cornerPoint.X && e.X <= cornerPoint.X+900 && e.Y<=cornerPoint.Y&& e.Y>=cornerPoint.Y-650 ) {
                this.ContextMenuStrip = contextMenuStrip1;              
            }
            else
            {
                this.ContextMenuStrip = contextMenuStrip2;
            }
            if (e.X >= cornerPoint.X && e.X <= cornerPoint.X + 840 && e.Y <= cornerPoint.Y && e.Y >= cornerPoint.Y - 600)
            {
/*                MessageBox.Show("Year = " + (+(e.X - cornerPoint.X) / 80 + 1987) + "  " + "Revenue= " + (+(cornerPoint.Y - e.Y) / 3 + 80)); // 60px==>20
*/                toolStripStatusLabel1.Text= "Year = " + (+(e.X - cornerPoint.X) / 80 + 1987) ;                                                                                                                  //  1px ==> ? 
                   toolStripStatusLabel2.Text= "Revenue= " + (+(cornerPoint.Y - e.Y) / 3 + 80) ;
            }
            else
            {
                toolStripStatusLabel1.Text = "Year=";
                toolStripStatusLabel2.Text = "Revenue= ";
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog_Box dialog1 = new Dialog_Box();
            dialog1.Owner = this;
            //3shan lma a5osh ala2yha checked
            dialog1.Txt1 = revenueName;
            dialog1.RadioFont = fontFamily;
            dialog1.RadioSize = fontSize;
            
            DialogResult dialogResult= dialog1.ShowDialog();
            if(dialogResult== DialogResult.OK)
            {
                //3shan y8yr 2l name
                if (dialog1.Txt2 == "")
                {
                    
                    revenueName = dialog1.Txt1;
                 
                }
                else
                {
                    revenueName = dialog1.Txt2;    
                }
                //3shan lma a3lm 3leha t8yr f 2l klma
                fontFamily = dialog1.RadioFont;
                fontSize = dialog1.RadioSize;
                Invalidate();
               
            }
            
        }
    }
}
