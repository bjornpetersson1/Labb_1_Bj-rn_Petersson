// "29535123p48723487597645723645"
static int[] FindFirstAndLastCharIndexes(string usrString, int start, char key)
{
    int[] results = new int[2];
    results[0] = start;
    results[1] = -1;
    if (int.TryParse(usrString[start].ToString(), out _))
    {
        results[1] = usrString.IndexOf(usrString[start], start + 1);
    }
    return results;
}
static bool IsNoLetterBetweenDigits(int firstIndex, int lastIndex, string usrString)
{
    for (global::System.Int32 i = 0; i < lastIndex - firstIndex; i++)
    {
        if (!char.IsDigit(usrString[firstIndex + i])) return false;
    }
    return true;
}

static string RedStringNumberSeperated(int firstIndex, int lastIndex, string usrString)
{
    string result = usrString.Substring(firstIndex, lastIndex - firstIndex+1);
    return result;
}
static string[] GrayStringNumbersSeperated(int firstIndex, int lastIndex, string usrString)
{
    string[] results = new string[2];
    results[0] = usrString.Remove(firstIndex);
    results[1] = usrString.Remove(0, lastIndex+1);
    return results;
}

static void PrintResults(string usrString)
{
    List<ulong> coloredNumUlong = new List<ulong>();
    ulong sum = 0;
    int ColoredNumListIndex = 0;
    for (global::System.Int32 i = 0; i < usrString.Length; i++)
    {
        int[] firstAndLastIndexes = FindFirstAndLastCharIndexes(usrString, i, usrString[i]);
        if (firstAndLastIndexes[1] == -1) continue;
        else if (IsNoLetterBetweenDigits(firstAndLastIndexes[0], firstAndLastIndexes[1], usrString))
        {
            coloredNumUlong.Add(0);
            string redStringNumber = RedStringNumberSeperated(firstAndLastIndexes[0], firstAndLastIndexes[1], usrString);
            coloredNumUlong[ColoredNumListIndex] = ulong.Parse(redStringNumber);
            ColoredNumListIndex++;
            string[] grayNumbers = GrayStringNumbersSeperated(firstAndLastIndexes[0], firstAndLastIndexes[1], usrString);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(grayNumbers[0]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(redStringNumber);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(grayNumbers[1]);

        }
        else continue;
    }
    for (int i = 0; i < coloredNumUlong.Count; i++)
    {
        sum += coloredNumUlong[i];
    }
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Gray;
    if (sum == 0) Console.WriteLine("Woops inga nummer matchade kriterierna");
    else Console.WriteLine($"Totalsumma: {sum}");
}

Console.WriteLine("Skriv siffror och tecken, fast mest siffror: ");
string usrString = Console.ReadLine();
Console.WriteLine();

PrintResults(usrString);