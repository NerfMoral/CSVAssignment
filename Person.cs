namespace CSVAssignment
{
    internal class Person
    {
        public string Id { get; set; }
        public string Gender { get; set; }
        public string Titel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Telefon { get; set; }
        public string Mobile { get; set; }
        public string EMail { get; set; }
        public string Newsletter { get; set; }
        public Person (string id, string gender, string titel, string firstName, string lastName, string birthday, string street, string houseNumber, string zipcode, string city, string telefon, string mobile, string eMail, string newsletter)
        {
            Id = id;
            Gender = gender;
            Titel = titel;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Street = street;
            HouseNumber = houseNumber;
            Zipcode = zipcode;
            City = city;
            Telefon = telefon;
            Mobile = mobile;
            EMail = eMail;
            Newsletter = newsletter;
        }
        public override string ToString ()
        {
            return "#" + Id + " " + Gender + " " + Titel + " " + FirstName + " " + LastName + " " + Birthday + " " + Street + " " + HouseNumber + " " + Zipcode + " " + City + " " + Telefon + " " + Mobile + " " + EMail + " " + Newsletter;
        }
    }
}
