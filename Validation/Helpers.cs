namespace Validation
{
    public class Helpers
    {
        public bool IsValueEntered(string value)
        {
            return string.IsNullOrEmpty(value) || value == " " ? false : true;
        }

        public bool IsValueEntered(int? value)
        {
            return value == null ? false : true;
        }
    }
}
