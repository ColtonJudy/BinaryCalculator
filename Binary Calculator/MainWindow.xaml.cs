//Colton Judy
//Calculator that performs operations on two binary numbers

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinaryCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //initializes main window
        public MainWindow()
        {
            InitializeComponent();
        }

        //clears num1
        private void Num1Clear_Click(object sender, RoutedEventArgs e)
        {
            num1TextBox.Clear();
        }

        //clears num2
        private void Num2Clear_Click(object sender, RoutedEventArgs e)
        {
            num2TextBox.Clear();
        }

        //adds numbers
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;

            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            int num2 = Convert.ToInt32(num2TextBox.Text, 2);

            int result = num1 + num2;

            DisplayResults(num1, num2, '+', result);
        }

        //subtracts numbers
        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;


            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            int num2 = Convert.ToInt32(num2TextBox.Text, 2);

            int result = num1 - num2;

            DisplayResults(num1, num2, '-', result);
        }

        //multiplies numbers
        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;


            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            int num2 = Convert.ToInt32(num2TextBox.Text, 2);

            int result = num1 * num2;

            DisplayResults(num1, num2, '*', result);
        }

        //divides numbers
        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;

            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            int num2 = Convert.ToInt32(num2TextBox.Text, 2);

            if(num2 == 0)
            {
                MessageBox.Show("Cannot divide by 0", "Input error");
                return;
            }

            int result = num1 / num2;

            DisplayResults(num1, num2, '/', result);
        }

        //uses bitwise OR operator
        private void ORButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;

            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            int num2 = Convert.ToInt32(num2TextBox.Text, 2);

            int result = num1 | num2;

            DisplayResults(num1, num2, '|', result);
        }

        //uses bitwise AND operator
        private void ANDButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;

            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            int num2 = Convert.ToInt32(num2TextBox.Text, 2);

            int result = num1 & num2;

            DisplayResults(num1, num2, '&', result);
        }

        //uses bitwise XOR operator
        private void XORButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;

            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            int num2 = Convert.ToInt32(num2TextBox.Text, 2);

            int result = num1 ^ num2;

            DisplayResults(num1, num2, '^', result);
        }

        //uses bitwise NOT operator
        private void NOTButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsBad())
                return;

            int num1 = Convert.ToInt32(num1TextBox.Text, 2);
            num2TextBox.Clear();

            int result = ~ num1;

            DisplayResults(num1, '~', result);
        }

        //clears all fields
        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            num1TextBox.Clear();
            num2TextBox.Clear();
            binaryTextBox.Clear();
            decimalTextBox.Clear();
            octalTextBox.Clear();
            hexTextBox.Clear();
        }

        //tests if input is not a binary number
        private bool InputIsBad()
        {
            var errorMessage = "";

            //if fields are null, set them to 0 instead
            if (num1TextBox.Text == "")
                num1TextBox.Text = "0";

            if (num2TextBox.Text == "")
                num2TextBox.Text = "0";

            //test if num1 is a binary number
            for (int i = 0; i < num1TextBox.Text.Length; i++)
            {
                if (num1TextBox.Text[i] != '0' && num1TextBox.Text[i] != '1')
                {
                    errorMessage += "Number 1 must be a binary number";
                    break;
                }
            }

            //test if num2 is a binary number
            for (int i = 0; i < num2TextBox.Text.Length; i++)
            {
                if (num2TextBox.Text[i] != '0' && num2TextBox.Text[i] != '1')
                {
                    if (errorMessage.Length != 0)
                    {
                        errorMessage += "\n";
                    }

                    errorMessage += "Number 2 must be a binary number";
                    break;
                }
            }

            //if there is an error message, display it on screen
            if (errorMessage.Length == 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show(errorMessage, "Input error");
                return true;
            }
        }

        //display results in decimal, binary, octal, and hecidecimal
        private void DisplayResults(int num1, int num2, char operation, int result)
        {
            decimalTextBox.Text = num1 + " " + operation + " " + num2 + " = " + result;

            binaryTextBox.Text = Convert.ToString(num1, 2) + " " + operation + " " + Convert.ToString(num2, 2) + " = " + Convert.ToString(result, 2);
            
            octalTextBox.Text = Convert.ToString(num1, 8) + " " + operation + " " + Convert.ToString(num2, 8) + " = " + Convert.ToString(result, 8);
            
            hexTextBox.Text = (Convert.ToString(num1, 16) + " " + operation + " " + Convert.ToString(num2, 16) + " = " + Convert.ToString(result, 16)).ToUpper();

        }

        //display results in decimal, binary, octal, and hecidecimal for operations with 1 operand (bitwise NOT)
        private void DisplayResults(int num1, char operation, int result)
        {
            decimalTextBox.Text = operation + " " + num1 + " = " + result;

            binaryTextBox.Text = operation + " " + Convert.ToString(num1, 2) + " = " + Convert.ToString(result, 2);

            octalTextBox.Text = operation + " " + Convert.ToString(num1, 8) + " = " + Convert.ToString(result, 8);

            hexTextBox.Text = (operation + " " + Convert.ToString(num1, 16) + " = " + Convert.ToString(result, 16)).ToUpper();
        }
    }
}
