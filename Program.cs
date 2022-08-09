/*
Написать программу, которая из имеющегося массива строк формирует массив из строк, 
длина которых меньше либо равна 3 символа. 
Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

Примеры:

["hello", "2", "world", ":-)"] -> ["2", ":-)"]
["1234", "1567", "-2", "computer science"] -> ["-2"]
["Russia", "Denmark", "Kazan"] -> []
*/
string GenerateWord(int lengthArray)//Генерируем слово произвольной длины
{
    Random rnd = new Random();
    char[] wordOfArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                           'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                           's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1',
                           '2', '3', '4', '5', '6', '7', '8', '9', '0',
                           '[', ']', '{', '}', ';', ':', '\'', '\"', '<',
                           '>', ',', '.', '/', '\\', '!', '@', '#', '$',
                           '%', '^', '&', '*', '(', ')', '-', '+', '=',
                           '?', '~', '`'};//массив символов, можно добавлять
    string result = string.Empty;
    int element = 0;
    int lengthOfWord = wordOfArray.Length;
    for (var i = 0; i < lengthArray; i++)
    {
        element = rnd.Next(1, lengthOfWord - 1); // генерируем индекс символа 
        result = result + wordOfArray[element];//добавляем символ в итоговое слово
    }
    return result;
}

string[] GenerateArray(int length, int maxWordLength = 10, int minWordLength = 1)//Генерируем массив произвольной длины из произвольных слов
{
    string[] result = new string[length];
    int wordLength = 0;
    for (int i = 0; i < length; i++)
    {
        wordLength = new Random().Next(minWordLength, maxWordLength);
        result[i] = GenerateWord(wordLength);//генерируем очередное слово
    }
    return result;
}

void printColor(string message, ConsoleColor color = ConsoleColor.Green)//смена цвета и печать слова
{
    Console.ForegroundColor = color;
    Console.Write($"{message}");
    Console.ResetColor();
}

void printArray(string[] arrayToPrint)//функция печати массива
{
    int length = arrayToPrint.Length;
    printColor("[", ConsoleColor.DarkYellow);
    for (int i = 0; i < length - 1; i++)
    {
        printColor("\"", ConsoleColor.DarkBlue);
        printColor($"{arrayToPrint[i]}", ConsoleColor.Green);
        printColor("\"", ConsoleColor.DarkBlue);
        printColor(", ", ConsoleColor.DarkYellow);
    }
    printColor("\"", ConsoleColor.DarkBlue);
    printColor($"{arrayToPrint[length - 1]}", ConsoleColor.Green);
    printColor("\"", ConsoleColor.DarkBlue);
    printColor("]", ConsoleColor.DarkYellow);
}

string[] ResultArray(string[] arrayOfWorld, int minChar = 3)//формируем массив, можно указать минимально количество длины слова
{
    int length = arrayOfWorld.Length;
    int indexResult = 0;
    int count = 0;
    for (var i = 0; i < length; i++)
    {
        if (arrayOfWorld[i].Length <= minChar)
        {
            count++;
        }
    }
    if (count <= 0) //если таких слов нет, вернем пустой массив
    {
        string[] resulterror = new string[1];
        resulterror[0] = "[]";
        return resulterror;
    }
    string[] result = new string[count];
    for (var i = 0; i < length; i++)
    {
        if (arrayOfWorld[i].Length <= minChar)
        {
            result[indexResult] = arrayOfWorld[i];
            indexResult++;
        }
    }
    return result;
}

void main()
{
    Console.Clear();
    Console.Write("Введите максимальный размер слова: ");
    int maxWordLength = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество элементов массива: ");
    int lengthArray = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите длину слова: ");
    int minChar = Convert.ToInt32(Console.ReadLine());
    if (minChar < 1)
    {
        Console.WriteLine("Длина слова не может быть меньше 1");
        return;
    }
    string[] arrayOfWorld = GenerateArray(lengthArray, maxWordLength, 1);
    string[] resultArray = ResultArray(arrayOfWorld, minChar);
    Console.WriteLine();
    printArray(arrayOfWorld);
    printColor(" -> ", ConsoleColor.DarkBlue);
    if (resultArray[0] != "[]")
    {
        printArray(resultArray);
    }
    else
    {
        printColor(" [] ", ConsoleColor.DarkYellow);
    }
    Console.WriteLine();
}

main();









