using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniraknare_Laboration2
{
    public partial class Form1 : Form
    {
        double value = 0;
        string operation = "";
        bool operation_pressed = false;
        public Form1()
        {
            InitializeComponent();
        }
        ///Event hanlder for number buttons
        private void number_click(object sender, EventArgs e)
        {
            if((tb1.Text == "0") || (operation_pressed))
            {
                tb1.Clear();
            }
            operation_pressed = false;
            Button button = (Button)sender;
            tb1.Text = tb1.Text + button.Text;
        }
        ///Event hanlder for clear button
        private void clear_click(object sender, EventArgs e)
        {
            tb1.Text = "0";
            equation.Text = string.Empty;
            value = 0;
        }
        ///Event hanlder for operation buttons
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(value != 0 && operation_pressed == false)
            {
                btn12.PerformClick();
                operation_pressed = true;
                operation = button.Text;
                equation.Text = value + " " + operation;
            }
            else { 
                operation = button.Text;
                try
                {
                    value = double.Parse(tb1.Text);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("number to big!");
                    tb1.Text = "";
                    equation.Text = "";
                    value = 0;
                    operation = "";
                    return;
                }
                operation_pressed = true;
                equation.Text = value + " " + operation;
            }
        }
        ///Event hanlder for equal button
        private void equal_click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    try
                    {
                        tb1.Text = (value + double.Parse(tb1.Text)).ToString();
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("number to big!");
                        tb1.Text = "";
                        equation.Text = "";
                        value = 0;
                        operation = "";
                        return;
                    }
                    break;
                case "-":
                    tb1.Text = (value - double.Parse(tb1.Text)).ToString();
                    break;
                case "x":
                    try
                    {
                        tb1.Text = (value * double.Parse(tb1.Text)).ToString();
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("number to big!");
                        tb1.Text = "";
                        equation.Text = "";
                        value = 0;
                        operation = "";
                        return;
                    }
                    break;
                case "/":
                    if (double.Parse(tb1.Text) != 0)
                    {
                        tb1.Text = (value / double.Parse(tb1.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("division with zero!");
                        tb1.Text = "";
                        equation.Text = "";
                        value = 0;
                        operation = "";
                        return;
                    }
                    break;
                default:
                    break;
            }// the end of switch statement
            try
            {
                value = double.Parse(tb1.Text);
            }
            catch (OverflowException)
            {
                MessageBox.Show("number to big!");
                tb1.Text = "";
                equation.Text = "";
                value = 0;
                operation = "";
                return;
            }
            operation = "";
        }
    }
}
     