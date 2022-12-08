using System;
using lb5_RPO.classesGame;

namespace lb5_RPO
{
    internal class Program
    {
        //Created by Ugle
        //lb5_RPO

        static void Main(string[] args)
        {
            bool chooseOne = true;
            bool goodBye = false;
            do
            {

                var fullData = inputData.inData();
                var lastFD = fullData;
                //вызов игры
                if (chooseOne == true)
                {
                    digitalExample.game(fullData.Item3, fullData.Item1, fullData.Item4, fullData.Item2);
                }

                //новая игра или выход 
                Console.Write("\nЕсли хотите закончить напишите - 0 " +
                    "\n начать заново с новыми настройками - 1," +
                    "\n а если хотите продолжить с такиме же настройками любую другую цирфу: ");
                int exitGame = 100;
                exitGame = Convert.ToInt32(Console.ReadLine());
                if (exitGame == 0)
                {
                    chooseOne = false;
                    goodBye = true;
                }
                else if (exitGame == 1)
                {
                    chooseOne = true;
                }
                else if (exitGame != 0 || exitGame != 1)
                {
                    chooseOne = false;
                }
            } while (goodBye != true);

            List<int> v = new List<int> { 1, 2, 3, 4,5,6,7,8,9,0 };

            

            Console.Write("\n\nСпасибо, что поиграли в мою игру<3... ");
            Console.ReadKey();
        }
    }
}
