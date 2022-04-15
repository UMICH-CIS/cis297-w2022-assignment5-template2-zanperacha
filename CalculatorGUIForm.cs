using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculatorGUI
{
   public partial class CalculatorGUIForm : Form
   {
        
      public CalculatorGUIForm()
      {
         InitializeComponent();
      }

        private void CalculatorGUIForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }


        /// <summary>
        /// This method allows the user to enter a decimal using the keypad on the calculator itself. They can also just use the keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        /// <summary>
        /// This method allows the user to enter a slash to indicate a division operation. They can also type it in the keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "/";
        }


        /// <summary>
        /// This is for all numbers on the calculator. Any time a number key is pressed it will show up in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberButton_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
        }

        /// <summary>
        /// This method takes a string that the user enters and returns it without any whitespaces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnWithoutWhitespaces_Click(object sender, EventArgs e)
        {
            string value = "";
            value = textBox1.Text;
            value = String.Concat(value.Where(c => !Char.IsWhiteSpace(c)));
            Result.Text = value;
        }

        /// <summary>
        /// This method takes a string that the user enters and returns it in reverse 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseString_Click(object sender, EventArgs e)
        {
            string value = "";
            value = textBox1.Text;
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            value = new string(charArray);
            Result.Text = value;
        }

        /// <summary>
        /// This method finds the log base 10 of whatever number the user entered into the calculator. **Enter a number and press the logbase10 button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findLogBase10_Click(object sender, EventArgs e)
        {
            string value = "";
            value = textBox1.Text;
            double num = 0.0;
            double resultNum = 0.0;
            num = double.Parse(value);
            resultNum = Math.Log10(num);
            Result.Text = resultNum.ToString();
        }

        /// <summary>
        /// Finds the log base x of a specified number. **Enter in the format of number,base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findLogBaseX_Click(object sender, EventArgs e)
        {
            string value = "";
            value = textBox1.Text;
            string[] nums = value.Split(',');
            double resultNum = 0;
            double num1 = 0, baseNum = 0;
            num1 = double.Parse(nums[0]);
            baseNum = double.Parse(nums[1]);
            resultNum = Math.Log(num1, baseNum);
            Result.Text = resultNum.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
        }

        /// <summary>
        /// Finds the min and max of two numbers entered. **Enter in the format number,number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findMinMax_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            string[] nums = value.Split(',');
            int num1 = 0, num2 = 0, min, max;
            num1 = int.Parse(nums[0]);
            num2 = int.Parse(nums[1]);
            min = Math.Min(num1, num2);
            max = Math.Max(num1, num2);
            Result.Text = $"Minimum: {min}, Maximum: {max}";
        }

        /// <summary>
        /// Finds the number to a specified exponent. **Enter in the format number^exponent and then press equal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exponent_Click(object sender, EventArgs e)
        {
            /*string value = textBox1.Text;
            string[] nums = value.Split('^');
            double num1 = 0, num2 = 0, answer = 0;
            num1 = double.Parse(nums[0]);
            num2 = double.Parse(nums[1]);
            answer = Math.Pow(num1, num2);
            Result.Text = answer.ToString();*/
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
        }

        /// <summary>
        /// Equal button for the calculator. Only used for the division and exponent functions. All other methods use their own buttons as the equal operator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void equals_Click(object sender, EventArgs e)
        {
            bool div = false, exp = false;
            string value = textBox1.Text;
            for (int i = 0; i < value.Length; ++i)
            {
                if (value[i] == '/')
                {
                    div = true;
                }

                if (value[i] == '^')
                {
                    exp = true;
                }
            }

            if (div == true)
            {
                int num1 = 0, num2 = 0;
                int quotient = 0, remainder = 0;
                string[] nums = value.Split('/');
                num1 = int.Parse(nums[0]);
                num2 = int.Parse(nums[1]);
                quotient = num1 / num2;
                remainder = num1 % num2;
                Result.Text = $"Quotient: {quotient}, Remainder: {remainder}";
            }

            if (exp == true)
            {
                string[] nums = value.Split('^');
                double num1 = 0, num2 = 0, answer = 0;
                num1 = double.Parse(nums[0]);
                num2 = double.Parse(nums[1]);
                answer = Math.Pow(num1, num2);
                Result.Text = answer.ToString();
            }
        }

        /// <summary>
        /// Finds the square root of an entered number. Enter number and press findSqrt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findsqrt_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            double num, answer = 0;
            num = double.Parse(value);
            answer = Math.Sqrt(num);
            Result.Text = answer.ToString();
        }

        /// <summary>
        /// Finds roots of an equation. Enter in the format a,b,c where a b and c are coefficients for the equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findroots_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            string[] coefficients = value.Split(',');
            double a, b, c, d, x1, x2;
            a = double.Parse(coefficients[0]);
            b = double.Parse(coefficients[1]);
            c = double.Parse(coefficients[2]);

            d = (Math.Pow(b, 2) - (4 * a * c));

            if (d == 0)
            {
                x1 = -b / (2.0 * a);
                x2 = x1;
                Result.Text = $"Roots are {x1} and {x2}";
            }

            else if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2.0 * a);
                x2 = (-b - Math.Sqrt(d)) / (2.0 * a);
                Result.Text = $"Roots are {x1} and {x2}";
            }

            else
            {
                Result.Text = "No real roots";
            }

        }
    }
}

/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/