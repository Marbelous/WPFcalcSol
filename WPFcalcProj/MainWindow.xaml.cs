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
        private OpClicked opClicked;

        public MainWindow()
        {
            InitializeComponent();

            equalsButton.Click += EqualsButton_Click;
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentButton.Click += PercentButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out newValue))
            {
                switch (opClicked)
                {
                    case OpClicked.Add:
                        result = CalcMath.Add(lastValue, newValue);
                        break;
                    case OpClicked.Subtract:
                        result = CalcMath.Subtract(lastValue, newValue);
                        break;
                    case OpClicked.Multiply:
                        result = CalcMath.Multiply(lastValue, newValue);
                        break;
                    case OpClicked.Divide:
                        result = CalcMath.Divide(lastValue, newValue);
                        break;
                }
                resultLabel.Content = result;
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

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
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
                char opClicked;
                
                Button sourceButton = e.Source as Button;
                char.TryParse(sourceButton.Content.ToString(), out opClicked);
                resultLabel.Content = "0";
                resultLabel.Content = opClicked;
                // sourceButton.Background = 
            }
        }
    }

    public enum OpClicked
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}
