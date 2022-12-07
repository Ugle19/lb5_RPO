using System;
namespace lb5_RPO.classesGame
{
    public class inputData
    {
        public static (difficultyGame, mathOperation, digitsMath, hpGame) inData()
        {
            difficultyGame dg = new difficultyGame();
            mathOperation mathO = new mathOperation();
            digitsMath digitsM = new digitsMath();
            hpGame hpG = new hpGame();
            bool exitInData = false;

            do
            {
                //ввод данных для игры 
                dg = dgChoose();
                mathO = moChoose();
                digitsM = dmChoose();
                hpG = hpChoose();

                if ((int)dg != 0 && (int)mathO != 0 && (int)digitsM != 0 && (int)hpG != 0)
                {
                    exitInData = true;
                }
                else
                {
                    Console.WriteLine("Вы что-то неправильно ввели. Попробуйте снова");
                }
            } while (exitInData != true);

            //показ игроку, что он выбрал 
            showChoose(dg, mathO, digitsM, hpG);

            return (dg, mathO, digitsM, hpG);
        }

        //показ выбора игрока
        public static void showChoose(difficultyGame dg, mathOperation mathO, digitsMath digitsM, hpGame hpG)
        {
            Console.Write($"\n Сложность: {dg}" +
                $"\n Тип примера: {mathO}" +
                $"\n Кол-во символов: {digitsM}" +
                $"\n Кол-во жизней: {hpG}\n");
        }


        //выбор сложности 
        public static difficultyGame dgChoose()
        {
            difficultyGame dg = new difficultyGame();
            Console.Write("Выберите уровень сложности(1 - легкий, 2 - средний, 3 - сложный): ");
            int typeDG = Convert.ToInt32(Console.ReadLine());
            switch (typeDG)
            {
                case 1: dg = difficultyGame.Easy; break;
                case 2: dg = difficultyGame.Normal; break;
                case 3: dg = difficultyGame.Hard; break;
                default: dg = difficultyGame.Error; break;
            }
            return dg;
        }

        //выбор операции
        public static mathOperation moChoose()
        {
            mathOperation mathO = new mathOperation();
            Console.Write("Выберите типа примера(1 - сложение, 2 - вычитание, 3- умножение, 4 - все сразу): ");

            int typeMathem = Convert.ToInt32(Console.ReadLine());
            switch (typeMathem)
            {
                case 1: mathO = mathOperation.Plus; break;
                case 2: mathO = mathOperation.Minus; break;
                case 3: mathO = mathOperation.MulpiPlus; break;
                case 4: mathO = mathOperation.All; break;
                default: mathO = mathOperation.Error; break;
            }
            return mathO;
        }

        //выбор кол-ва символов
        public static digitsMath dmChoose()
        {
            digitsMath digitsM = new digitsMath();
            Console.Write("Выберите количество символов(от 1 до 3): ");

            int typeDigits = Convert.ToInt32(Console.ReadLine());
            switch (typeDigits)
            {
                case 1: digitsM = digitsMath.oneDigits; break;
                case 2: digitsM = digitsMath.twoDigits; break;
                case 3: digitsM = digitsMath.threeDigits; break;
                default: digitsM = digitsMath.Error; break;
            }
            return digitsM;
        }

        //выбор кол-ва чисел
        public static hpGame hpChoose()
        {
            hpGame hpG = new hpGame();
            Console.Write("Выберите количество жизней(от 1 до 5): ");
            int typeHp = Convert.ToInt32(Console.ReadLine());
            switch (typeHp)
            {
                case 1: hpG = hpGame.One; break;
                case 2: hpG = hpGame.Two; break;
                case 3: hpG = hpGame.Three; break;
                case 4: hpG = hpGame.Four; break;
                case 5: hpG = hpGame.Five; break;
                default: hpG = hpGame.Error; break;
            }
            return hpG;
        }

    }
}
