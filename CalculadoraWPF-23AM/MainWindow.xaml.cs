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

namespace CalculadoraWPF_23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;

            string value = (string)button.Content;

            if (IsNumber(value))//Validar si es un número
            {
                HandleNumbers(value);
            }
            else if (IsOperator(value))
            {
                HandleOperators(value);
            }
            else if (value == "CE")
            {
                Screen.Clear();
            }
            else if (value == "=") 
            {
                HandleEquals(Screen.Text);
            }

        }


        private void HandleNumbers(string value)
        {

            if (String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;




            }

        }


        // Métodos Auxiliares
        private bool IsNumber(string num)
        {
            return double.TryParse(num, out _);
        }


        private bool IsOperator(string possibleOperator)
        {
            return possibleOperator == "+" || possibleOperator == "-" || possibleOperator == "*" ||
                possibleOperator == "/";

        }

        private void HandleOperators(string value)
        {
            if (!String.IsNullOrEmpty(Screen.Text) && !ContainsOtherOperators(Screen.Text))
            {

                Screen.Text += value;

            }

        }

        private bool ContainsOtherOperators(string screenContent)
        {
            return screenContent.Contains("+") || screenContent.Contains("-") || screenContent.Contains("*") ||
                screenContent.Contains("/");
        }

        private void HandleEquals(string screenContent)
        {
            string op = FindOperator(screenContent);

            // Arreglar bien el tema de los números negativos. Esto es temporal. 
            if (!String.IsNullOrEmpty(op))

                
                    switch (op)
                    {
                        case "+":
                            Screen.Text = Sum();
                            break;
                    }

                
        }

        private string FindOperator(string screenContent)
        {
            foreach (char c in screenContent)
            {
                if (IsOperator(c.ToString()))
                {
                    return c.ToString();
                }
               
            }
            return screenContent;
        }

        // Operaciones
        private string Sum()
        {
            string[] numbers = Screen.Text.Split("+");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 + n2, 12).ToString();
        }
    }



}
