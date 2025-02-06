using System;
using System.Collections.Immutable;

namespace LAB02 
{
    partial class LAB02
    {
        public class Car
        {
            private static int carCount = 0;
            private readonly int id;

            public string Vendor { get; private set; } 
            public string Model { get; private set; }  
            public int Year { get; private set; }      
            public string Color { get; private set; }  
            public int BasePrice { get; private set; } 
            public string RegNumber { get; private set; }

            public int DoubleRefOut(ref int a, out int b)
            {
                b = a * a;
                a = 2 * a;
                return a;
            }
            public Car CarPrivate()
            {
                return new Car("BMW", "X7");
            }
            static Car()
            {
                carCount = 0;
            }
            public Car()
            {
                Vendor = "Unknown";
                Model = "Unknown";
                Year = DateTime.Now.Year;
                Color = "Unset";
                BasePrice = 0;
                RegNumber = GenerateRegNumber();
                carCount++;
                id = GenerateUniqueId();
            }
            public Car(int iVendor, int iModel, int iYear, int iColor, int iBasePrice)
            {
                Vendor = GetVendor(iVendor);
                Model = GetModel(iVendor, iModel);
                Year = ValidateYear(iYear);
                Color = GetColor(iColor);
                BasePrice = iBasePrice;
                RegNumber = GenerateRegNumber();
                carCount++;
                id = GenerateUniqueId();
            }
            
            private Car(string vendor, string model)
            {
                Vendor = vendor;
                Model = model;
                Year = DateTime.Now.Year;
                Color = "Unset";
                BasePrice = 0;
                RegNumber = GenerateRegNumber();
                carCount++;
                id = GenerateUniqueId();
            }
            private string GetVendor(int vendorCode)
            {
                return vendorCode switch
                {
                    1 => "Porsche",
                    2 => "BMW",
                    3 => "Volkswagen",
                    4 => "Audi",
                    _ => "Error!"
                };
            }

            private string GetModel(int vendorCode, int modelCode)
            {
                return vendorCode switch
                {
                    1 => modelCode switch
                    {
                        1 => "911",
                        2 => "Cayenne",
                        3 => "992 Carrera",
                        _ => "Error!"
                    },
                    2 => modelCode switch
                    {
                        1 => "M5 Competition",
                        2 => "X7",
                        3 => "i8",
                        _ => "Error!"
                    },
                    3 => modelCode switch
                    {
                        1 => "Touareg",
                        2 => "Passat",
                        3 => "Golf",
                        _ => "Error!"
                    },
                    4 => modelCode switch
                    {
                        1 => "RS6",
                        2 => "A8",
                        3 => "Q8 E-tron",
                        _ => "Error!"
                    },
                    _ => "Error!"
                };
            }

            private int ValidateYear(int year)
            {
                return (year < 1980 || year > DateTime.Now.Year) ? 0 : year;
            }

            private string GetColor(int colorCode)
            {
                return colorCode switch
                {
                    1 => "Red",
                    2 => "Blue",
                    3 => "White",
                    4 => "Black",
                    _ => "Unset"
                };
            }

            private string GenerateRegNumber()
            {
                Random rnd = new Random();
                char[] letters = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
                char[] numbers = "1234567890".ToCharArray();
                string regNumber = "";

                for (int i = 0; i < 4; i++)
                {
                    regNumber += numbers[rnd.Next(numbers.Length)];
                }

                for (int i = 0; i < 2; i++)
                {
                    regNumber += letters[rnd.Next(letters.Length)];
                }

                return regNumber;
            }

            private int GenerateUniqueId()
            {
                return ++carCount;
            }

            public int GetAge()
            {
                return DateTime.Now.Year - Year;
            }

            public int CalculatePrice()
            {
                int age = GetAge();
                int depreciation = age * 2500; // Убыток за каждый год
                int currentPrice = Math.Max(BasePrice - depreciation, 0); // Не допускаем отрицательной цены
                return currentPrice;
            }

            public override bool Equals(object obj)
            {
                if (obj is Car car)
                {
                    return Vendor == car.Vendor && Model == car.Model && Year == car.Year;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Vendor, Model, Year);
            }

            public override string ToString()
            {
                return $"{Vendor} {Model}, {RegNumber}, {Year}, {Color}, {CalculatePrice()}$";
            }

            public static Car GenerateRandomCar(int vendorCode, int modelCode, Random rnd)
            {
                int year = GenerateRandomYear(vendorCode, modelCode, rnd); // Случайный год от 1 до 20 лет
                int colorCode = rnd.Next(1, 5); // Случайный цвет
                int basePrice = GetBasePrice(vendorCode, modelCode); // Базовая цена
                return new Car(vendorCode, modelCode, year, colorCode, basePrice);
            }

            private static int GenerateRandomYear(int vendorCode, int modelCode, Random rnd)
            {
                (int minAge, int maxAge) = (vendorCode, modelCode) switch
                {
                    (1, 1) => (3, 20),  // Porsche 911
                    (1, 2) => (5, 20),  // Porsche Cayenne
                    (1, 3) => (10, 20), // Porsche 992 Carrera
                    (2, 1) => (0, 3),   // BMW M5 Competition
                    (2, 2) => (0, 6),   // BMW X7
                    (2, 3) => (1, 4),   // BMW i8
                    (3, 1) => (0, 10),  // Volkswagen Touareg
                    (3, 2) => (10, 21), // Volkswagen Passat
                    (3, 3) => (15, 21), // Volkswagen Golf
                    (4, 1) => (0, 8),  // Audi RS6
                    (4, 2) => (0, 3),  // Audi A8
                    (4, 3) => (0, 1),  // Audi Q8 E-tron
                    _ => (0, 20)        // По умолчанию
                };

                // Генерация случайного возраста
                int randomAge = rnd.Next(minAge, maxAge);
                return DateTime.Now.Year - randomAge; // Возвращаем год на основе возраста
            }

            private static int GetBasePrice(int vendorCode, int modelCode)
            {
                // Определяем базовые цены в зависимости от модели
                return (vendorCode, modelCode) switch
                {
                    (1, 1) => 70000,  // Porsche 911
                    (1, 2) => 60000,  // Porsche Cayenne
                    (1, 3) => 80000,  // Porsche 992 Carrera
                    (2, 1) => 100000, // BMW M5 Competition
                    (2, 2) => 80000,  // BMW X7
                    (2, 3) => 150000, // BMW i8
                    (3, 1) => 80000,  // Volkswagen Touareg
                    (3, 2) => 70000,  // Volkswagen Passat
                    (3, 3) => 60000,  // Volkswagen Golf
                    (4, 1) => 100000, // Audi RS6
                    (4, 2) => 90000,  // Audi A8
                    (4, 3) => 120000, // Audi Q8 E-tron
                    _ => 30000 // Значение по умолчанию, если модель не найдена
                };
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int randomCarCount = rnd.Next(100, 200); // Случайное количество автомобилей от 5 до 20
            Car[] cars = new Car[randomCarCount];

            // Генерация случайных автомобилей
            for (int i = 0; i < cars.Length; i++)
            {
                int vendorCode = rnd.Next(1, 5); // Случайный производитель от 1 до 4
                int modelCode = rnd.Next(1, 4); // Случайная модель от 1 до 3
                cars[i] = Car.GenerateRandomCar(vendorCode, modelCode, rnd);
            }

            // Вывод актуального списка автомобилей
            Console.WriteLine("Актуальный список автомобилей:");
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

            // Ввод модели автомобиля от пользователя
            Console.WriteLine("Введите модель автомобиля:");
            string iModel = Console.ReadLine();

            // Ввод возраста от пользователя
            Console.WriteLine("Введите минимальный возраст автомобиля (в годах):");
            if (!int.TryParse(Console.ReadLine(), out int minAge))
            {
                Console.WriteLine("Некорректный ввод возраста.");
                return;
            }

            // Перебор массива и вывод автомобилей заданной модели, которые эксплуатируются больше n лет
            foreach (var car in cars)
            {
                if (car.ToString().Contains(iModel, StringComparison.OrdinalIgnoreCase) && car.GetAge() > minAge)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            int test1 = 2;
            int test2 = 0;
            int test3;

            test3 = cars[0].DoubleRefOut(ref test1, out test2);
            Console.WriteLine(test1.ToString(), "\t", test2);
            
        }
    }
}