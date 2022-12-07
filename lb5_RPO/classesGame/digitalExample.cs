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
            Random rnd = new Random();
            int a = rnd.Next(Item2, Item1);
            do
            {
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
                    case 4:
                        {

                            allRandom(result, a);
                            break;
                        }
                }
                count++;
                value--;
            } while ((value - 1) == 0);
            return (int)result;
        }

        //функция для всех знаков
        public static int allRandom(int result, int a)
        {
            int count = 0;
            int lastStep = 0;
            Random rndAll = new Random();
            int y = rndAll.Next(1, 4);
            if (count == 1)
            {
                lastStep = y;
            }
            switch (lastStep)
            {
                case 1:
                    result += a;
                    break;
                case 2:
                    {
                        if (count == 1)
                        {
                            result = a;
                        }
                        else { result -= a; }

                        break;
                    }
                case 3:
                    {
                        if (count == 1)
                        {
                            result = a;
                        }
                        else { result *= a; }
                        break;
                    }
            }
            switch (y)
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
            lastStep = y;
            //valueRandom = lastStep;
            return result;
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
