using System;

namespace Arrays
{
    class Program
    {
        private const string UsageInfo = "info";
        private const string UsageInit = "init <length>";
        private const string UsageSet = "set <index> <value>";
        private const string UsageGet = "get <index>";
        private const string UsageExit = "exit";
        
        private static int[] _arr;

        private static void Main(string[] args)
        {
            Console.WriteLine("Please type in a command:");
            PrintUsages();

            while (true)
            {
                string line = Console.ReadLine();
                ProcessCommand(line);
            }
        }

        private static void PrintUsages()
        {
            Console.WriteLine(UsageInfo);
            Console.WriteLine(UsageInit);
            Console.WriteLine(UsageSet);
            Console.WriteLine(UsageGet);
            Console.WriteLine(UsageExit);
            Console.WriteLine();
        }

        private static void ProcessCommand(string command)
        {
            string[] args = command.Split(" ");

            if (string.Equals(args[0], "info", StringComparison.OrdinalIgnoreCase)) //usage: info
            {
                PrintArray();
            }
            else if (string.Equals(args[0], "init", StringComparison.OrdinalIgnoreCase)) //usage: init <length>
            {
                if (CheckLength(2, args.Length, UsageInit))
                {
                    InitArray(int.Parse(args[1]));
                }
            }
            else if (string.Equals(args[0], "set", StringComparison.OrdinalIgnoreCase)) //usage: set <index> <value>
            {
                if (CheckLength(3, args.Length, UsageSet))
                {
                    Set(int.Parse(args[1]), int.Parse(args[2]));
                }
            }
            else if (string.Equals(args[0], "get", StringComparison.OrdinalIgnoreCase)) //usage: get <index>
            {
                if (CheckLength(2, args.Length, UsageSet))
                {
                    Get(int.Parse(args[1]));
                }
            }
            else if (string.Equals(args[0], "exit", StringComparison.OrdinalIgnoreCase)) //usage: exit
            {
                Exit();
            }
            else
            {
                Console.WriteLine($"Command {command} not found!");
                PrintUsages();
            }
        }

        private static bool CheckLength(int requiredLength, int length, string usageToPrint)
        {
            if (requiredLength == length) return true;
            Console.WriteLine(usageToPrint);
            return false;
        }

        private static void InitArray(int length)
        {
            _arr = new int[length];
            Console.WriteLine($"The array has been initialized with a length of {length}!");
        }

        private static void PrintArray()
        {
            if (_arr != null)
            {
                Console.WriteLine($"Array lenght: {_arr.Length}");
                for (var i = 0; i < _arr.Length; i++)
                {
                    Console.WriteLine($"Array[{i}] = {_arr[i]}");
                }
            }
            else
            {
                Console.WriteLine("The array is not initialized!");
            }
        }

        private static void Set(int index, int value)
        {
            if (_arr == null)
            {
                Console.WriteLine("The array is not initialized!");
                return;
            }

            if (_arr.Length <= index)
            {
                Console.WriteLine(
                    $"Index was outside the bounds of the array! Array length: {_arr.Length}, index: {index}");
                return;
            }

            _arr[index] = value;
            Console.WriteLine($"The {index}. index was set to {value}");
        }

        private static void Get(int index)
        {
            if (_arr == null)
            {
                Console.WriteLine("The array is not initialized!");
                return;
            }

            if (_arr.Length <= index)
            {
                Console.WriteLine(
                    $"Index was outside the bounds of the array! Array length: {_arr.Length}, index: {index}");
                return;
            }

            Console.WriteLine($"The {index}. index is currently set to {_arr[index]}");
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}