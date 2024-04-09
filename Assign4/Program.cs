using ClientSpace;

Client myClient = new();
List<Client> listOfClients = [];

LoadFileValuesToMemory(listOfClients); // work through main menu choices top down

bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = NewClient();
        if (mainMenuChoice == "S")
            ShowClientInfo(myClient);
        if (mainMenuChoice == "A")
            Console.WriteLine("Not Implemented Yet");
        AddClientToList(myClient, listOfClients);
        if (mainMenuChoice == "F")
            Console.WriteLine("Not Implemented Yet");
        FindClientInList(listOfClients);
        if (mainMenuChoice == "R")
            Console.WriteLine("Not Implemented Yet");
        RemoveClientFromList(myClient, listOfClients);
        if (mainMenuChoice == "D")
            Console.WriteLine("Not Implemented Yet");
        DisplayAllClientsInList(listOfClients);
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(listOfClients);
            loopAgain = false;
            throw new Exception("Bye, hope to see you again.");
        }
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nEnter an Edit Menu Choice: ").ToUpper();
                if (editMenuChoice == "F")
                    GetFirstName(myClient);
                if (editMenuChoice == "L")
                    GetLastName(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "H")
                    GetHeight(myClient);
                if (editMenuChoice == "R")
                    throw new Exception("Returning to Main Menu");
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
    Console.WriteLine("\nMain Menu");
    Console.WriteLine("N) New Client");
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
    Console.WriteLine("Edit Menu");
    Console.WriteLine("F) First Name");
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
    string myString = Prompt($"Please enter First Name: ");
    client.FirstName = myString;
}

void GetLastName(Client client)
{
    string myString = Prompt($"Please enter Last Name: ");
    client.LastName = myString;
}

void GetWeight(Client client)
{
    int myInt = PromptIntBetweenMinMax("Please enter Weight in pounds: ", 0, 300);
    client.Weight = myInt;
}

void GetHeight(Client client)
{
    int myInt = PromptIntBetweenMinMax("Please enter Height in inches: ", 0, 60);
    client.Height = myInt;
}

void ShowClientInfo(Client client)
{
    if (client == null)
        throw new Exception($"No Client In Memory");
    Console.WriteLine($"\n{client.ToString()}");
    Console.WriteLine($"BMI Score   :\t{client.BmiScore:n2}");
    Console.WriteLine($"BMI Status  :\t{client.BmiStatus}");
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
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return myString;
}

// double PromptDoubleBetweenMinMax(String msg, double min, double max)
// {
//     double num = 0;
//     while (true)
//     {
//         try
//         {
//             Console.Write($"{msg} between {min} and {max}: ");
//             num = double.Parse(Console.ReadLine());
//             if (num < min || num > max)
//                 throw new Exception($"Must be between {min:n2} and {max:n2}");
//             return num;
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Invalid: {ex.Message}");
//         }
//     }  
// }

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

// void DisplayClientInformation(Client myClient)
// {
//     Console.WriteLine($"\tFirst Name  :\t{myClient.FirstName}");
//     Console.WriteLine($"\tLast Name   :\t{myClient.LastName}");
//     Console.WriteLine($"\tWeight      :\t{myClient.Weight}");
//     Console.WriteLine($"\tHeight      :\t{myClient.Height}");
// }

void AddClientToList(Client myClient, List<Client> listOfClients)
{
    listOfClients.Add(myClient);
}

Client FindClientInList(List<Client> listOfClients)
{
    Console.WriteLine("Not Implemented Yet PartB");
    return new Client();
}

void RemoveClientFromList(Client myClient, List<Client> listOfClients)
{
    Console.WriteLine("Not Implemented Yet PartB");
}

void DisplayAllClientsInList(List<Client> listOfClients)
{
    foreach (Client client in listOfClients)
        ShowClientInfo(client);
}

void LoadFileValuesToMemory(List<Client> listOfClients)
{
    while (true)
    {
        try
        {
            //string fileName = Prompt("Enter file name including .csv or .txt: ");
            string fileName = "regin.csv";
            string filePath = $"./data/{fileName}";
            if (!File.Exists(filePath))
                throw new Exception($"The file {fileName} does not exist.");
            string[] csvFileInput = File.ReadAllLines(filePath);
            for (int i = 0; i < csvFileInput.Length; i++)
            {
                //Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
                string[] items = csvFileInput[i].Split(',');
                for (int j = 0; j < items.Length; j++)
                {
                    //Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
                }
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
    //string fileName = Prompt("Enter file name including .csv or .txt: ");
    string fileName = "regout.csv";
    string filePath = $"./data/{fileName}";
    string[] csvLines = new string[listOfClients.Count];
    for (int i = 0; i < listOfClients.Count; i++)
    {
        csvLines[i] = listOfClients[i].ToString();
    }
    File.WriteAllLines(filePath, csvLines);
    Console.WriteLine($"Save complete. {fileName} has {listOfClients.Count} entries.");
}




