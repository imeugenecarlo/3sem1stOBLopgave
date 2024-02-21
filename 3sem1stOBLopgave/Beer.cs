namespace _3sem1stOBLopgave
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Abv { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Abv}"; 
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException(nameof(Name),"Name cannot be null");
            }

            if(Name.Length < 3)
            {
                throw new ArgumentException("Name must include 3 or more characters", nameof(Name));
            }
        }

        public void ValidateAbv()
        {
            if (Abv <= -1 || Abv >=68) 
            {
                throw new ArgumentOutOfRangeException(nameof(Abv),"ABV value must have a value between 0% and 67%");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateAbv();
        }


    }
}
