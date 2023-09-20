namespace ObjectClassLibrary
{
    public class BodyMassIndex
    {
        private double _weight;
        private double _height;
        public string Name { get; private set; }

        public double Weight
        {
            get
            {
                // FIX: Incorrect field referenced
                return _weight;
            }
            set
            {
                if (value <= 0)
                {
                    // FIX: Incorrect exception type and message
                    //throw new ArgumentNullException("Weight must be a positive non-zero value");
                    throw new ArgumentOutOfRangeException("Weight must be a positive non-zero number", new ArgumentException());
                }
                // FIX: Incorrect property referenced
                _weight = value;
            }
        }
        public double Height
        {
            get
            {
                // FIX: Circular reference, should return field
                return _height;
            }
            set
            {
                if (value <= 0)
                {
                    // FIX: Incorrect exception type and message
                    //throw new ArgumentException("Height must be a positive non-zero value");
                    throw new ArgumentOutOfRangeException("Height must be a positive non-zero number", new ArgumentException());
                }
                _height = value;
            }
        }
        public BodyMassIndex(string name, double weight, double height)
        {
            // FIX: Incorrect condition, must NOT be empty
            //if (string.IsNullOrWhiteSpace(name))
            if (!string.IsNullOrWhiteSpace(name))
            {
                // FIX: The following won't work: param assigned to param
                //name = name;
                Name = name;
            }
            else
            {
                // FIX: Incorrect exception type
                //throw new ArgumentException("Name cannot be blank");
                throw new ArgumentNullException("Name cannot be blank", new ArgumentException());
            }
            this.Weight = weight;
            // FIX: Reversed property and param
            this.Height = height;
        }
        /// <summary>
        /// Calculate the body mass index (BMI) using the weight and height of the person.
        ///
        /// The BMI of a person is calculated using the formula: BMI = 700 * weight / (height * height)
        /// where weight is in pounds and height is in inches.
        /// </summary>
        /// <returns>the body mass index (BMI) value of the person</returns>
        public double Bmi()
        {
            // FIX: Incorrect use of Math.Pow
            //double bmiValue = 703 * Weight / Math.Pow(2, Height);
            double bmiValue = 703 * Weight / Math.Pow(Height, 2);
            bmiValue = Math.Round(bmiValue, 1);
            return bmiValue;
        }
        /// <summary>
        /// Determines the BMI Category of the person using their BMI value.
        /// </summary>
        /// <returns>one of following: underweight, normal, overweight, obese.</returns>
        public string BmiCategory()
        {
            string category = "Unknown";
            double bmiValue = Bmi();
            if (bmiValue < 18.5)
            {
                category = "underweight";
            }
            if (bmiValue < 24.9)
            {
                category = "normal";
            }
            if (bmiValue < 29.9)
            {
                category = "overweight";
            }
            if (bmiValue >= 30)
            {
                category = "obese";
            }
            return category;
        }
    }
}