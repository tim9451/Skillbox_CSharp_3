using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region УсловияЗадачи
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!
            #endregion

            Console.OutputEncoding = Encoding.UTF8;
            bool GameOn = true, gameSession = true, currentDiff = false;
            string player1, playerComputer, currentPlayer = "", Restart;
            int gameNumber, playerNumber, diffNubmer;
            int min = 0, max = 0;
            Random rndm = new Random();

            // пустим саму игру по циклу на случай, если захочется сыграть реванш
            while(GameOn)
            {
                Console.WriteLine("Введите имя Игрока 1: ");
                player1 = Console.ReadLine();                       
                Console.WriteLine("Введите имя Игрока Компьютера: ");
                playerComputer = Console.ReadLine();          
                
                // введем уровень сложности
                while(!currentDiff)
                {
                    Console.WriteLine("Введите уровень сложности от 1 до 3: ");
                    try
                    {
                        diffNubmer = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        diffNubmer = 0;
                    }
                    switch(diffNubmer)
                    {
                        case 1:
                            min = 10;
                            max = 40;
                            currentDiff = true;
                            break;
                        case 2:
                            min = 41;
                            max = 80;
                            currentDiff = true;
                            break;
                        case 3:
                            min = 81;
                            max = 120;
                            currentDiff = true;
                            break;
                        default:
                            Console.WriteLine("Введен не корректный уровень сложности, повторите попытку");
                            currentDiff = false;
                            break;
                    }

                }

                gameNumber = rndm.Next(min,max);
                
                // непосредственно игра
                while(gameSession)
                {
                    currentPlayer = (currentPlayer == player1) ? playerComputer:player1;
                    // ввод числа игроком пустим по циклу, чтобы контролировать
                    if (currentPlayer == player1)
                    while(true)
                    {
                        Console.WriteLine($"\nЧисло: {gameNumber}");
                        Console.Write($"Ход {currentPlayer}: ");
                        try
                        {
                            playerNumber = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            playerNumber = 0;
                        }
                        
                        if (playerNumber >= 1 && playerNumber <= 4)
                        break;

                        Console.WriteLine("Введенное число должно быть в диапазоне от 1 до 4! Повторите попытку");
                    }
                    else
                    {
                        playerNumber = rndm.Next(1,4);
                        Console.WriteLine($"\nЧисло: {gameNumber}");
                        Console.WriteLine($"Ход {currentPlayer}: {playerNumber}");
                    }

                    gameNumber = gameNumber - playerNumber;
                    gameSession = (gameNumber <= 0) ? false:true;
                }

                Console.WriteLine($"\nИгра окончена! Победил игрок {currentPlayer} \nДля повтора игры введите слово 'Реванш' и нажмите Enter");
                Restart = Console.ReadLine();
                GameOn = (Restart == "Реванш") ? true: false;
            }

        }
    }
}
