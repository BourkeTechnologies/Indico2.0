namespace Indico20CodeBase.Extensions
{
    public static class BoolExtensions
    {
        public static 
            int ToOneZero(this bool value)
        {
            return value ? 1 : 0;
        }
    }
}
