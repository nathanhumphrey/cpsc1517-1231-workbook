namespace Utils
{
    public static class Utilities
    {
        // Static classes are NOT instantiated
        // Static class members (i.e. properties or methods) are referenced by
        //   ClassName.Member
        // Methods within a static class have the keyword static in their
        //   signature
        // Static classes are shared by all outside users at the SAME time
        // DO NOT consider saving data within a static class because you cannot
        // be certain it will be there when you use the class again

        // Numeric Validators
        // ==============================================================================

        /// <summary>
        /// Tests for a positive int value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if positive, false otherwise</returns>
        public static bool IsPositive(int value)
        {
            // The following statement makes use of the condition or ternary
            // operator. The operator evaluates a boolean expression and 
            // returns the result of one of the following expressions: the 
            // expression following the '?' if the expression is true, and
            // the expression following the ':' if the expression is false.
            // Read more here: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
            return value > 0 ? true : false;
        }

        /// <summary>
        /// Tests for a negative int value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if negative, false otherwise</returns>
        public static bool IsNegative(int value)
        {
            return value < 0 ? false : true;
        }
        // The following is an example of an expression-bodied method

        /// <summary>
        /// Tests for a zero or positive int value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if zero or positive, false otherwise</returns>
        public static bool IsZeroOrPositive(int value) => value >= 0;

        /// <summary>
        /// Tests for a zero or negative int value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if zero or negative, false otherwise</returns>
        public static bool IsZeroOrNegative(int value) => value <= 0;

        // String Validators
        // ==============================================================================

        /// <summary>
        /// Tests for an empty string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if null, empty or white space, false otherwise</returns>
        public static bool IsNullEmptyOrWhiteSpace(string value) =>
            String.IsNullOrWhiteSpace(value);

        // Date Validators
        // ==============================================================================

        // The following two methods are named the same, but have differing method
        // signatures. This is technique is known as overloading methods. In this
        // way, we can call the same method but passing in different parameters,
        // which enables the system to determine which version of the method to execute.
        // Read more here: https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading

        /// <summary>
        /// Tests for a DateTime in the future from now
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if value is in the future or now, false otherwise</returns>
        public static bool IsInTheFuture(DateTime value) => value >= DateTime.Now;

        /// <summary>
        /// Tests for a DateOnly in the future from now
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// True if value is in the future excluding today, false otherwise
        /// </returns>
        public static bool IsInTheFuture(DateOnly value) =>
            value > DateOnly.FromDateTime(DateTime.Now);
    }
}