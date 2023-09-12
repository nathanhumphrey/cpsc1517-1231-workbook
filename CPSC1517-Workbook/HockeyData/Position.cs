namespace Hockey.Data
{
    // An enumeration type (or enum type) is a value type defined by a set of named constants
    // of the underlying integral type. To define an enumeration type, use the 'enum'
    // keyword and specify the names of the enum members.
    //
    // By default, the type used for enum members is 'int', but this can be changed to a more
    // suitable integral type (i.e. to a smaller type likke byte or short).
    public enum Position
    {
        // By default, the initial value assigned to the first enum member is '0'
        // But, this can be altered by assigning a value as below:
        LeftWing = 1,
        // Each subsequent member will be assigned the previous member's value incremented
        // by 1; so RightWing below will be assigned a value of '2'
        // You can assign values to all memebers in the enum if desired
        RightWing,
        Center,
        Defense,
        Goalie,
    }
}