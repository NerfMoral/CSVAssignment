namespace CSVAssignment
{
    internal class Program
    {
        static void Main (string[] args)
        {
            // Relative path to the CSV file
            string filePath = "Resources\\TestDaten.csv";
            List<Person> persons = new();

            // open a new stream
            using (var reader = new StreamReader(GetFullPathByFilename(filePath))) {
                while (!reader.EndOfStream) {
                    // read a line
                    String line = reader.ReadLine();
                    //split the line with the delimiter ";" (each cell)
                    string[] splitLine = line.Split(";");
                    persons.Add(new Person(splitLine[0], splitLine[1], splitLine[2], splitLine[3], splitLine[4], splitLine[5], splitLine[6], splitLine[7], splitLine[8], splitLine[9], splitLine[10], splitLine[11], splitLine[12], splitLine[13]));

                }
            }
            persons.RemoveAt(0);
            #region Task1
            //Geben Sie an wie viele Personen den Newsletter abonniert haben.
            var newsletter = (from person in persons
                              where person.Newsletter.Contains("ja")
                              select person).Count();
            Console.WriteLine($"Amount of People subscribed to the newsletter: {newsletter}");
            #endregion
            #region Task2
            //Geben Sie an wie viele Prozent der Kunden männlich und wie viele weiblich sind.
            double maleRatio = (double)(from person in persons where person.Gender.Contains("Herr") select person).Count() / (double)(from person in persons select person).Count();
            double femaleRatio = (double)(from person in persons where person.Gender.Contains("Frau") select person).Count() / (double)(from person in persons select person).Count();

            Console.WriteLine($"male Ratio :{Math.Round(maleRatio * 100, 2)}% \t female Ratio {Math.Round(femaleRatio * 100, 2)}%");
            #endregion
            #region Task3
            //Geben Sie den häufigsten E-Mail-Provider an.
            Dictionary<string, int> EMails = new();
            // select all emails and save them in Email
            var EMail = from person in persons select person.EMail;
            foreach (var mail in EMail) {
                //split each valid email into only the provider part
                if (!String.IsNullOrEmpty(mail)) {
                    string[] splitEMail = mail.Split("@");
                    //if the email provider already exists add 1, otherwise add a new dictionary key value pair
                    if (!EMails.ContainsKey(splitEMail[1])) {
                        EMails.Add(splitEMail[1], 1);
                    } else {
                        EMails[splitEMail[1]] += 1;
                    }
                }
            }
            foreach (var mail in EMails) {
                Console.WriteLine($"There are {mail.Value} people associated with the Provider {mail.Key}");
            }
            #endregion
            #region Task4+5
            //Listen Sie die Kunden gruppiert nach Alter auf.
            //Geben Sie Name, Nachname und Alter, nicht Geburtstag, aller Kunden aus, welche einen Eintrag „Geburtsdatum“ haben.
            Func<string, int> age = x =>
            {
                if (!String.IsNullOrEmpty(x)) {
                    string[] splitBirthday = x.Split(".");
                    return 2024 - Int32.Parse(splitBirthday[2]);
                } else {
                    return -1;
                }
            };
            var groupAge = from person in persons orderby age(person.Birthday) group person by age(person.Birthday);
            foreach (var altersgruppe in groupAge) {
                Console.WriteLine($"Altersgruppe: {altersgruppe.Key}");

                foreach (var p in altersgruppe) {
                    Console.WriteLine($"First Name: {p.FirstName} \tLast Name: {p.LastName}");
                }
            }
            #endregion
            #region Task6
            // Der gesamte Datensatz soll sich in der Konsole in einzelnen Blöcken zu jeweils 50 Datensätzen anzeigen lassen.  
            int j = 0;
            string str = "n";
            do {
                for (int i = 0; i < 50 && j < persons.Count; i++, j++) {
                    Console.WriteLine(persons[j].ToString());
                }
                if (j < persons.Count) {
                    Console.WriteLine("Continue ? Press [y] to print 50 more entries");
                    str = Console.ReadLine();
                } else {
                    Console.WriteLine("Printed all persons, nothing more to do");
                }
            } while (str == "y" && j < 500);
            #endregion
            #region Task7
            //Ermöglichen Sie einem Nutzer den Namen einer Stadt einzugeben damit der Datensatz nach dieser Stadt gefiltert wird.
            //Gestalten Sie die ausgegebenen Kundendaten die dem Nutzer dann bezüglich dieser Stadt angezeigt werden nach Belieben.
            Console.WriteLine("Please input a city to filter by: ");
            string input = Console.ReadLine();
            var cityFilter = from person in persons where person.City == input select person;
            Console.WriteLine($"In City \"{input}\" live:\n");
            foreach (var person in cityFilter) {
                Console.WriteLine($"Name: {person.FirstName}, {person.LastName}");
            }
            #endregion
        }


        public static string GetFullPathByFilename (string fileName)
        {
            //Console.WriteLine("" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\"+fileName);
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\" + fileName;
        }
    }
}
