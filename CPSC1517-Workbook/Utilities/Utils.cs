namespace Utilities
{
    public static class Utils
    {
        // Static classes are NOT instantiated
        // Static class members (i.e. properties or methods) are referenced by
        //    ClassName.Member
        // Methods within a static class have the keyword static in their signature
        // Static classes are shared by all outside users at the SAME time
        // DO NOT consider saving data within a static class because you cannot be certain
        // it will be there when you use the class again

        // The #region directive allows you to define an area of your code that you expand and
        // collapse for readability/organization
        #region Numeric Validators
        public static bool IsPositive(int value)
        {
            return value > 0 ? true : false;
        }

        public static bool IsNegative(int value)
        {
            return value < 0 ? false : true;
        }

        // Expression-bodied method
        public static bool IsZeroOrPositive(int value) => value >= 0 ? true : false;
        public static bool IsZeroOrNegative(int value) => value <= 0 ? true : false;

        #endregion

        #region String Validators
        public static bool IsNullEmptyOrWhiteSpace(string value) => String.IsNullOrWhiteSpace(value);

        #endregion

        #region Date Validators
        public static bool IsInTheFuture(DateTime value) => value >= DateTime.Now;
        public static bool IsInTheFuture(DateOnly value) => value >= DateOnly.FromDateTime(DateTime.Now);
        #endregion
    }
}