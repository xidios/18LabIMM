using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastLab
{
    public partial class Form1 : Form
    {
        public int numberOfWindows;
        public int customersQueue;
        public int customersServed;
        Random rand = new Random();
        public double lb = 200, m = 80;
        public Form1()
        {
            InitializeComponent();
            customersQueue = 0;
            customersServed = 0;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            windowsUpDown.Enabled = false;
            numberOfWindows = (int)windowsUpDown.Value;
            customersServed = numberOfWindows;
            textBox1.Text = "";

            timer1.Start();

        }
        private double countValues(double n)
        {
            return n * Math.Exp(n * rand.NextDouble() * (-1));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Box2.Text = customersServed.ToString();
            Box1.Text = customersQueue.ToString();
            double theory = countValues(lb);
            double discrete = countValues(m * customersServed);


            UpdateTexbar(ref theory, ref discrete);
            CheckTD(ref theory, ref discrete);




        }

        private void UpdateTexbar(ref double theory, ref double discrete)
        {
            textBox1.Text += "Обслужено: " + customersServed + Environment.NewLine;
            textBox1.Text += "Очередь: " + customersQueue + Environment.NewLine;
            textBox1.Text += "N: " + numberOfWindows + Environment.NewLine + "Теор.распределение: " + theory + Environment.NewLine + "Discrete: " + discrete + Environment.NewLine;
        }

        private void CheckTD(ref double theory, ref double discrete)
        {
            if (theory > discrete)
            {
                if (customersServed >= numberOfWindows)
                    customersQueue++;

                else
                    customersServed++;
            }
            else
            {
                if (customersQueue == 0)
                {
                    if (customersServed > 0)
                        customersServed--;

                }
                else
                {
                    if (customersQueue > 0)
                        customersQueue--;
                }
            }
        }
        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            Box2.Text = "";
            Box1.Text = "";
            windowsUpDown.Enabled = true;
            textBox1.Text += "Stop" + Environment.NewLine;
            customersServed = 0;
            customersQueue = 0;
        }

        
    }
}
