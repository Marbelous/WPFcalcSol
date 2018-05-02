namespace WPFcalcProj
{
    public class CalcMath
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;

            }
            else
            {
                return double.NaN;
            }
        }
    }
}
