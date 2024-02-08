using WypozyczalniaFilmow;

string access = "";
while (access != "pracownik" && access != "klient")
{
    Console.WriteLine("Wybierz dostep: pracownik, klient");
    access = Console.ReadLine();
    if (access != "pracownik" && access != "klient")
        Console.WriteLine("Podales zla wartosc");
}

bool end = true;
while (end)
{
    Console.WriteLine("--------------------------------------------------------------------------------------------------");
    Console.WriteLine("1. Informacje o filmie \n" + "2. Dane klientow \n" + "3. Wypozyczenie \n" + "4. Stan magazynu \n" + "5. Wyciagnij z magazynu \n" + "6. Dodaj do magazynu");
    Console.WriteLine("--------------------------------------------------------------------------------------------------");
    string selectedFunction = Console.ReadLine();
    if (selectedFunction == "end")
        break;

    switch (selectedFunction)
    {
        case "1":
            Movies movies = new Movies();
            DigitalMovies digitalMovies = new DigitalMovies();
            PhysicalMovies physicalMovies = new PhysicalMovies();
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("1. Wyswietl wszystkie filmy \n" + "2. Wyszukaj film \n" + "3. Wyszukaj wszystkie filmy cyfrowe \n" + "4. Wyszukaj wszystkie filmy na plytce");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            string selectMovies = Console.ReadLine();
            if (selectMovies == "end")
                break;
            switch (selectMovies)
            {
                case "1":
                    movies.getAllMovies();
                    break;

                case "2":
                    Console.WriteLine("Podaj tytul filmu");
                    string movieTitle = Console.ReadLine();
                    if (movieTitle == "end")
                        break;
                    movies.getMovie(movieTitle);
                    break;

                case "3":
                    digitalMovies.getAllDigitalMovies();
                    break;

                case "4":
                    physicalMovies.getAllPhysicallMovies();
                    break;
            }
            break;

        case "2":
            if (access == "pracownik")
            {
                Customers customers = new Customers();
                PremiumCustomers premiumCustomers = new PremiumCustomers();
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Wyswietl wszystkich klientow \n" + "2. Wyszukaj klienta \n" + "3. Klienci premium");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                string selectCustomers = Console.ReadLine();
                if (selectCustomers == "end")
                    break;
                switch (selectCustomers)
                {
                    case "1":
                        customers.getAllCustomers();
                        break;

                    case "2":
                        Console.WriteLine("Podaj imie");
                        string name = Console.ReadLine();
                        if (name == "end")
                            break;
                        Console.WriteLine("Podaj nazwisko");                       
                        string surname = Console.ReadLine();
                        if (surname == "end")
                            break;
                        customers.getCustomer(name, surname);
                        break;

                    case "3":
                        premiumCustomers.getAllPremiumCustomers();
                        break;
                }
            }
            else
                Console.WriteLine("Nieautoryzowany dostep");
            break;

        case "3":
            Rental rent = new Rental();
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("1. Dodaj wypozyczenie \n" + "2. Wypisz wszystie wypozyczenia klienta \n" + "3. Usun wypozyczenie");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            string selectRent = Console.ReadLine();
            if (selectRent == "end")
                break;
            switch (selectRent)
            {
                case "1":
                    Console.WriteLine("Podaj nazwe filmu: ");
                    string movieName = Console.ReadLine();
                    if (movieName == "end")
                        break;
                    Console.WriteLine("Podaj dane klienta: ");
                    string clientName = Console.ReadLine();
                    if (clientName == "end")
                        break;
                    Console.WriteLine("Podaj date wypozyczenia: ");
                    DateOnly rentDate = DateOnly.Parse(Console.ReadLine());
                    DateOnly returnDate = rentDate.AddMonths(3);
                    Console.WriteLine("Podaj cene wypozyczenia: ");
                    double rentCost = Convert.ToDouble(Console.ReadLine());

                    if (movieName != null && clientName != null)
                        rent.addRental(movieName, clientName, rentDate, returnDate, rentCost);
                    else
                        Console.WriteLine("Nie uzupelniono poprawnie formularza");

                    break;

                case "2":
                    if (access == "pracownik")
                    {
                        Console.WriteLine("Podaj imie i nazwisko klienta: ");
                        string rentalClient = Console.ReadLine();
                        if (rentalClient == "end")
                            break;
                        if (rentalClient != null)
                            rent.findRentals(rentalClient);
                        else
                            Console.WriteLine("Nie podano klienta");
                    }
                    else
                        Console.WriteLine("Nieautoryzowany dostep");
                    break;

                case "3":
                    if (access == "pracownik")
                    {
                        Console.WriteLine("Podaj imie i nazwisko klienta: ");
                        string clientNameRemove = Console.ReadLine();
                        if (clientNameRemove == "end")
                            break;
                        Console.WriteLine("Podaj tytul filmu: ");
                        string movieNameRemove = Console.ReadLine();
                        if (movieNameRemove == "end")
                            break;
                        rent.deleteRental(movieNameRemove, clientNameRemove);
                    }
                    else
                        Console.WriteLine("Nieautoryzowany dostep");
                    break;
            }

            break;

        case "4":
            MovieStorage storage = new MovieStorage();
            storage.getAmmount();
            break;

        case "5":
            if (access == "pracownik")
            {
                MovieStorage storedMoviesRemoving = new MovieStorage();
                Console.WriteLine("Podaj tytul: ");
                string titleRemove = Console.ReadLine();
                if (titleRemove == "end")
                    break;
                storedMoviesRemoving.removeMovie(titleRemove);
            }
            else
                Console.WriteLine("Nieautoryzowany dostep");
            break;

        case "6":
            if (access == "pracownik")
            {
                MovieStorage storedMoviesAdding = new MovieStorage();
                Console.WriteLine("Podaj tytul: ");
                string titleAdd = Console.ReadLine();
                if (titleAdd == "end")
                    break;
                storedMoviesAdding.addMovie(titleAdd);
            }
            else
                Console.WriteLine("Nieautoryzowany dostep");
            break;
    }
}

