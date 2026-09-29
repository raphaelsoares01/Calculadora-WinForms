using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TreinoA
{
    public partial class Form1 : Form
    {
        double value1 = 0;
        string operation = "";
        bool isNewNumber = true;

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isNewNumber || txtDisplay.Text == "0")
            {
                txtDisplay.Text = btn.Text;
                isNewNumber = false;
            } 
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (operation != "")
            {
                txtHistory.Text = Calcular().ToString() + " " + btn.Text;
            } 
            else
            {
                txtHistory.Text = txtDisplay.Text.ToString() + " " + btn.Text;
            }

            operation = btn.Text;
            value1 = double.Parse(txtDisplay.Text);
            isNewNumber = true;
        }

        private void btnEqualsOperation_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void btnCeOperation_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void btnClearOperation_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            txtHistory.Text = "";
            value1 = 0;
            operation = "";
            isNewNumber = true;
        }

        private void btnBackspaceOperation_Click(object sender, EventArgs e)
        {
            string displayText = txtDisplay.Text;

            if (displayText.Length > 0)
            {
                txtDisplay.Text = displayText.Substring(0, displayText.Length - 1);
                
                if (txtDisplay.Text == "")
                {
                    txtDisplay.Text = "0";
                    isNewNumber = true;
                }
            }
        }

        private void btnCommaOperation_Click(object sender, EventArgs e)
        {
            bool canComma = true;

            for (int i = 0; i < txtDisplay.Text.Length; i++)
            {
                if (txtDisplay.Text[i] == ',')
                {
                    canComma = false;
                }
            }

            if (canComma)
            {
                txtDisplay.Text += ",";
                isNewNumber = false;
            }
        }

        private void btnPlusMinusOperation_Click(object sender, EventArgs e)
        {
            if (txtHistory.Text != "")
            {
                txtHistory.Text = "negate" + "(" + txtDisplay.Text + ")";
            }

            if (double.Parse(txtDisplay.Text) > 0)
            {
                txtDisplay.Text = "-" + txtDisplay.Text;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text.Substring(1, txtDisplay.Text.Length - 1);
            }
        }

        private double Calcular()
        {
            double value2 = double.Parse(txtDisplay.Text);
            double result = 0;

            switch (operation)
            {
                case "+": result = value1 + value2; break;
                case "-": result = value1 - value2; break;
                case "×": result = value1 * value2; break;
                case "÷":
                    if (value2 == 0)
                    {
                        txtDisplay.Text = "Cannot divide by zero";
                        operation = "";
                        isNewNumber = true;
                        return 0;
                    }
                    result = value1 / value2; 
                    break;
                case "":
                    txtDisplay.Text = value2.ToString();
                    txtDisplay.Text = txtDisplay.Text.ToString();
                    operation = "";
                    isNewNumber = true;
                    return 0;
            }

            txtDisplay.Text = result.ToString();
            txtHistory.Text = value1.ToString() + " " + operation.ToString() + " " + value2.ToString() + " =";
            operation = "";
            isNewNumber = true;
            
            return result;
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
