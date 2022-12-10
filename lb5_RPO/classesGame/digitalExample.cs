using System;
namespace lb5_RPO.classesGame
{
    class digitalExample
    {

        //генерация примера
        public static void game(digitsMath digitsMath, difficultyGame difG, hpGame hp, mathOperation mathO)
        {
            int expGame = 0;
            Random rnd = new Random();
            var rangeDM = rangeDigitsMath(digitsMath);
            var difGM = difGameMath(difG);
            while (hp != 0)
            {

                int value = rnd.Next(difGM.Item2, difGM.Item1);
               // Console.WriteLine($"value = {value}");
                int qw = 0;
                int count = 1;



                qw = mathFunc(mathO, count, value, rangeDM.Item2, rangeDM.Item1);
                
                switch ((int)mathO)
                {
                    case 1: qw += lastStep(mathO, rangeDM.Item2, rangeDM.Item1); break;
                    case 2: qw -= lastStep(mathO, rangeDM.Item2, rangeDM.Item1); break;
                    case 3: qw *= lastStep(mathO, rangeDM.Item2, rangeDM.Item1); break;
                }


                bool exit = proverka(qw);

                if (exit == true)
                {
                    expGame += difGM.Item3;
                }
                else
                {
                    hp--;
                }
                count = 1;
            }
            if (hp == 0)
            {
                Console.WriteLine($"Ваш опыт: {expGame}");
            }

        }

        //проверка результата
        public static bool proverka(int result)
        {
            bool testPro = false;
            Console.WriteLine("Введите ваш результат: ");
            int inRes = Convert.ToInt32(Console.ReadLine());
            if (inRes == result)
            {
                Console.WriteLine("Верно");
                testPro = true;
            }
            else
            {
                Console.WriteLine("Неверно");
                Console.WriteLine($"Правильный: {result}");

            }
            return testPro;
        }

        //последнйи шаг
        public static int lastStep(mathOperation mathO, int Item2, int Item1)
        {
            int result = 0;
            Random rnd = new Random();
            int a = rnd.Next(Item2, Item1);
            Console.WriteLine(a);
            switch ((int)mathO)
            {
                case 1: result += a; break;
                case 2: result -= a; break;
                case 3: result *= a; break;
            }
            return result;
        }

        //вычисление результата, кроме последнего шага
        public static int mathFunc(mathOperation mathO, int count, int value, int Item2, int Item1)
        {
            int result = 0;
            if ((int)mathO != 4)
            {
                for (int q = value; q >= 1; q--)
                {
                    Random rnd = new Random();
                    int a = rnd.Next(Item2, Item1);
                    switch ((int)mathO)
                    {
                        case 1:
                            {
                                Console.Write(a + " + ");
                                result += a;
                                break;
                            }
                        case 2:
                            {
                                Console.Write(a + " - ");
                                if (count == 1)
                                {
                                    result = a;
                                }
                                else { result -= a; }

                                break;
                            }
                        case 3:
                            {
                                Console.Write(a + " * ");
                                if (count == 1)
                                {
                                    result = a;
                                }
                                else { result = result * a; }
                                break;
                            }
                    }
                }
            }
            else if ((int)mathO == 4)
            {
                result = allRandom(Item2, Item1, value);
            }
            return (int)result;
        }




        //функция для всех знаков
        public static int allRandom(int Item2, int Item1, int value)
        {
            int result = 0;
            
            int q = value + 1;
            List<int> masA = new List<int>();

            for (int i = 0;i<q;i++)
            {
                Random rnd = new Random();
                int a = rnd.Next(Item2, Item1);
                masA.Add(a);
               // Console.WriteLine($"masA[{i + 1}] = {masA[i]}");
            }
            List<int> mas = new List<int>();

            List<string> mathMas = new List<string>();
            for(int w = 0;w<value;w++)
            {

                Random rndAll = new Random();
                int y = rndAll.Next(1, 4);
                

                switch(y)
                {
                    case 1: mathMas.Add("+"); break;
                    case 2: mathMas.Add("-"); break;
                    case 3: mathMas.Add("*"); break;
                }
            }

           
            string popo = "";

            for (int i = 0; i < masA.Count - 1; i++)
            {
                popo += masA[i] + mathMas[i];
            }
            popo += masA[masA.Count - 1];

            Console.WriteLine(popo);
            result = ParseExpression(popo);
            return result;
        }


        private static readonly char[] supportedOperators = "*+-".ToCharArray(); // знаки для примера 
        private static readonly char[] allDigits = "0123456789".ToCharArray(); // цифры для примера 
        private static readonly int[] priorities = new[] { 0,  1, 1 }; // приоритет действий

        private static int ParseExpression(string expString)
        {
            expString = expString.Replace(" ", "");
            //разделение чисел и знаков в листы
            List<char> ops = expString.Split(allDigits, StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]).ToList();
            List<int> numbers = expString.Split(supportedOperators, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();

            if (ops.Count + 1 != numbers.Count)
                throw new FormatException("Некорректное математическое выражение");


            foreach (int priority in priorities.Distinct())
            {
                List<char> operators = new List<char>();
                for (int i = 0; i < priorities.Length; i++)
                {
                    if (priorities[i] == priority)
                        operators.Add(supportedOperators[i]);
                }
                for (int i = 0; i < ops.Count; i++)
                {
                    if (operators.Contains(ops[i]))
                    {
                        numbers[i] = Calculate(numbers[i], numbers[i + 1], ops[i]);
                        numbers.RemoveAt(i + 1);
                        ops.RemoveAt(i);
                        i--;
                    }
                }

            }
            return numbers[0];
        }

        private static int Calculate(int left, int right, char op) => op switch
        {
            '*' => left * right,
            '+' => left + right,
            '-' => left - right,
            _ => throw new NotSupportedException("Неподдерживаемый оператор")
        };


        public static void printRandom(int count, int a, int operat)
        {
            switch (operat)
            {
                case 1:
                    Console.Write(a + " + ");
                    break;
                case 2:
                    {
                        Console.Write(a + " - ");
                        break;
                    }
                case 3:
                    {
                        Console.Write(a + " * ");
                        break;
                    }
            }
        }




        // выбор количества символов в числе
        public static (int, int) rangeDigitsMath(digitsMath digitsM)
        {
            int max = 0;
            int min = 0;
            switch ((int)digitsM)
            {
                case 1: min = 1; max = 10; break;
                case 2: min = 10; max = 100; break;
                case 3: min = 100; max = 1000; break;
            }

            return (max, min);
        }

        //выбор количества знаков в примере
        public static (int, int, int) difGameMath(difficultyGame difG)
        {
            int max = 0; int min = 0; int ex = 0;
            switch ((int)difG)
            {
                case 1: max = 4; min = 2; ex = 100; break;
                case 2: max = 7; min = 5; ex = 200; break;
                case 3: max = 12; min = 8; ex = 500; break;
            }
            return (max, min, ex);
        }


    }
}
