using ClientSpace;

Client myClient = new();
List<Client> listOfClients = [];

LoadFileValuesToMemory(listOfClients);

bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter a Main Menu selection: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = NewClient();
        if (mainMenuChoice == "S")
            ShowClientInfo(myClient);
        if (mainMenuChoice == "A")
        {
            AddClientToList(myClient, listOfClients);
            myClient = new();
        }
        if (mainMenuChoice == "F")
            myClient = FindClientInList(listOfClients);
        if (mainMenuChoice == "R")
        {
            RemoveClientFromList(myClient, listOfClients);
            myClient = new();
        }
        if (mainMenuChoice == "D")
            DisplayAllClientsInList(listOfClients);
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(listOfClients);
            loopAgain = false;
            throw new Exception("\nBye, hope to see you again.");
        }
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nEnter an Edit Menu selection: ").ToUpper();
                if (editMenuChoice == "F")
                    GetFirstName(myClient);
                if (editMenuChoice == "L")
                    GetLastName(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "H")
                    GetHeight(myClient);
                if (editMenuChoice == "R")
                    throw new Exception("\nReturning to Main Menu");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

void DisplayMainMenu()
{
    Console.WriteLine("\nMain Menu\n=========");
    Console.WriteLine("\nN) New Client");
    Console.WriteLine("S) Show Client Info");
    Console.WriteLine("E) Edit Client Info");
    Console.WriteLine("A) Add Client to List");
    Console.WriteLine("F) Find Client in List");
    Console.WriteLine("R) Remove Client from List");
    Console.WriteLine("D) Display Client List");
    Console.WriteLine("Q) Quit");
}

void DisplayEditMenu()
{
    Console.WriteLine("\nEdit Client Menu\n================");
    Console.WriteLine("\nF) First Name");
    Console.WriteLine("L) Last Name");
    Console.WriteLine("W) Weight");
    Console.WriteLine("H) Height");
    Console.WriteLine("R) Return to Main Menu");
}

Client NewClient()
{
    Client myClient = new();
    GetFirstName(myClient);
    GetLastName(myClient);
    GetWeight(myClient);
    GetHeight(myClient);
    return myClient;
}

void GetFirstName(Client client)
{
    string myString = Prompt($"\nPlease enter client's First Name: ");
    client.FirstName = myString;
}

void GetLastName(Client client)
{
    string myString = Prompt($"\nPlease enter client's Last Name: ");
    client.LastName = myString;
}

void GetWeight(Client client)
{
    int myInt = PromptIntBetweenMinMax("\nPlease enter client's Weight in pounds", 0, 300);
    client.Weight = myInt;
}

void GetHeight(Client client)
{
    int myInt = PromptIntBetweenMinMax("\nPlease enter client's Height in inches", 0, 90);
    client.Height = myInt;
}

void ShowClientInfo(Client myClient)
{
    if (myClient == null)
        throw new Exception($"No Client In Memory");
    Console.WriteLine($"\n========= Client Info =========");
    Console.WriteLine($"\nClient Name  :\t{myClient.FullName}");
    Console.WriteLine($"Weight       :\t{myClient.Weight} lbs.");
    Console.WriteLine($"Height       :\t{myClient.Height} inches");
    Console.WriteLine($"BMI Score    :\t{myClient.BmiScore:n1}");
    Console.WriteLine($"BMI Status   :\t{myClient.BmiStatus}");
}

void AddClientToList(Client myClient, List<Client> listOfClients)
{
    if (myClient == null)
        throw new Exception($"No Client In Memory");
    listOfClients.Add(myClient);
    // There was a bug here where editing the client in memory would also edit the same client in the list despite the client in memory not being added to the list yet. 
    // I made the client in memory set to the default client after clients were added or removed from the list. This seemed to work.
    // myClient = new();
}

Client FindClientInList(List<Client> listOfClients)
{
    string searchString = Prompt("\nEnter part of Clients first or last name: ");
    foreach (Client client in listOfClients)
        if (client.LastName.Contains(searchString) || client.FirstName.Contains(searchString))
            return client;
    Console.WriteLine($"\nNo Clients match search terms.");
    return null;
}

void RemoveClientFromList(Client myClient, List<Client> listOfClients)
{
    if (myClient == null)
        throw new Exception($"No Client In Memory");
    Console.WriteLine($"\n{myClient.FullName} is being removed.");
    listOfClients.Remove(myClient);
    Console.WriteLine("\nClient removed.");
}

void DisplayAllClientsInList(List<Client> listOfClients)
{
    // listOfClients.Sort(delegate ((string, string, int, int) cli1, (string, string, int, int) cli2)
    // {
    //     return cli1.LastName.CompareTo(cli2.LastName);
    // });

    listOfClients.Sort((cli1, cli2) =>
    {
        return cli1.LastName.CompareTo(cli2.LastName);
    });
    foreach (Client client in listOfClients)
        ShowClientInfo(client);
}

void LoadFileValuesToMemory(List<Client> listOfClients)
{
    while (true)
    {
        try
        {
            string fileName = "regin.csv";
            string filePath = $"./data/{fileName}";
            if (!File.Exists(filePath))
                throw new Exception($"The file {fileName} does not exist.");
            string[] csvFileInput = File.ReadAllLines(filePath);
            for (int i = 0; i < csvFileInput.Length; i++)
            {
                string[] items = csvFileInput[i].Split(',');
                Client myClient = new(items[0], items[1], int.Parse(items[2]), int.Parse(items[3]));
                listOfClients.Add(myClient);
            }
            Console.WriteLine($"Load complete. {fileName} has {listOfClients.Count} data entries");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

void SaveMemoryValuesToFile(List<Client> listOfClients)
{
    string fileName = "regout.csv";
    string filePath = $"./data/{fileName}";
    string[] csvLines = new string[listOfClients.Count];
    for (int i = 0; i < listOfClients.Count; i++)
    {
        csvLines[i] = listOfClients[i].ToString();
    }
    File.WriteAllLines(filePath, csvLines);
    Console.WriteLine($"\nSave complete. {fileName} has {listOfClients.Count} entries.");
}

string Prompt(string prompt)
{
    string myString = "";
    while (true)
    {
        try
        {
            Console.Write(prompt);
            myString = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(myString))
                throw new Exception($"Please enter something.");
            return myString;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

int PromptIntBetweenMinMax(string msg, int min, int max)
{
    int num = 0;
    while (true)
    {
        try
        {
            Console.Write($"{msg} between {min} and {max}: ");
            num = int.Parse(Console.ReadLine());
            if (num < min || num > max)
                throw new Exception($"Must be between {min} and {max}");
            return num;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
}


