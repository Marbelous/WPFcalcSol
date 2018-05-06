using System.Windows;
using System.Windows.Controls;

namespace WPFcalcProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private double lastValue, newValue, result;
        private OpClickedEnum opClickedEnum;
        string opClicked;

        public MainWindow()
        {
            InitializeComponent();

            equalsButton.Click += EqualsButton_Click;
            acButton.Click += AcButton_Click;
            negateButton.Click += NegateButton_Click;
            percentButton.Click += PercentButton_Click;
            decimalButton.Click += DecimalButton_Click;
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                // Ignore if it's another decimal point.
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out newValue))
            {
                switch (opClicked)
                {
                    case "+":
                        result = CalcMath.Add(lastValue, newValue);
                        break;
                    case "-":
                        result = CalcMath.Subtract(lastValue, newValue);
                        break;
                    case "*":
                        result = CalcMath.Multiply(lastValue, newValue);
                        break;
                    case "/":
                        result = CalcMath.Divide(lastValue, newValue);
                        break;
                }
                resultLabel.Content = result;

                lastValue = 0f;
                newValue = 0f;
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastValue))
            {
                lastValue *= .01;
                resultLabel.Content = lastValue;
            }
        }

        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastValue) && resultLabel.Content.ToString() != "0")
            {
                lastValue *= -1;
                resultLabel.Content = lastValue;
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int numberClicked = 0;
            Button sourceButton = e.Source as Button;
            int.TryParse(sourceButton.Content.ToString(), out numberClicked);

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{numberClicked.ToString()}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{numberClicked.ToString()}";
            }
        }

        private void OpButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastValue))
            {
                Button sourceButton = e.Source as Button;
                opClicked = sourceButton.Content.ToString();
                resultLabel.Content = "0";
            }
        }
    }

    public enum OpClickedEnum
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}
