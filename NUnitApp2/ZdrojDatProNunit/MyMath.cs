namespace ZdrojDatProNunit
{
    public class MyMath
    {

        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        public string GetTextFromX()
        {
            return "ABCD";
        }

        public bool IsPositiveNumber(decimal value)
        {
            if (value >= 0)
            {
                return true;
            }
            return false;
        }
    }
}