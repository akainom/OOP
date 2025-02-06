using System;
using System.Text;

namespace nmspc
{
    class Cls
    {
        static void Main(string[] args)
        {
            ////a)
            //Console.WriteLine("Enter the variables of each type");

            ////bool
            //bool bl;
            //Console.WriteLine("\nEnter either true or false");
            //bl = Convert.ToBoolean(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {bl}");

            ////byte
            //byte bt;
            //Console.WriteLine("\nEnter any number between 0 and 255");
            //bt = Convert.ToByte(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {bt}");

            ////sbyte
            //sbyte sbt;
            //Console.WriteLine("\nEnter any number between -128 and 127");
            //sbt = Convert.ToSByte(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {sbt}");

            ////char
            //char ch;
            //Console.WriteLine("\nEnter only 1 symbol");
            //ch = Convert.ToChar(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {ch}");

            ////decimal
            //decimal dc;
            //Console.WriteLine("\nEnter any decimal type number");
            //dc = Convert.ToDecimal(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {dc}");

            ////double
            //double db;
            //Console.WriteLine("\nEnter any decimal(double) number");
            //db = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {db}");

            ////float
            //float ft;
            //Console.WriteLine("\nEnter any floating point number");
            //ft = Convert.ToSingle(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {ft}");

            ////int
            //int integer;
            //Console.WriteLine("\nEnter any integer");
            //integer = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {integer}");

            ////uint
            //uint ui;
            //Console.WriteLine("\nEnter any unsigned integer");
            //ui = Convert.ToUInt32(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {ui}");

            ////nint
            //nint ni;
            //Console.WriteLine("\nEnter any integer");
            //int input = Convert.ToInt32(Console.ReadLine());
            //ni = (nint)input;
            //Console.WriteLine($"\nEntered value - {ni}");

            ////nuint
            //nuint nui;
            //Console.WriteLine("\nEnter any integer");
            //input = Convert.ToInt32(Console.ReadLine());
            //nui = (nuint)input;
            //Console.WriteLine($"\nEntered value - {nui}");

            ////long
            //long l;
            //Console.WriteLine("\nEnter any integer");
            //l = Convert.ToInt64(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {l}");

            ////ulong
            //ulong ul;
            //Console.WriteLine("\nEnter any integer");
            //ul = Convert.ToUInt64(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {ul}");

            ////short
            //short sh;
            //Console.WriteLine("\nEnter any integer");
            //sh = Convert.ToInt16(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {sh}");

            ////ushort
            //ushort ush;
            //Console.WriteLine("\nEnter any integer");
            //ush = Convert.ToUInt16(Console.ReadLine());
            //Console.WriteLine($"\nEntered value - {ush}");

            ////b)
            //// Явное приведение типов
            //double doubleValue = 9.78;
            //int intValue = (int)doubleValue; // double to int

            //long longNumber = 1234567890;
            //int longToInt = (int)longNumber; // long to int

            //float floatVal = 7.56f;
            //int floatToInt = (int)floatVal; // float to int

            //decimal decimalValue = 12.34m;
            //double decimalToDouble = (double)decimalValue; // decimal to double

            //object obj = 42;
            //int objToInt = (int)(int)obj; // object to int (unboxing)

            //// Неявное приведение типов
            //int intNumber = 10;
            //double doubleNumber = intNumber; // int to double

            //char character = 'A';
            //int charToInt = character; // char to int

            //float floatNumber = 20.5f;
            //double floatToDouble = floatNumber; // float to double

            //byte byteNumber = 100;
            //int byteToInt = byteNumber; // byte to int

            //short shortNumber = 3000;
            //int shortToInt = shortNumber; // short to int

            ////c)
            //intValue = 42;

            //// Boxing
            //object boxedValue = intValue;
            //Console.WriteLine($"Boxed value: {boxedValue}");

            //// Unboxing
            //int unboxedValue = (int)boxedValue;
            //Console.WriteLine($"Unboxed value: {unboxedValue}");

            ////d)
            //// Неявно типизированные переменные
            //var number = 10; // int
            //var text = "Hello, world!"; // string
            //var pi = 3.14; // double
            //var isActive = true; // bool
            //var numbers = new[] { 1, 2, 3 }; // int[]

            //// Вывод значений
            //Console.WriteLine($"Number: {number}");
            //Console.WriteLine($"Text: {text}");
            //Console.WriteLine($"Pi: {pi}");
            //Console.WriteLine($"Is Active: {isActive}");
            //Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");

            ////e)
            //int? nullableInt = null;

            //// Check if it has a value
            //if (nullableInt.HasValue)
            //{
            //    Console.WriteLine($"Value: {nullableInt.Value}");
            //}
            //else
            //{
            //    Console.WriteLine("The variable is null.");
            //}

            //// Assign a value
            //nullableInt = 42;

            //// Use the null-coalescing operator
            //int result = nullableInt ?? 0;
            //Console.WriteLine($"Result: {result}");

            ////f)
            //var value = 10; // Компилятор определяет тип как int
            //value = "Hello"; // Ошибка: Невозможно присвоить значение типа string переменной типа int


            //task5 : 
            static (int, int, int, char) localf(int[] array, string str)
            {   
                (int, int, int, char) retTuple = (array.Min(), array.Max(), array.Sum(), str[0]);
                return retTuple;
            }

            int[] testArray = { 1, 2, 3, };
            string testString = "Hello";

            var localTuple = localf(testArray, testString);
            Console.WriteLine("=============");
            Console.WriteLine("Input int array is [{0}], input string is \"{1}\", output tuple's min number is {2}, max number is {3}, sum is {4}, first letter of string is  {5}",
                string.Join(", ", testArray),
                testString,
                localTuple.Item1,
                localTuple.Item2,
                localTuple.Item3,
                localTuple.Item4);
            Task2();
        }
        static void Task2()
        {
            //a)
            // Объявление строковых литералов
            string str1 = "Hello";
            string str2 = "Hello";
            string str3 = "World";

            // Сравнение строк
            bool areEqual1 = str1 == str2; // true
            bool areEqual2 = str1 == str3; // false

            // Вывод результатов
            Console.WriteLine($"str1 == str2: {areEqual1}");
            Console.WriteLine($"str1 == str3: {areEqual2}");

            // Использование метода Equals
            bool areEqual3 = str1.Equals(str2); // true
            Console.WriteLine($"str1.Equals(str2): {areEqual3}");

            //b)
            // Создание строк
            str1 = "Hello";
            str2 = "World";
            str3 = "Aaabba";

            // Конкатенация строк
            string concatenated = string.Concat(str1, " ", str2, "!");
            Console.WriteLine($"Конкатенация: {concatenated}");

            // Копирование строки
            string copiedString = string.Copy(str3);
            Console.WriteLine($"Копирование: {copiedString}");

            // Выделение подстроки
            string substring = str3.Substring(1, 3);
            Console.WriteLine($"Подстрока: {substring}");

            // Разделение строки на слова
            string[] words = str3.Split(' ');
            Console.WriteLine("Слова:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            // Вставка подстроки в заданную позицию
            string insertedString = str1.Insert(5, ", inserted");
            Console.WriteLine($"Вставка: {insertedString}");

            // Удаление заданной подстроки
            string removedSubstring = str3.Remove(1, 3);
            Console.WriteLine($"Удаление подстроки: {removedSubstring}");

            // Интерполирование строк
            string interpolatedString = $"{str1}, {str2}! :: {substring}.";
            Console.WriteLine($"Интерполирование: {interpolatedString}");

            //c)
            // Создание пустой и null строки
            string emptyString = string.Empty;
            string? nullString = null;

            // Проверка с помощью string.IsNullOrEmpty
            Console.WriteLine($"Пустая строка: {string.IsNullOrEmpty(emptyString)}"); // True
            Console.WriteLine($"Null строка: {string.IsNullOrEmpty(nullString)}");   // True

            // Примеры использования пустой строки
            Console.WriteLine($"Длина пустой строки: {emptyString.Length}"); // 0

            // Конкатенация с пустой строкой
            string example1 = "Example" + emptyString;
            Console.WriteLine($"Конкатенация с пустой строкой: {example1}"); // Example

            // Примеры с null строкой
            try
            {
                // Попытка получить длину null строки вызывает исключение
                int length = nullString.Length;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null строка не имеет длины.");
            }

            // Конкатенация с null строкой
            string example2 = "Example" + nullString;
            Console.WriteLine($"Конкатенация с null строкой: {example2}"); // Examplenull

            //d)
            // Создание строки на основе StringBuilder
            StringBuilder sb = new StringBuilder("Hello, StringBuilder!");

            // Удаление определенных позиций (например, 7-18)
            sb.Remove(7, 12);
            Console.WriteLine($"После удаления: {sb}");

            // Добавление новых символов в начало
            sb.Insert(0, "Welcome! ");
            Console.WriteLine($"Добавление в начало: {sb}");

            // Добавление новых символов в конец
            sb.Append(" Have a nice day!");
            Console.WriteLine($"Добавление в конец: {sb}");
            Task3();
        }
        static unsafe void Task3()
        {
            //a)
            // Создание двумерного массива
            int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
                            };

            // Вывод массива на консоль в отформатированном виде
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            //b)
            // Создание одномерного массива строк
            string[] array = { "Element 1", "Element 2", "Element 3", "Element 4", "Element 5" };

            // Вывод содержимого массива и его длины
            Console.WriteLine("Содержимое массива:");
            foreach (string element in array)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Длина массива: {array.Length}");

            // Запрос позиции и нового значения от пользователя
            Console.WriteLine("Введите позицию элемента, который хотите изменить (0-4):");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое значение:");
            string newValue = Console.ReadLine();

            // Изменение элемента массива
            if (position >= 0 && position < array.Length)
            {
                array[position] = newValue;
            }
            else
            {
                Console.WriteLine("Неверная позиция!");
            }

            // Вывод обновленного массива
            Console.WriteLine("Обновленное содержимое массива:");
            foreach (string element in array)
            {
                Console.WriteLine(element);
            }

            //c)
            // Определение количества столбцов в каждой строке
            int[] columns = { 2, 3, 4 };
            double[][] jaggedArray = new double[3][];

            // Ввод значений с консоли
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new double[columns[i]];
                Console.WriteLine($"Введите {columns[i]} вещественных чисел для строки {i + 1}:");
                for (int j = 0; j < columns[i]; j++)
                {
                    jaggedArray[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            // Вывод ступенчатого массива
            Console.WriteLine("Ступенчатый массив:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }


            //d)
            var numbers = new[] { 1, 2, 3 };
            var message = "string";

            task4();
        }
        static void task4()
        {
            //a)
            (int, string, char, string, ulong) tuple = (1, "string", 'c', "string2", 32434213213412UL);

            //b)
            Console.WriteLine($"Весь кортеж: {tuple}");
            Console.WriteLine($"Выборочные элементы: {tuple.Item1}, {tuple.Item3}, {tuple.Item4}");

            //c)
            (int number, string firstString, char character, string secondString, ulong bigNumber) = tuple;
            Console.WriteLine($"Распакованные переменные: {number}, {firstString}, {character}, {secondString}, {bigNumber}");
            (_, string str, _, string str2, _) = tuple;
            Console.WriteLine($"Использование переменной (_): {str}, {str2}");

            //d)
            var anotherTuple = (1, "string", 'c', "string2", 32434213213412UL);
            Console.WriteLine($"Кортежи равны: {tuple == anotherTuple}");

            task6();
            
        }
        static void task6()
        {
            CheckedFunction();
            UncheckedFunction();
            static void CheckedFunction()
            {
                try
                {
                    checked
                    {
                        int maxInt = int.MaxValue;
                        Console.WriteLine($"Checked: {maxInt}");
                        maxInt++; // causes OverflowException
                        Console.WriteLine($"After increment: {maxInt}");
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Checked: Overflow occurred!");
                }
            }

            static void UncheckedFunction()
            {
                unchecked
                {
                    int maxInt = int.MaxValue;
                    Console.WriteLine($"Unchecked: {maxInt}");
                    maxInt++; // without exception
                    Console.WriteLine($"After increment: {maxInt}");
                }
            }
        }
        }
}