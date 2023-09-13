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
        /// <summary>
        /// Tests for a positive int value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if positive, false otherwise</returns>
        public static bool IsPositive(int value)
        {
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

        // Expression-bodied method
        /// <summary>
        /// Tests for a zero or positive int value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if zero or positive, false otherwise</returns>
        public static bool IsZeroOrPositive(int value) => value >= 0 ? true : false;

        /// <summary>
        /// Tests for a zero or negative int value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if zero or negative, false otherwise</returns>
        public static bool IsZeroOrNegative(int value) => value <= 0 ? true : false;

        #endregion

        #region String Validators
        /// <summary>
        /// Tests for an empty string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if null, empty or white space, false otherwise</returns>
        public static bool IsNullEmptyOrWhiteSpace(string value) => String.IsNullOrWhiteSpace(value);

        #endregion

        #region Date Validators

        /// <summary>
        /// Tests for a DateTime in the future from now
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if the value is in the future or now, false otherwise</returns>
        public static bool IsInTheFuture(DateTime value) => value >= DateTime.Now;
        
        /// <summary>
        /// Tests for a DateOnly in the future from now
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if the value is in the future excluding today, false otherwise</returns>
        public static bool IsInTheFuture(DateOnly value) => value > DateOnly.FromDateTime(DateTime.Now);
        #endregion
    }
}