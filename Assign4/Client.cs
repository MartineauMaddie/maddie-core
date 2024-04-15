namespace ClientSpace
{
    public class Client
    {
        //Private Fields
        private string _firstName;
        private string _lastName;
        private int _weight;
        private int _height;

        // Non-Greedy Constructor
        public Client()
        {
            FirstName = "Jane";
            LastName = "Doe";
            Weight = 150;
            Height = 67;
        }

        // Greedy Constructor
        public Client(string firstName, string lastName, int weight, int height)
        {
            FirstName = firstName;
            LastName = lastName;
            Weight = weight;
            Height = height;
        }

        // Fully Implemented Properties
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("A First Name is required. Must not be empty or blank.");
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("A Last Name is required. Must not be empty or blank.");
                _lastName = value.Trim();
            }
        }

        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentNullException("Please enter a Weight greater than 0.");
                _weight = value;
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                    throw new ArgumentNullException("Please enter a Height greater than 0.");
                _height = value;
            }
        }

        // read Only Fully Implemented Properties

        public double BmiScore
        {
            get
            {
                double BmiScore = Weight / Math.Pow(Height, 2) * 703;
                return BmiScore;
            }
        }

        public string BmiStatus
        {
            get
            {
                string BmiStatus = "";
                if (BmiScore <= 18.4)
                    BmiStatus = "Underweight";
                if (BmiScore >= 18.5 && BmiScore <= 24.9)
                    BmiStatus = "Normal";
                if (BmiScore >= 25.0 && BmiScore <= 39.9)
                    BmiStatus = "Overweight";
                if (BmiScore >= 40)
                    BmiStatus = "Obese";
                return BmiStatus;
            }
        }

        public string FullName
        {
            get
            {
                string FullName = $"{LastName}, {FirstName}";    
                return FullName;
            }
        }

        public override string ToString()
        {
            return $"{FirstName},{LastName},{Weight},{Height}";
        }
    }
}