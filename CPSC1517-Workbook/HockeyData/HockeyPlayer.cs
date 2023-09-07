namespace Hockey.Data
{
    /// <summary>
    /// An instance of this class will hold data about a hockey player
    /// The code for this class is the definition of that data
    /// The characteristics (data) of the class are:
    ///     first name, last name, weight, height, date of birth, position, shot, birthplace
    /// </summary>
    public class HockeyPlayer
    {
        // There are four components of a class definition
        // - data fields (data members)
        // - property
        // - constructor
        // - behaviour (methods)

        // Data Fields
        // are storage areas in the class
        // these are treated as variables
        // these may be public, private, public readonly
        private string _firstName;
        private string _lastName;
        private DateOnly _dateOfBirth;
        private int _weightInPounds;
        private int _heightInInches;
        // The following are unnecessary as enums are used
        // private Position _position = Position.Center;
        // private Shot _shot;
        private string _birthPlace;

        // Constructor
        // Constructors are used to initialize an instance of the class.
        // The result purpose for implementing a constructor is to ensure that the data
        // fields are in a known and valid state.
        //
        // If your class definition has NO explicit construtor included, the data fields
        //   and/or auto-implemented properties are set to the default C# data type value
        // You can code one or more constructos (overloading) in the class definition
        // If you code a constructor for the class, you are responsible for all constructors
        //   used by the class (i.e. only the ones you create are valid)
        // If you are going to code your own constructor(s) you will likely code the following
        //   two:
        //   1) Default: this constructor does not accept any parameters
        //   2) Greedy: this constructor defines a list of parameters, one for each 
        //      property
        //
        // Syntax: access classname([list of parameters]) { code block }
        //
        // IMPORTANT: Constructors do not have a return type
        //            You do not call a constructor directly, must be preceded by the 
        //            "new" operator
        //            E.g. HockeyPlayer player = new HockeyPlayer(...)

        // Default constructor
        /// <summary>
        /// Creates a default instance of a HockeyPlayer
        /// </summary>
        public HockeyPlayer()
        {
            // Constructor body: 
            // a) If empty: the C# defualts for each field will be assigned
            // b) You can provide literal values to your fields/properties with this constructor

            // Ensure that you assign values that would pass any validation rules you set
            // for property mutators, or better yet, assign to the properties to make use 
            // of validation rules directly - avoid duplicating validation logic in the 
            // constructor method(s)
            //
            // You may want to code validation logic in the constructor(s) if you have implemented
            // a readonly property or if the data member has only a private set.
            _firstName = string.Empty;
            _lastName = string.Empty;
            _birthPlace = string.Empty;
            _dateOfBirth = new DateOnly();
            _weightInPounds = 0;
            _heightInInches = 0;
            Shot = Shot.Right;
            Position = Position.Center;
        }

        // Greedy Constructor
        public HockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth,
            int weightInPounds, int heightInInches, Shot shot, Position position)
        {
            // Constructor body:
            // a) A parameter for every property
            // b) You COULD perform validation here, but he properties already do it, so just use them
            // c) Validation for public readonly data members MUST be done here
            // d) validation for properties with a private set MUST be done here
            //    if not done in the property
            FirstName = firstName;
            LastName = lastName;
            BirthPlace = birthPlace;
            DateOfBirth = dateOfBirth;
            WeightInPounds = weightInPounds;
            HeightInInches = heightInInches;
            Shot = shot;
            Position = position;
        }

        // Property
        // these are access techniques to retrieve or set data in
        // the class without directly 'touching' the storage data field
        // allows for protection of data field

        // A property is associated with a single instance of data
        // A property is public so it can be accessed outside the class
        // A property MUST have a 'get'
        // A property MAY have a 'set'
        // - if no 'set' is present, the property cannot be modified;
        //   it is effectively readonly, which is commonly used for derived data of
        //   the class
        // - the set can be either public or privte
        //     public: user can alter contents
        //     private: only code within the class can alter contents

        // Fully-implemented property
        // a) a declared storage area (data field)
        // b) a declared property signature (access type name)
        // c) a coded accessor (get) method: public
        // d) an optional coded mutator (set) method: public or private
        //    if the set is private, it can only be used in a constructor or other method

        // When to use:
        // a) if you are storing the data in an explicitly declared data field
        // b) if you are doing validation on incoming data
        // c) if you are creating a property that generates output based on other sources
        //    within the class (readonly property); this property would ONLY have an
        //    accessor (get)
        public string FirstName
        {
            get
            {
                // Accessor
                // The get block will return teh contents of the associated data field
                // The return has syntax of return expression
                return _firstName;
            }
            set
            {
                // Mutator
                // The set block receives an incoming "value" and places it into the associated field
                // During the set, you can perform validation on the incoming value
                // During the set, you may also want to perform some logical processing using the value  
                //    to set another field

                // Ensure the incoming value is not null, empty, or whitespace (invalid values)
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"First name cannot be null empty.");
                }

                // If we get here, the value is "good" and we can assign to the data field
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Last name cannot be null empty.");
                }

                _lastName = value;
            }
        }

        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Birth place cannot be null empty.");
                }

                _birthPlace = value;
            }
        }

        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value >= DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentException($"Date of birth cannot be in the future.");
                }

                _dateOfBirth = value;
            }
        }

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height must be positive.");
                }

                _heightInInches = value;
            }
        }

        public int WeightInPounds
        {
            get
            {
                return _weightInPounds;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Weight must be positive.");
                }

                _weightInPounds = value;
            }
        }

        // Auto-implemented property - using an enum so no validation necessary
        public Position Position { get; set; }

        public Shot Shot { get; set; }
    }
}