using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace tic_tac_toe
{
    class Program
    {
        public static string[,] TheTableArray = new string[9, 11];
        public static string existingNumbers = "";
        public static bool final = false;

        public static void TableCreation()
        {
            #region Description
            //Создадим массив, чтобы цифры можно было редактировать обращаясь к элементу массива ( массив со значениями string)
            //заполним массив циклом
            /*
            ***|***|*** row0
            *1*|*2*|*3* row1
            ---|---|--- row2
            ***|***|*** row3
            *4*|*5*|*6* row4
            ---|---|--- row5
            ***|***|*** row6
            *7*|*8*|*9* row7
            ***|***|*** row8
            */
            #endregion

            #region Заполнение массива
            //Вынесла массив в общий доступ, т.к. разные методы должны к нему обращаться
            //string[,] TheTableArray = new string[9, 11];
            int number = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (j == 3 || j == 7)
                    {
                        TheTableArray[i, j] = "|";
                    }
                    else
                    {
                        if (i == 2 || i == 5)
                        {
                            TheTableArray[i, j] = "_";
                        }
                        else
                        {
                            if ((i == 1 || i == 4 || i == 7) && (j == 1 || j == 5 || j == 9))
                            {
                                TheTableArray[i, j] = Convert.ToString(number);
                                number++;
                            }
                            else
                                TheTableArray[i, j] = " ";
                        }
                    }
                }
            }
            #endregion

        }

        public static void TablePopulation()
        { 
            #region Вывод на экран (моя версия)
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (j == 3 || j == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(TheTableArray[i,j]);
                    }
                    else
                    {
                        if (i == 2 || i == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(TheTableArray[i, j]);
                        }
                        else
                        {
                            if ((i == 1 || i == 4 || i == 7) && (j == 1 || j == 5 || j == 9))
                            {
                                if (TheTableArray[i, j] == "X")
                                { Console.ForegroundColor = ConsoleColor.Yellow; }
                                else if (TheTableArray[i, j] == "O")
                                { Console.ForegroundColor = ConsoleColor.Red; }
                                else
                                { Console.ForegroundColor = ConsoleColor.DarkGray; }
                                Console.Write(TheTableArray[i, j]);
                            }
                            else
                                Console.Write(TheTableArray[i, j]);
                        }
                    }
                }
                Console.WriteLine();
            }
            #endregion

            #region  Вывод на экран(комментарии и доп сценарии)
        /*
        //Определенную сложность может представлять перебор многомерного массива. 
        //Прежде всего надо учитывать, что длина такого массива - это совокупное количество элементов.
        //И цикл foreach выводит все элементы массива в строку =(
        //если мы хотим отдельно пробежаться по каждой строке в таблице - надо получить количество элементов в размерности. 
        //у каждого массива есть метод GetUpperBound(dimension), который возвращает индекс последнего элемента в определенной размерности. 
        //В двухмерном массиве первая размерность (с индексом 0) по сути это и есть таблица. 
        //И с помощью выражения mas.GetUpperBound(0) + 1 можно получить количество строк таблицы, представленной двухмерным массивом.
        //А через mas.Length / rows можно получить количество элементов в каждой строке
        int rows = mas.GetUpperBound(0) + 1;
        int columns = mas.Length / rows;
        // или так
        // int columns = mas.GetUpperBound(1) + 1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{mas[i, j]} \t");
            }
            Console.WriteLine();
        }
        */
        #endregion
         }

        public static void Player1()
        {
            string chosenString = "";
            int chosenNumber = 0;
            bool success = false;
            bool exist = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Player 1 (X): Enter the number of cell");
                chosenString = Console.ReadLine();
                //проверка на ошибку ввода не цифры, а буквы или других символов
                success = int.TryParse(chosenString, out chosenNumber);
                //проверка, что такая цифра ещё не занята
                exist = existingNumbers.Contains(chosenString);
                if (success == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Fill in only Number. Try again!");
                }
                else
                {
                    if (exist == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("This cell has been already chosen. Try again!");
                    }
                    else
                        existingNumbers += chosenNumber;
                }
            }
            while (success == false || exist == true);

            // Если введенное число совпало со стринговой записью числа, то замени на X
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    TheTableArray[i, j] = TheTableArray[i, j].Replace(chosenString, "X");
                }
            }

        }

        public static void Player2()
        {
            string chosenString = "";
            int chosenNumber = 0;
            bool success = false;
            bool exist = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player 2 (O): Enter the number of cell");
                chosenString = Console.ReadLine();
                //проверка на ошибку ввода не цифры, а буквы или других символов
                success = int.TryParse(chosenString, out chosenNumber);
                //проверка, что такая цифра ещё не занята
                exist = existingNumbers.Contains(chosenString);
                if (success == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fill in only Number. Try again!");
                }
                else
                {
                    if (exist == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This cell has been already chosen. Try again!");
                    }
                    else
                        existingNumbers += chosenNumber;
                }
            }
            while (success == false || exist == true);

            // Если введенное число совпало со стринговой записью числа, то замени на O
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    TheTableArray[i, j] = TheTableArray[i, j].Replace(chosenString, "O");
                }
            }

        }

        public static void Winner()
        {
            
            int winnercounter = 0;
            string Congrats = "";
            string winner = "X";

            for (int i = 0; i<2; i++)
            {
                bool line1 = (winner == TheTableArray[1, 1] && TheTableArray[1, 1] == TheTableArray[1, 5] && TheTableArray[1, 5] == TheTableArray[1, 9]);
                bool line2 = (winner == TheTableArray[4, 1] && TheTableArray[4, 1] == TheTableArray[4, 5] && TheTableArray[4, 5] == TheTableArray[4, 9]);
                bool line3 = (winner == TheTableArray[7, 1] && TheTableArray[7, 1] == TheTableArray[7, 5] && TheTableArray[7, 5] == TheTableArray[7, 9]);
                bool diagonal1 = (winner == TheTableArray[1, 1] && TheTableArray[1, 1] == TheTableArray[4, 5] && TheTableArray[4, 5] == TheTableArray[7, 9]);
                bool diagonal2 = (winner == TheTableArray[1, 9] && TheTableArray[1, 9] == TheTableArray[4, 5] && TheTableArray[4, 5] == TheTableArray[7, 1]);
                bool column1 = (winner == TheTableArray[1, 1] && TheTableArray[1, 1] == TheTableArray[4, 1] && TheTableArray[4, 1] == TheTableArray[7, 1]);
                bool column2 = (winner == TheTableArray[1, 5] && TheTableArray[1, 5] == TheTableArray[4, 5] && TheTableArray[4, 5] == TheTableArray[7, 5]);
                bool column3 = (winner == TheTableArray[1, 9] && TheTableArray[1, 9] == TheTableArray[4, 9] && TheTableArray[4, 9] == TheTableArray[7, 9]);
                final = (line1 || line2 || line3 || diagonal1 || diagonal2 || column1 || column2 || column3);
                if (final == true)
                {
                    Congrats = winner;
                    winnercounter++;
                }
                winner = "O";
            }

            if (winnercounter == 2)
            {
                final = true;
                Console.WriteLine("DRAW!");
            }
            else if (winnercounter == 1)
            {
                final = true;
                if (Congrats == "X")
                    Console.WriteLine("The winner is Player 1");
                else
                    Console.WriteLine("The winner is Player 2");
            }
            else if (winnercounter == 0 && existingNumbers.Length == 9)
            {
                final = true;
                Console.WriteLine("Draw!");
            }
        }


        static void Main(string[] args)
        {
            string reset;
            do
            {
            reset = "";
            Array.Clear(TheTableArray,9,11);
            existingNumbers = "";
            final = false;
            Console.Clear();
            Console.WriteLine("Let's play a tic tac toe!");
                //Создание массива и заполнение его дефолтными значениями
                TableCreation();
                //вывод на экран поля и цифр с названиями ячеек
                TablePopulation();

                #region Image
                /*
                ***|***|*** row0
                *1*|*2*|*3* row1
                ---|---|--- row2
                ***|***|*** row3
                *4*|*5*|*6* row4
                ---|---|--- row5
                ***|***|*** row6
                *7*|*8*|*9* row7
                ***|***|*** row8

                1 - 1,1
                2 - 1,5
                3 - 1,9
                4 - 4,1
                5 - 4,5
                6 - 4,9
                7 - 7,1
                8 - 7,5
                9 - 7,9
                 */
                #endregion

                do
                {
                    //цикл запроса хода игрока1
                    Player1();
                    //Стираем всё
                    Console.Clear();
                    //Вывод новой таблицы с обновленными данными
                    TablePopulation();
                    //цикл запроса хода игрока2
                    //проверка, что не все ячейки заняты
                    if (existingNumbers.Length != 9)
                    {
                        Player2();
                        Console.Clear();
                        //Вывод новой таблицы с обновленными данными
                        TablePopulation();
                    }
                    //проверка победы
                    Winner();
                }
                while (final == false);

                //Reset
                Console.WriteLine("To reset game please press Y, other symbols will closed programm");
                reset = Console.ReadLine();
            }
            while (reset == "Y" || reset == "y");

        }
    }
 }
