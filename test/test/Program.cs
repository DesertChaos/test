namespace MyApp
{
    internal class Program
    {
        private static string _name;
        private static string _surname;
        private static string _lastname;
        static void Main(string[] args)
        {
            Console.WriteLine("Определятор знаков зодиака 3000");
            GetInfo();
        }

        static void GetInfo()
        {
            Console.WriteLine("Введите имя");
            _name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            _surname = Console.ReadLine();
            Console.WriteLine("Введите отчество");
            _lastname = Console.ReadLine();

            GetDate();
        }

        static void GetDate()
        {
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Введите день");
            int Day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите месяц");
            int Month = Convert.ToInt32(Console.ReadLine());
            
            ConvertDate(Day, Month);
        }

        static void ConvertDate(int Day, int Month)
        {
            if (Day <= 0)
            {
                Console.WriteLine(new string('!', 3) + " Ошибка");
                Console.WriteLine("Неверно указана дата.");
                GetDate();
            }
            else
            {
                int totalDays = 0;
                switch (Month)
                {
                    case 1:
                        totalDays = Day;
                        break;
                    case 2:
                        totalDays = 31 + Day;
                        break;
                    case 3:
                        totalDays = 59 + Day;
                        break;
                    case 4:
                        totalDays = 90 + Day;
                        break;
                    case 5:
                        totalDays = 120 + Day;
                        break;
                    case 6:
                        totalDays = 151 + Day;
                        break;
                    case 7:
                        totalDays = 181 + Day;
                        break;
                    case 8:
                        totalDays = 212 + Day;
                        break;
                    case 9:
                        totalDays = 243 + Day;
                        break;
                    case 10:
                        totalDays = 273 + Day;
                        break;
                    case 11:
                        totalDays = 304 + Day;
                        break;
                    case 12:
                        totalDays = 334 + Day;
                        break;
                    default:
                        Console.WriteLine(new string('!', 3) + " Ошибка");
                        Console.WriteLine("Неверно указан месяц.");
                        GetDate();
                        return;
                }

                if (totalDays > 365) 
                {
                    Console.WriteLine(new string('!', 3) + " Ошибка");
                    Console.WriteLine("Неверно указана дата. Количество дней превысило 365");
                    GetDate();
                }
                else if ((Month == 1 |
                          Month == 3 |
                          Month == 5 |
                          Month == 7 |
                          Month == 8 |
                          Month == 10 |
                          Month == 12) && Day > 31)
                {
                    Console.WriteLine(new string('!', 3) + " Ошибка");
                    Console.WriteLine("Неверно указана дата: Слишком большой день для этого месяца.");
                    GetDate();
                }
                else if ((Month == 4 |
                          Month == 6 |
                          Month == 9 |
                          Month == 11) && Day > 30)
                {
                    Console.WriteLine(new string('!', 3) + " Ошибка");
                    Console.WriteLine("Неверно указана дата: Слишком большой день для этого месяца.");
                    GetDate();
                }
                else if (Month == 2 && Day > 29)
                {
                    Console.WriteLine(new string('!', 3) + " Ошибка");
                    Console.WriteLine("Неверно указана дата: Слишком большой день для этого месяца.");
                    GetDate();
                    return;
                }
                else
                {
                    Solution(Day, Month);
                }
            }
            static void Solution(int Day, int Month)
            {
                Console.WriteLine(new string('>', 5) + "Программа завершила работу");
                Console.WriteLine($"ФИО: {_surname} {_name} {_lastname}");
                if ((Month == 3 && (Day >= 21 && Day <= 31)) | (Month == 4 && Day <= 19))
                {
                    Console.WriteLine("Ваш знак задиака Овен");
                }
                else if ((Month == 4 && (Day >= 20 && Day <= 30)) | (Month == 5 && Day <= 20))
                {
                    Console.WriteLine("Ваш знак задиака Телец");
                }
                else if ((Month == 5 && (Day >= 21 && Day <= 31)) | (Month == 6 && Day <= 20))
                {
                    Console.WriteLine("Ваш знак задиака Близнецы");
                }
                else if ((Month == 6 && (Day >= 21 && Day <= 30)) | (Month == 7 && Day <= 22))
                {
                    Console.WriteLine("Ваш знак задиака Рак");
                }
                else if ((Month == 7 && (Day >= 23 && Day <= 31)) | (Month == 8 && Day <= 22))
                {
                    Console.WriteLine("Ваш знак задиака Лев");
                }
                else if ((Month == 8 && (Day >= 23 && Day <= 31)) | (Month == 9 && Day <= 22))
                {
                    Console.WriteLine("Ваш знак задиака Дева");
                }
                else if ((Month == 9 && (Day >= 23 && Day <= 30)) | (Month == 10 && Day <= 22))
                {
                    Console.WriteLine("Ваш знак задиака Весы");
                }
                else if ((Month == 10 && (Day >= 23 && Day <= 31)) | (Month == 11 && Day <= 21))
                {
                    Console.WriteLine("Ваш знак задиака Скорпион");
                }
                else if ((Month == 11 && (Day >= 22 && Day <= 30)) | (Month == 12 && Day <= 21))
                {
                    Console.WriteLine("Ваш знак задиака Стрелец");
                }
                else if ((Month == 12 && (Day >= 22 && Day <= 31)) | (Month == 1 && Day <= 19))
                {
                    Console.WriteLine("Ваш знак задиака Козерог");
                }
                else if ((Month == 1 && (Day >= 20 && Day <= 31)) | (Month == 2 && Day <= 18))
                {
                    Console.WriteLine("Ваш знак задиака Водолей");
                }
                else if ((Month == 2 && (Day >= 19 && Day <= 28)) | (Month == 3 && Day <= 20))
                {
                    Console.WriteLine("Ваш знак задиака Рыбы");
                }
            }

        }
    }
}