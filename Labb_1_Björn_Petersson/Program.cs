// "29535123p48723487597645723645"
Console.WriteLine("Skriv siffror och tecken, fast mest siffror: ");
string usrString = Console.ReadLine();
Console.WriteLine();

static int[] FindCharIndex(string usrString, int start, char key)
{
    int[] result = new int[2];
    result[0] = start;
    result[1] = -1;
    if (int.TryParse(usrString[start].ToString(), out _))
    {
        for (global::System.Int32 i = start + 1; i < usrString.Length; i++)
        {
            if (key == usrString[i])
            {
                result[1] = i;
                break;
            }
        }        
    }
    return result;
}

static bool NoAlienCharInbetween(int firstIndex, int lastIndex, string usrString)
{
    for (global::System.Int32 i = 0; i < lastIndex - firstIndex; i++)
    {
        if (!int.TryParse(usrString[firstIndex + i].ToString(), out _)) return false;
    }
    return true;
}

static void PrintColoredNumberSequences(string usrString, List<string> coloredNumbers)
{
    int listIndex = 0;
    for (global::System.Int32 i = 0; i < usrString.Length; i++)
    {
        int[] index = FindCharIndex(usrString, i, usrString[i]);
        if (index[1] == -1) continue;
        if (index[1] - index[0] < 1) continue;
        else if (NoAlienCharInbetween(index[0], index[1], usrString))
        {
            coloredNumbers.Add(string.Empty);
            for (global::System.Int32 k = 0; k < usrString.Length; k++)
            {
                if (k < index[0] || k > index[1])
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(usrString[k]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(usrString[k]);
                    coloredNumbers[listIndex] += usrString[k];
                }
            }
            listIndex++;
            Console.WriteLine();
        }
        else continue;
    }
}

List<string> coloredNumbers = new List<string>();
List<ulong> coloredNumInt = new List<ulong>();
ulong sum = 0;

PrintColoredNumberSequences(usrString, coloredNumbers);

for (int i = 0; i < coloredNumbers.Count; i++)
{
    coloredNumInt.Add(ulong.Parse(coloredNumbers[i].ToString()));
    sum += coloredNumInt[i];
}
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Gray;
if (sum == 0) Console.WriteLine("Woops inga nummer matchade kriterierna");
else Console.WriteLine($"Totalsumma: {sum}");