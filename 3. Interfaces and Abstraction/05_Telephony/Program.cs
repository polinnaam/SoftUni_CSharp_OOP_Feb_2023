
using Telephony;

string[] phoneNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < phoneNumbers.Length; i++)
{
    bool areAllDigits = true;
    foreach (var digit in phoneNumbers[i])
    {
        if (!char.IsDigit(digit))
        {
            Console.WriteLine("Invalid number!");
            areAllDigits = false;
            break;
        }
    }
    if (phoneNumbers[i].Length == 10 && areAllDigits == true)
    {
        Smartphone smartphone = new Smartphone();
        Console.WriteLine(smartphone.Calling(phoneNumbers[i]));        
    }
    else if (phoneNumbers[i].Length == 7 && areAllDigits == true)
    {
        StationaryPhone stationaryPhone = new StationaryPhone();
        Console.WriteLine(stationaryPhone.Calling(phoneNumbers[i]));
    }
}
string[] browsedSites = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < browsedSites.Length; i++)
{
    bool isThereDigit = false;
    foreach (var word in browsedSites[i])
    {
        if (char.IsDigit(word))
        {
            Console.WriteLine("Invalid URL!");
            isThereDigit = true;
            break;
        }
    }
    if (isThereDigit == false)
    {
        Smartphone smartphone = new Smartphone();
        Console.WriteLine(smartphone.Browsing(browsedSites[i]));
    }
}