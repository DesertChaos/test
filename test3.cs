namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Попробуйте угадать число от 1 до 100");
            
            Random rnd = new Random();
            int goal = rnd.Next(1, 101);
            Console.WriteLine($"По секрету, это число - {goal}");
            int counter = 0; //счетчик попыток пользователя

            start:  //оказывается можно ставить метки просто так. приколь конечно
                Console.WriteLine("Введите число");
                int answer = Convert.ToInt32(Console.ReadLine());
                counter++;

            switch (answer)
            {
                case int n when n == goal && counter < 5:
                    Console.WriteLine("Верно");
                    break;

                case int x when x != goal && counter > 4:
                    Console.WriteLine("Попытки закончились");
                    break;

                default:
                    Console.WriteLine("Неверно");                   
                    goto start;
            }
        }
    }
}
