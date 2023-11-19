using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domino
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();

            int[,] dominos = new int[28, 2];

            // Заполнение массива костяшками домино
            int index = 0;
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    dominos[index, 0] = i;
                    dominos[index, 1] = j;
                    index++;
                }
            }

            for (int i = 0; i < dominos.GetLength(0); i++)
            {
                int randomIndex = random.Next(i, dominos.GetLength(0));
                int temp1 = dominos[i, 0];
                int temp2 = dominos[i, 1];
                dominos[i, 0] = dominos[randomIndex, 0];
                dominos[i, 1] = dominos[randomIndex, 1];
                dominos[randomIndex, 0] = temp1;
                dominos[randomIndex, 1] = temp2;
            }


            // Раздаем кости игрокам
            List<int[,]> player1Hand = new List<int[,]>();
            List<int[,]> player2Hand = new List<int[,]>();

            for (int i = 0; i < 7; i++)
            {
                player1Hand.Add(new int[,] { { dominos[i, 0], dominos[i, 1] } });
                player2Hand.Add(new int[,] { { dominos[i+7, 0], dominos[i+7, 1] } });
            }

            Console.WriteLine("Костяшки игрока 1:");

            // Вывод костяшек в кортежах
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"|{player1Hand[i][0, 0]} | {player1Hand[i][0, 1]}|");
            }

            Console.WriteLine("Костяшки игрока 2:");

            // Вывод костяшек в кортежах
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"|{player2Hand[i][0, 0]} | {player2Hand[i][0, 1]}|");
            }


            Console.ReadLine();
        }
    }
}
