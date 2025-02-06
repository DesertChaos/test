//o velikiy kod

/* Моя любимая часть работы - написание комментария
 * 
 * Предистория
 * Я хотел реализовать функции как в питоне:
 * если пользователь вводит неправильные данные, 
 * то можно просто заставить вводить его эти данные еще раз, 
 * пока не будет правильно. Лазая по просторам документации C#,
 * я нашел такую вещь как методы. Я до сих пор понятия не имею
 * как они работают, НО они работают и работают так как мне нужно.
 * 
 * Логика программы
 * В программе 3 метода
 * О каждом из них подробнее я пишу рядом с ними.
 * 
 * Возвращаясь к теме из предыдущей моей работы:
 * если гитхаб позволяет бесплатно мне размещать мои
 * (и многие чужие) проекты, то на какие деньги он это
 * вообще делает, и как оно работает? 
 * Ну, наверно не важно.
 */

namespace test2
{
    internal class Program
    {
        public static string? Name;      // Обе переменные задаются еще в основном методе при старте, но будут использоваться в последнем методе для вывода пользователю 
        public static string? Surname;   // Чтобы не мучаться с классами и не добавлять синтаксиса, который я не понимаю, это информация хранится здесь (но все равно в классе >:| )

        static void Main()
        {
            /* Первый основной метод.
             * Входная точка программы.
             * Выполняется всего один раз (что важно!!!).
             * Основная цель всех моих мучений - заставлять пользователя переписывать дату,
             * если он ее ввел неверно. Но, если количество дней в месяце (или количество месяцев, раз уж на то пошло)
             * можно забыть, то свое имя и фамилию пользователь должен помнить. В крайнем случае он может оставить эти поля пустыми,
             * на что указывает '?' после объявления переменной
             */
            Console.Title = "Определятор знаков зодиака 3000";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Определятор знаков зодиака 3000");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', 10)); // Для красоты

            Console.WriteLine("Введите имя");
            Console.ForegroundColor = ConsoleColor.Blue;
            Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите фамилию");
            Console.ForegroundColor = ConsoleColor.Blue;
            Surname = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            GetDate(); // Вызываем метод для получения конкретной даты с котороый мы работает. Main() больше не будет вызван.
        }

        static void GetDate()
        {
            /* Второй метод
             * Принимает от пользователя данные о дате
             * и проверяет их на наличие ошибок, которые могу привести к поломке программы
             * Это переполнение переменной, использование неправильного типа данных и др.
             * С этим помогает метод int.TryParse(). Он пытается преоброзовать переменную на входе 'a'
             * и если у него это получается - выводит ее в другую переменную 'b': 
             * int.TryParse(a, out b)
             * Основной результат выполнения - булеан:
             * если не получится преобразовать переменную, то программа сообщит об этом, и увеличит счетчик ошибок.
             * Чтобы не повторять 2 конструкции if - else, я инвертировал логику (если так вообще можно сказать) и
             * уменьшил необходимо количество строчек кода.
             * Наконец, если есть хотя бы одна ошибка преобразования, весь метод начинается сначала.
             * Если преобразование прошло успешно, мы двигаемся дальше.
             */

            Console.WriteLine(new string('-', 10)); // Для красоты (опять)

            Console.WriteLine("Введите номер дня (от 1 до 31)");
            Console.ForegroundColor = ConsoleColor.Blue;
            string DayRaw = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите номер месяця (от 1 до 12)");
            Console.ForegroundColor = ConsoleColor.Blue;
            string MonthRaw = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            int Day;               // В данном случае переменные необходимо объявить заранее
            int Month;             // т.к. они будут переданы в следующий метод
            int ParsingError = 0;  // (если конечно преобразование пройдет успешно)

            if (!int.TryParse(DayRaw, out Day))
            {
                ParsingError++; // Слава богу есть инкрементация 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: Указано недопустимое значение '{DayRaw}' для номера дня");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (!int.TryParse(MonthRaw, out Month))
            {
                ParsingError++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: Указано недопустимое значение '{MonthRaw}' для номера месяца");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (ParsingError == 0)
            {
                Calculation(Day, Month); // Переходим в следующий метод
            }
            else
            {
                GetDate(); // Перезапускаем этот метод
                return;
            }

        }

        static void Calculation(int Day, int Month)
        {
            /* Третий метод
             * Самый длинный и разнообразный
             * Делится на 2 части:
             * 
             * Сначала мы проверяем: а верно ли введены значения месяцев и дней.
             * В этот раз мы можем быть точно уверены что работаем с числами в пределах int32,
             * поэтому нет необходимости в лишних проверках.
             * Этот способ проверки (немного) украден из интернета,
             * т.к программа и так уже получилась слишком длинной и
             * писать один и тот же код 3 раз подряд слишком скучно.
             * DaysInMonth это массив индекс которого соответсвует номеру месяца (n - 1 конечно же),
             * а значение - максимально допустимое количество дней.
             * Если проверка не пройдена - мы швыряем пользователя в предыдущий метод.
             * 
             * Вторая часть - само определение знака зодиака.
             * Оно сделано достаточно просто через 24 (!) кейса.
             * Пусть оно выглядит не особо красиво м возможно не особо читаемо,
             * оно работает, и для меня этого достаточно.
             */
            int[] DaysInMonth = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // Массивчик

            if (Month < 1 || Month > 12)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Недопустимый номер месяца");
                Console.ForegroundColor = ConsoleColor.White;
                GetDate(); // Туда этого глупого пользователя
                return;
            }
            else if (Day < 1 || Day > DaysInMonth[Month - 1])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Недопустимый номер дня для этого месяца");
                Console.ForegroundColor = ConsoleColor.White;
                GetDate(); // Надо помнить сколько дней в каждом месяце
                return;
            }

            Console.WriteLine(new string('-', 10)); // Для красоты (опять)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ваше имя: " + Name);           // Наконец таки пригодились глобальные переменные с самого начала программы.
            Console.WriteLine($"Ваша фамилия: " + Surname);    // Только зачем пользователю напоминать его же данные - я так и не разобрался.

            switch (Month)
            {
                case 1 when Day <= 19:
                    Console.WriteLine("Ваш знак зодиака: Козерог");
                    break;
                case 1 when Day >= 20:
                    Console.WriteLine("Ваш знак зодиака: Водолей");//
                    break;
                case 2 when Day <= 18:
                    Console.WriteLine("Ваш знак зодиака: Водолей");//
                    break;
                case 2 when Day >= 19:
                    Console.WriteLine("Ваш знак зодиака: Рыбы");
                    break;
                case 3 when Day <= 20:
                    Console.WriteLine("Ваш знак зодиака: Рыбы");
                    break;
                case 3 when Day >= 21:
                    Console.WriteLine("Ваш знак зодиака: Овен");
                    break;
                case 4 when Day <= 19:
                    Console.WriteLine("Ваш знак зодиака: Овен");
                    break;
                case 4 when Day >= 20:
                    Console.WriteLine("Ваш знак зодиака: Телец");
                    break;
                case 5 when Day <= 20:
                    Console.WriteLine("Ваш знак зодиака: Телец");
                    break;
                case 5 when Day >= 21:
                    Console.WriteLine("Ваш знак зодиака: Близнецы");
                    break;
                case 6 when Day <= 20:
                    Console.WriteLine("Ваш знак зодиака: Близнецы");
                    break;
                case 6 when Day >= 21:
                    Console.WriteLine("Ваш знак зодиака: Рак");
                    break;
                case 7 when Day <= 22:
                    Console.WriteLine("Ваш знак зодиака: Рак");
                    break;
                case 7 when Day >= 23:
                    Console.WriteLine("Ваш знак зодиака: Лев");
                    break;
                case 8 when Day <= 22:
                    Console.WriteLine("Ваш знак зодиака: Лев");
                    break;
                case 8 when Day >= 23:
                    Console.WriteLine("Ваш знак зодиака: Дева");//
                    break;
                case 9 when Day <= 22:
                    Console.WriteLine("Ваш знак зодиака: Дева");//
                    break;
                case 9 when Day >= 23:
                    Console.WriteLine("Ваш знак зодиака: Весы");
                    break;
                case 10 when Day <= 22:
                    Console.WriteLine("Ваш знак зодиака: Весы");
                    break;
                case 10 when Day >= 23:
                    Console.WriteLine("Ваш знак зодиака: Скорпион");
                    break;
                case 11 when Day <= 21:
                    Console.WriteLine("Ваш знак зодиака: Скорпион");
                    break;
                case 11 when Day >= 22:
                    Console.WriteLine("Ваш знак зодиака: Стрелец");
                    break;
                case 12 when Day <= 21:
                    Console.WriteLine("Ваш знак зодиака: Стрелец");
                    break;
                case 12 when Day >= 22:
                    Console.WriteLine("Ваш знак зодиака: Козерог");
                    break;

                /* Наконец таки наступил конец этой программы.
                 * Я в сочинении ОГЭ по русскому написал меньше слов чем здесь
                 * (а я написал на максимальный балл вапщето).
                 * Я надеюсь что такое количество комментариев, предоставляющие подробный разбор моего хода мыслей, 
                 * работы программы и просто левые замечания доказывают, что эта программа написана мной, 
                 * а не нейронкой (фу!) за 5 секунд.
                 * Я если честно уже устал все это писать, поэтому я это прекращаю.
                 * 
                 * Наверно.
                 * 
                 * Почти закончил.
                 * 
                 * Мяу.
                 */
            }
        }
    }
}

// Я так и не понял как избавится от двух предупреждений в vs studio. Да, я понимаю что есть 2 места где "Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL." Но это не значит, что в меня надо этим тыкать. Почему нельзя просто убрать эти предупреждения. За что этот мир так жесток со мной. Я просто хотел сделать приколюху.