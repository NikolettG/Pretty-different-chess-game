using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy_Chess_Game
{
     class Program
    {
        static void Main(string[] args)
        {
            


            

            //Welcome title
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(60, 0);
            Console.WriteLine("Welcome in the Fantasy Chess Game!");

            

            

            //description - but now I will don't use beacuse of space
            //Description();

            

            Console.ForegroundColor = ConsoleColor.Cyan;
            
            byte[] row = new byte[5] 
                {1, 2, 3, 4, 5};

            ShowArrayPosRow(row, 4, 0);

           

            int size = Convert.ToInt32(Size(properties_field));

            

            SetYPoz(properties_yellow, size);


            Console.ForegroundColor = ConsoleColor.Cyan;


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(60, 10);
           
            Console.SetCursorPosition(76, 10);

            ShowArrayPosCol(FillArrayCol(Col(size)), 0, 2);

           
            
            //kiindulási pont
            string[,] field = CreateField(row, Col(size));
            ShowField(FillField(field, properties_blue, properties_yellow, 200, 200, 'N'));  

           //Addig 
            while(!Winning(properties_blue, properties_yellow))
            {
                
                ShowLost(properties_blue, properties_yellow);


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 60);
                AllProperties(properties_blue, properties_yellow);


                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.SetCursorPosition(0, 22);

                


                string input = null;
                Console.WriteLine("Kérek egy bábút: ");
                input = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine();
                Console.WriteLine();



                if(input == "I")
                {

                }
                //ShowStesp(field, input, properties_blue, properties_yellow);

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Cyan;
                string[] yx = ShowStesp(ShowField(FillField(CreateField(row, Col(size)), properties_blue, properties_yellow, 200, 200, 'N')), input, properties_blue, properties_yellow);
                Console.WriteLine();
                Console.SetCursorPosition(0, 20);

             
                if (yx != null)
                {
                   

                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 24);
                Console.WriteLine("Sor: ");
                string input_y = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine();





                Console.WriteLine("Oszlop: ");
                string input_x = Console.ReadLine();

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                






                int n = 60;
                int n2 = 25;
                int counter = 0;
                //Miután beírtam az értékeket, törölje ki őket

                while (counter <= 20)
                {
                    Console.SetCursorPosition(n, n2);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(n, n2);
                    n2 += 2;
                    counter++;
                }



                Console.WriteLine();
               
                
               
                NewPozition(CreateField(row, Col(size)), yx, input_y, input_x, input, properties_blue, properties_yellow);

                

               
            }
            if(Winning(properties_blue, properties_yellow))
            {
                string winner = Winner(properties_blue, properties_yellow);
                Console.Clear();
                Console.WriteLine($"Nyert a {winner} csapat!");
            }
           


            Console.ReadKey();

        }
        //Call read files
        static List<Properties_Blue> properties_blue = PropertiesIO.Read_blue("blue.txt");
        static List<Properties_Yellow> properties_yellow = PropertiesIO.Read_yellow("yellow.txt");
        static List<Properties_Field> properties_field = PropertiesIO.Read_field("size.txt");

        static byte size = Size(properties_field);

        

        
        //This function is return a size for col of field
        static byte Size(List<Properties_Field> properties_field)
        {
            byte size = 0;

            for (int i = 0; i < properties_field.Count; i++)
            {
                size = properties_field[i].Size;
            }

            return size;
            
        }

        //This function is create a col array for design
        static int[] Col(int size)
        {
            int[] col;
            if (size > 7 && size < 16)
            {
                return col = new int[size];
            }
            else
            {
                return col = new int[10];
            }
            
        }

        //This function is for the all description
        static void Description()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(60, 6);
            Console.WriteLine("About the game:");
            Console.SetCursorPosition(60, 7);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("- Puppet is red, when it has 1 life");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(60, 8);
            Console.WriteLine("- You win if you kill the king or kill the all knights!");
        }

        //This function is show the row of array in console
        static void ShowArrayPosRow(byte[] arr, int x, int y)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(arr[i]);
                x += 8;

            }
        }

        //This function is fil coll with numbers
        static int[] FillArrayCol(int[] arr)
        {
            int n = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = n;
                n++;

            }

            return arr;
        }

        //This function is show the col of array in console
        static void ShowArrayPosCol(int[] arr, int x, int y)
        {
          
            for (int i = 0; i < arr.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(arr[i]);
                y += 2;

            }
        }

        static void SetYPoz(List<Properties_Yellow> properties_yellow, int size)
        {
            int legth = size - 1;
            foreach (Properties_Yellow item in properties_yellow)
            {
                item.Y_coordinate_now = Convert.ToByte(legth - item.Y_coordinate_now);
            }
        }

        //This function is cerate a matrix for field
        static string[,] CreateField(byte[] row, int[] col)
        {
            int col_size = col.Length;
            int row_size = row.Length;

            string[,] field = new string[col_size, row_size];

            return field;
        }


        //This function is fill the matrix of field
        static string[,] FillField(string[,] matrix, List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow, byte y_prev, byte x_prev, char group)
        {
            //át kéne adni egy stringet, hogy B vagy Y és az alapján dönteni a prev-ről, ha Y-vel léptem, akkor a B prev legyen 0
            foreach (Properties_Blue item in properties_blue)
            {
               if(item.Life > 0)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {


                            if (j == x_prev && i == y_prev)
                            {
                                if (y_prev != item.Y_coordinate_now && x_prev != item.X_coordinate_now && y_prev != 200 && x_prev != 200 && group == 'B')
                                {


                                    matrix[i, j] = "xx";


                                }

                            }


                            if (item.Y_coordinate_now == i && item.X_coordinate_now == j)
                            {

                                matrix[i, j] = item.Name;
                            }

                        }
                    }
                }

                    
                


            }

            foreach (Properties_Yellow item in properties_yellow)
            {

                if(item.Life > 0)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (j == x_prev && i == y_prev)
                            {
                                if (y_prev != item.Y_coordinate_now && x_prev != item.X_coordinate_now && y_prev != 200 && x_prev != 200 && group != 'B')   //BUG!!!
                                {
                                    matrix[i, j] = "xx";
                                }

                            }


                            if (item.Y_coordinate_now == i && item.X_coordinate_now == j)
                            {

                                matrix[i, j] = item.Name;
                            }


                        }
                    }
                }
                
                    

                

            }


           
            
                for (int i = 0; i < matrix.GetLength(0); i++)
                {

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        if (matrix[i, j] == null)
                        {
                            matrix[i, j] = "xx";
                        }
                    }
                }
            
               

            return matrix;
        }

        //This function is give the current matrix positiones


        //This function is shows the matrix of field
        static string[,] ShowField(string[,] matrix)
        {
            byte y = 2;
            byte x = 4;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y);
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   if (matrix[i,j].Contains("B"))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (matrix[i, j].Contains("Y"))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    if (matrix[i, j] == "xx")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write($"{matrix[i,j]}      ");

                   
                }
                Console.WriteLine();
                Console.WriteLine();
               y += 2;
                
            }
            return matrix;
        }


      


        //This function is show the steps
        static string[] ShowStesp(string[,] matrix, string input, List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow)
        {
            string input_ = input.ToUpper();
           
            //megkeressük az adott koordinátáját a bábúnak
            int y = 0;
            int x = 0;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == input_) //ahol a megadott név szerepel
                    {
                        y = i;  //itt töltem be az adott koordinátákat
                        x = j;
                    }
                }
            }

            int y1 = 0;
            int x1 = 0;
            int y2 = 0;
            int x2 = 0;
            int y3 = 0;
            int x3 = 0;
            int y4 = 0;
            int x4 = 0;
            int y5 = 0;
            int x5 = 0;
            int y6 = 0;
            int x6 = 0;



            int[] yy = new int[10];
            int[] xx = new int[10];

            string[] yx = new string[20];
            int c = 0;

            int n = 60;  //nézet miatt
            int n2 = 25;

            if (input_.Contains("B"))
            {
                foreach (Properties_Blue item in properties_blue)
                {
                    if (item.Name == input_)
                    {
                        if (item.Steps == 1)
                        {

                            y1 = y + item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x1 = x + item.X_coordinate;


                            if (y1 < matrix.GetLength(0) && x1 < matrix.GetLength(1))
                            {
                                for (int i = 0; i < matrix.GetLength(0); i++)
                                {
                                    for (int j = 0; j < matrix.GetLength(1); j++)
                                    {
                                        if (y1 == i && x1 == j && !matrix[i, j].Contains("B")) //azon a koordinátán nem szerepel 'B'
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.SetCursorPosition(n, n2);
                                            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y1 + 1}, Oszlop: {x1 + 1}");

                                            yx[c] = Convert.ToString(y1) + Convert.ToString(x1); //hozzáadom a tömbhöz stringként a további vizsgálatokhoz


                                        }
                                    }
                                }
                            }


                           

                            




                        }

                        if (item.Steps == 2)
                        {

                            //int n = 60;  //nézet miatt
                            //int n2 = 5;

                            y1 = y + Convert.ToInt32(item.Y_coordinate);  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x1 = x + Convert.ToInt32(item.X_coordinate);

                            byte count_y_1 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                            byte count_y_2 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                            byte count_y_3 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                            byte count_y_4 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                            byte count_y_5 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                            byte count_y_6 = 0;  //ha ez 1 lesz, akkor nem megy tovább

                            if (y1 < matrix.GetLength(0) && x1 < matrix.GetLength(1))
                            {
                               
                                for (int i = 0; i < matrix.GetLength(0); i++)
                                {
                                    for (int j = 0; j < matrix.GetLength(1); j++)
                                    {
                                        if (y1 == i && x1 == j && !matrix[i, j].Contains("B") && count_y_1 == 0) //ahol nem 'B' bábú szerepel
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.SetCursorPosition(n, n2);
                                            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y1 + 1}, Oszlop: {x1 + 1}");  //csak azokat írja ki, ahol nem szerepel "B", tehát ahová valóban léphet

                                            yx[c] = Convert.ToString(y1) + Convert.ToString(x1);
                                            c++;


                                            y1 += item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x1 += item.X_coordinate;


                                            
                                            n2 += 2;

                                            if(matrix[i, j].Contains("Y"))
                                            {
                                                count_y_1++;
                                            }
                                            

                                        }
                                    }
                                }

                            }
                        
                        
                        
                            y2 = y - Convert.ToInt32(item.Y_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x2 = x - Convert.ToInt32(item.X_coordinate);
                            //n2 += 2;
                            if (y2 >= 0 && x2 >= 0 && count_y_2 == 0)
                            {

                                for (int i = matrix.GetLength(0) -1; i >= 0; i--)
                                {
                                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                    {
                                        if (y2 == i && x2 == j && !matrix[i, j].Contains("B")) //ahol a megadott név szerepel
                                        {



                                            byte counter = 0;

                                            string coordinate = Convert.ToString(y2) + Convert.ToString(x2);


                                            for (int k = 0; k < yx.Length; k++)
                                            {
                                                if (yx[k] == coordinate)
                                                {
                                                    counter++;
                                                }
                                            }

                                            if (counter == 0)
                                            {
                                                yx[c] = Convert.ToString(y2) + Convert.ToString(x2);
                                                c++;

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.SetCursorPosition(n, n2);
                                                Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y2 + 1}, Oszlop: {x2 + 1}");
                                            }

                                            counter = 0;


                                            y2 -= item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x2 -= item.X_coordinate;

                                            n2 += 2;

                                            if (matrix[i, j].Contains("Y"))
                                            {
                                                count_y_2++;
                                            }



                                        }
                                    }
                                }



                                y3 = y + Convert.ToInt32(item.Y_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                x3 = x - Convert.ToInt32(item.X_coordinate);


                                if (y3 >= 0 && x3 >= 0 && y3 < matrix.GetLength(0) && x3 < matrix.GetLength(1))
                                {
                                    for (int i = 0; i < matrix.GetLength(0); i++)
                                    {
                                        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                        {
                                            if (y3 == i && x3 == j && !matrix[i, j].Contains("B") && count_y_3 == 0) //ahol a megadott név szerepel
                                            {
                                                byte counter = 0;

                                                string coordinate = Convert.ToString(y3) + Convert.ToString(x3);


                                                for (int k = 0; k < yx.Length; k++)
                                                {
                                                    if (yx[k] == coordinate)
                                                    {
                                                        counter++;
                                                    }
                                                }

                                                if (counter == 0)
                                                {
                                                    yx[c] = Convert.ToString(y3) + Convert.ToString(x3);
                                                    c++;

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.SetCursorPosition(n, n2);
                                                    Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y3 + 1}, Oszlop: {x3 + 1}");
                                                }

                                                counter = 0;


                                                y3 += item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                                x3 -= item.X_coordinate;

                                                n2 += 2;

                                                if (matrix[i, j].Contains("Y"))
                                                {
                                                    count_y_3++;
                                                }
                                            }
                                        }
                                    }
                                }

                                y4 = y - Convert.ToInt32(item.Y_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                x4 = x + Convert.ToInt32(item.X_coordinate);

                                if (y4 >= 0 && x4 >= 0 && y4 < matrix.GetLength(0) && x4 < matrix.GetLength(1))
                                {
                                    for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                                    {
                                        for (int j = 0; j < matrix.GetLength(1); j++)
                                        {
                                            if (y4 == i && x4 == j && !matrix[i, j].Contains("B") && count_y_4 == 0) //ahol a megadott név szerepel
                                            {
                                                byte counter = 0;

                                                string coordinate = Convert.ToString(y4) + Convert.ToString(x4);


                                                for (int k = 0; k < yx.Length; k++)
                                                {
                                                    if (yx[k] == coordinate)
                                                    {
                                                        counter++;
                                                    }
                                                }

                                                if (counter == 0)
                                                {
                                                    yx[c] = Convert.ToString(y4) + Convert.ToString(x4);
                                                    c++;

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.SetCursorPosition(n, n2);
                                                    Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y4 + 1}, Oszlop: {x4 + 1}");
                                                }

                                                counter = 0;


                                                y4 += item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                                x4 -= item.X_coordinate;

                                                n2 += 2;

                                                if (matrix[i, j].Contains("Y"))
                                                {
                                                    count_y_4++;
                                                }

                                            }
                                        }
                                    }
                                }


                                y5 = y - Convert.ToInt32(item.X_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                x5 = x - Convert.ToInt32(item.Y_coordinate);


                                //n2 += 2;
                                if (y5 >= 0 && x5 >= 0)
                                {
                                    for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                                    {
                                        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                        {
                                            if (y5 == i && x5 == j && !matrix[i, j].Contains("B") && count_y_5 == 0) //ahol a megadott név szerepel
                                            {
                                                byte counter = 0;

                                                string coordinate = Convert.ToString(y5) + Convert.ToString(x5);


                                                for (int k = 0; k < yx.Length; k++)
                                                {
                                                    if (yx[k] == coordinate)
                                                    {
                                                        counter++;
                                                    }
                                                }

                                                if (counter == 0)
                                                {
                                                    yx[c] = Convert.ToString(y5) + Convert.ToString(x5);
                                                    c++;

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.SetCursorPosition(n, n2);
                                                    Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y5 + 1}, Oszlop: {x5 + 1}");
                                                }

                                                counter = 0;


                                                y5 -= item.X_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                                x5 -= item.Y_coordinate;

                                                n2 += 2;

                                                if (matrix[i, j].Contains("Y"))
                                                {
                                                    count_y_5++;
                                                }
                                            }
                                        }
                                    }
                                }

                                ///////////////////////

                                y6 = y + Convert.ToInt32(item.X_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                x6 = x + Convert.ToInt32(item.Y_coordinate);


                                //n2 += 2;
                                if (y6 >= 0 && x6 >= 0)
                                {
                                    for (int i = 0; i < matrix.GetLength(0); i++)
                                    {
                                        for (int j = 0; j < matrix.GetLength(1); j++)
                                        {
                                            if (y6 == i && x6 == j && !matrix[i, j].Contains("B") && count_y_6 == 0) //ahol a megadott név szerepel
                                            {
                                                byte counter = 0;

                                                string coordinate = Convert.ToString(y6) + Convert.ToString(x6);


                                                for (int k = 0; k < yx.Length; k++)
                                                {
                                                    if (yx[k] == coordinate)
                                                    {
                                                        counter++;
                                                    }
                                                }

                                                if (counter == 0)
                                                {
                                                    yx[c] = Convert.ToString(y6) + Convert.ToString(x6);
                                                    c++;

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.SetCursorPosition(n, n2);
                                                    Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y6 + 1}, Oszlop: {x6 + 1}");
                                                }

                                                counter = 0;


                                                y6 += item.X_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                                x6 += item.Y_coordinate;

                                                n2 += 2;

                                                if (matrix[i, j].Contains("Y"))
                                                {
                                                    count_y_6++;
                                                }
                                            }
                                        }
                                    }
                                }





                            }//
                        }

                        
                    }
                }
            }
//////////////////////////////////////////////////////////////////////////////////

            if (input_.Contains("Y"))
            {
                byte count_b_1 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                byte count_b_2 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                byte count_b_3 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                byte count_b_4 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                byte count_b_5 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                byte count_b_6 = 0;  //ha ez 1 lesz, akkor nem megy tovább
                foreach (Properties_Yellow item in properties_yellow)
                {


                    if (item.Name == input_)
                    {
                        if (item.Steps == 1)
                        {
                            
                            y1 = y - item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x1 = x - item.X_coordinate;

                            if (y1 >= 0 && x1 >= 0)
                            {
                                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                                {
                                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                    {
                                        if (y1 == i && x1 == j && !matrix[i, j].Contains("Y")) //azon a koordinátán nem szerepel 'B'
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.SetCursorPosition(n, n2);
                                            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y1 + 1}, Oszlop: {x1 + 1}");

                                            yx[c] = Convert.ToString(y1) + Convert.ToString(x1); //hozzáadom a tömbhöz stringként a további vizsgálatokhoz


                                        }
                                    }
                                }
                            }

                            //Ez a rész még nincs kész (ami commentben van, csak az!!), tovább lesz majd fejlesztve a jövőben:)

                            //y2 = y + item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            //x2 = x + item.X_coordinate;

                            //if (y2 < matrix.GetLength(0) && x2 < matrix.GetLength(1))
                            //{
                            //    for (int i = 0; i < matrix.GetLength(0); i++)
                            //    {
                            //        for (int j = 0; j < matrix.GetLength(1); j++)
                            //        {
                            //            if (y1 == i && x1 == j && !matrix[i, j].Contains("Y")) //azon a koordinátán nem szerepel 'B'
                            //            {
                            //                Console.SetCursorPosition(n, n2);
                            //                Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y2 + 1}, Oszlop: {x2 + 1}");

                            //                yx[c] = Convert.ToString(y2) + Convert.ToString(x2); //hozzáadom a tömbhöz stringként a további vizsgálatokhoz


                            //            }
                            //        }
                            //    }
                            //}
                                

                            //y3 = y - item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            //x3 = x + item.X_coordinate;

                            //for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                            //{
                            //    for (int j = 0; j < matrix.GetLength(1); j++)
                            //    {
                            //        if (y1 == i && x1 == j && !matrix[i, j].Contains("Y")) //azon a koordinátán nem szerepel 'B'
                            //        {
                            //            Console.SetCursorPosition(n, n2);
                            //            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y3 + 1}, Oszlop: {x3 + 1}");

                            //            yx[c] = Convert.ToString(y3) + Convert.ToString(x3); //hozzáadom a tömbhöz stringként a további vizsgálatokhoz


                            //        }
                            //    }
                            //}
                            //y4 = y + item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            //x4 = x - item.X_coordinate;

                            //for (int i = 0; i < matrix.GetLength(0); i++) 
                            //{
                            //    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                            //    {
                            //        if (y1 == i && x1 == j && !matrix[i, j].Contains("Y")) //azon a koordinátán nem szerepel 'B'
                            //        {
                            //            Console.SetCursorPosition(n, n2);
                            //            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y4 + 1}, Oszlop: {x4 + 1}");

                            //            yx[c] = Convert.ToString(y4) + Convert.ToString(x4); //hozzáadom a tömbhöz stringként a további vizsgálatokhoz


                            //        }
                            //    }
                            //}

                            //y5= y + item.X_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            //x5 = x + item.Y_coordinate;

                            //for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                            //{
                            //    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                            //    {
                            //        if (y1 == i && x1 == j && !matrix[i, j].Contains("Y")) //azon a koordinátán nem szerepel 'B'
                            //        {
                            //            Console.SetCursorPosition(n, n2);
                            //            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y5 + 1}, Oszlop: {x5 + 1}");

                            //            yx[c] = Convert.ToString(y5) + Convert.ToString(x5); //hozzáadom a tömbhöz stringként a további vizsgálatokhoz


                            //        }
                            //    }
                            //}

                            //y6 = y - item.X_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            //x6 = x - item.Y_coordinate;

                            //for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                            //{
                            //    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                            //    {
                            //        if (y1 == i && x1 == j && !matrix[i, j].Contains("Y")) //azon a koordinátán nem szerepel 'B'
                            //        {
                            //            Console.SetCursorPosition(n, n2);
                            //            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y6 + 1}, Oszlop: {x6 + 1}");

                            //            yx[c] = Convert.ToString(y6) + Convert.ToString(x6); //hozzáadom a tömbhöz stringként a további vizsgálatokhoz


                            //        }
                            //    }
                            //}

                        }

                        if (item.Steps == 2)
                        {

                            //int n = 60;  //nézet miatt
                            //int n2 = 5;

                            y1 = y + Convert.ToInt32(item.Y_coordinate);  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x1 = x + Convert.ToInt32(item.X_coordinate);

                            

                            if (y1 < matrix.GetLength(0) && x1 < matrix.GetLength(1))
                            {

                                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                                {
                                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                    {
                                        if (y1 == i && x1 == j && !matrix[i, j].Contains("Y") && count_b_1 == 0) //ahol nem 'B' bábú szerepel
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.SetCursorPosition(n, n2);
                                            Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y1 + 1}, Oszlop: {x1 + 1}");  //csak azokat írja ki, ahol nem szerepel "B", tehát ahová valóban léphet

                                            yx[c] = Convert.ToString(y1) + Convert.ToString(x1);
                                            c++;


                                            y1 += item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x1 += item.X_coordinate;



                                            n2 += 2;

                                            if (matrix[i, j].Contains("B"))
                                            {
                                                count_b_1++;
                                            }



                                         

                                        }
                                    }
                                }

                            }



                            y2 = y - Convert.ToInt32(item.Y_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x2 = x - Convert.ToInt32(item.X_coordinate);
                            //n2 += 2;
                            if (y2 >= 0 && x2 >= 0)
                            {

                                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                                {
                                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                    {
                                        if (y2 == i && x2 == j && !matrix[i, j].Contains("Y") && count_b_2 == 0) //ahol a megadott név szerepel
                                        {
                                            byte counter = 0;

                                            string coordinate = Convert.ToString(y2) + Convert.ToString(x2);


                                            for (int k = 0; k < yx.Length; k++)
                                            {
                                                if (yx[k] == coordinate)
                                                {
                                                    counter++;
                                                }
                                            }

                                            if (counter == 0)
                                            {
                                                yx[c] = Convert.ToString(y2) + Convert.ToString(x2);
                                                c++;

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.SetCursorPosition(n, n2);
                                                Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y2 + 1}, Oszlop: {x2 + 1}");
                                            }

                                            counter = 0;


                                            y2 -= item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x2 -= item.X_coordinate;

                                            n2 += 2;

                                            if (matrix[i, j].Contains("B"))
                                            {
                                                count_b_2++;
                                            }



                                        }
                                    }
                                }




                            }

                            y3 = y + Convert.ToInt32(item.Y_coordinate);  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x3 = x - Convert.ToInt32(item.X_coordinate);
                            //n2 += 2;
                            if (y3 >= 0 && x3 >= 0 && y3 < matrix.GetLength(0) && x3 < matrix.GetLength(1))
                            {

                                for (int i = 0; i < matrix.GetLength(0); i++)
                                {
                                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                    {
                                        if (y3 == i && x3 == j && !matrix[i, j].Contains("Y") && count_b_3 == 0) //ahol a megadott név szerepel
                                        {

                                            byte counter = 0;

                                            string coordinate = Convert.ToString(y3) + Convert.ToString(x3);


                                            for (int k = 0; k < yx.Length; k++)
                                            {
                                                if (yx[k] == coordinate)
                                                {
                                                    counter++;
                                                }
                                            }

                                            if (counter == 0)
                                            {
                                                yx[c] = Convert.ToString(y3) + Convert.ToString(x3);
                                                c++;

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.SetCursorPosition(n, n2);
                                                Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y3 + 1}, Oszlop: {x3 + 1}");
                                            }

                                            counter = 0;


                                            y3 += item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x3 -= item.X_coordinate;

                                            n2 += 2;

                                            if (matrix[i, j].Contains("B"))
                                            {
                                                count_b_3++;
                                            }



                                        }
                                    }
                                }




                            }

                            y4 = y - Convert.ToInt32(item.Y_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x4 = x + Convert.ToInt32(item.X_coordinate);
                            //n2 += 2;
                            if (y4 >= 0 && x4 >= 0 && y4 < matrix.GetLength(0) && x4 < matrix.GetLength(1))
                            {

                                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                                {
                                    for (int j = 0; j < matrix.GetLength(1); j++)
                                    {
                                        if (y4 == i && x4 == j && !matrix[i, j].Contains("Y") && count_b_4 == 0) //ahol a megadott név szerepel
                                        {


                                            byte counter = 0;

                                            string coordinate = Convert.ToString(y4) + Convert.ToString(x4);

                                            for (int k = 0; k < yx.Length; k++)
                                            {
                                                if (yx[k] == coordinate)
                                                {
                                                    counter++;
                                                }
                                            }

                                            if (counter == 0)
                                            {
                                                yx[c] = Convert.ToString(y4) + Convert.ToString(x4);
                                                c++;

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.SetCursorPosition(n, n2);
                                                Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y4 + 1}, Oszlop: {x4 + 1}");
                                            }

                                            counter = 0; //visszaállítjuk 0-ra

                                            y4 -= item.Y_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x4 += item.X_coordinate;

                                            n2 += 2;

                                            if (matrix[i, j].Contains("B"))
                                            {
                                                count_b_4++;
                                            }



                                        }
                                    }
                                }




                            }

                            y5 = y + Convert.ToInt32(item.X_coordinate);  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x5 = x + Convert.ToInt32(item.Y_coordinate);
                            //n2 += 2;
                            if (y5 >= 0 && x5 >= 0 && y5 < matrix.GetLength(0) && x5 < matrix.GetLength(1))
                            {

                                for (int i = 0; i < matrix.GetLength(0); i++)
                                {
                                    for (int j = 0; j < matrix.GetLength(1); j++)
                                    {
                                        if (y5 == i && x5 == j && !matrix[i, j].Contains("Y") && count_b_5 == 0) //ahol a megadott név szerepel
                                        {


                                            byte counter = 0;

                                            string coordinate = Convert.ToString(y5) + Convert.ToString(x5);

                                            for (int k = 0; k < yx.Length; k++)
                                            {
                                                if (yx[k] == coordinate)
                                                {
                                                    counter++;
                                                }
                                            }

                                            if (counter == 0)
                                            {
                                                yx[c] = Convert.ToString(y5) + Convert.ToString(x5);
                                                c++;

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.SetCursorPosition(n, n2);
                                                Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y5 + 1}, Oszlop: {x5 + 1}");
                                            }

                                            counter = 0; //visszaállítjuk 0-ra

                                            y5 -= item.X_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x5 += item.Y_coordinate;

                                            n2 += 2;

                                            if (matrix[i, j].Contains("B"))
                                            {
                                                count_b_5++;
                                            }



                                        }
                                    }
                                }




                            }
                            y6 = y - Convert.ToInt32(item.X_coordinate);   //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                            x6 = x - Convert.ToInt32(item.Y_coordinate);
                            //n2 += 2;
                            if (y6 >= 0 && x6 >= 0 && y6 < matrix.GetLength(0) && x6 < matrix.GetLength(1))
                            {

                                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                                {
                                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                                    {
                                        if (y6 == i && x6 == j && !matrix[i, j].Contains("Y") && count_b_6 == 0) //ahol a megadott név szerepel
                                        {


                                            byte counter = 0;

                                            string coordinate = Convert.ToString(y6) + Convert.ToString(x6);

                                            for (int k = 0; k < yx.Length; k++)
                                            {
                                                if (yx[k] == coordinate)
                                                {
                                                    counter++;
                                                }
                                            }

                                            if (counter == 0)
                                            {
                                                yx[c] = Convert.ToString(y6) + Convert.ToString(x6);
                                                c++;

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.SetCursorPosition(n, n2);
                                                Console.WriteLine($"{input_} Lehetséges lépések -> Sor: {y6 + 1}, Oszlop: {x6 + 1}");
                                            }

                                            counter = 0; //visszaállítjuk 0-ra

                                            y6 -= item.X_coordinate;  //hozzáadom a jelenlegi koordinátához a lehetséges koordinátákat
                                            x6 -= item.Y_coordinate;

                                            n2 += 2;

                                            if (matrix[i, j].Contains("B"))
                                            {
                                                count_b_6++;
                                            }



                                        }
                                    }
                                }




                            }
                        }


                    }
                }
            }




            return yx;
        }

        

        //Update properties
        static void NewPozition(string[,] matrix, string[] yx, string y, string x, string input, List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow)
        {
            string input_ = input.ToUpper();
            int yy = Convert.ToByte(y) - 1; 
            int xx = Convert.ToByte(x) - 1;

            Console.WriteLine($"input: {input_}");
            string yx_input = Convert.ToString(yy) + Convert.ToString(xx);

            byte y_poz = Convert.ToByte(y);
            byte x_poz = Convert.ToByte(x);

            
            byte y_pre= 0;
            byte x_pre = 0;

            byte y_now = 0;
            byte x_now = 0;

            bool exists = true;


            char group = 'N';   //default 'N'

            Console.WriteLine(yx_input);

            for (int i = 0; i < yx.Length; i++)
            {
               
                if (yx[i] == yx_input)    //hogyha a beírt érték benne van a lehetőségek között, akkor vizsgálódjon tovább
                {
                    if (input_.Contains("B"))
                    {
                        group = 'B';

                        foreach (Properties_Blue item in properties_blue)
                        {
                            if (item.Name == input_)
                            {

                                 y_pre = item.Y_coordinate_now;    //csak akkor írja felül a koordinátákat, hogyha az megfelel a feltételeknek
                                
                                x_pre = item.X_coordinate_now;

                                y_now = Convert.ToByte(y_poz - 1);
                                x_now = Convert.ToByte(x_poz - 1);

                             
                                int counter = 0;

                             


                                foreach (Properties_Yellow itemY in properties_yellow)
                                {
                                    if (itemY.Y_coordinate_now == y_now && itemY.X_coordinate_now == x_now)
                                    {
                                       

                                        if (item.Shot > 0)
                                        {
                                            item.Shot--;

                                            if (itemY.Shield > 0)
                                            {
                                                itemY.Shield--;
                                            }
                                            else
                                            {
                                                itemY.Life--;
                                            }

                                        }

                                        if (itemY.Life == 0)
                                        {
                                            itemY.Y_coordinate_now = 200;
                                            itemY.X_coordinate_now = 200;

                                            item.X_coordinate_now = x_now;     //csak akkor írja felül a koordinátákat, hogyha az megfelel a feltételeknek
                                            item.Y_coordinate_now = y_now;
                                          
                                            exists = false;
                                        }
                                    }


                                    if (itemY.Y_coordinate_now == y_now && itemY.X_coordinate_now == x_now)
                                    {
                                        counter++;
                                    }
                                }


                                if (counter == 0)  //tehát nincs a mezőn Y-on
                                {
                                    item.X_coordinate_now = x_now;     //csak akkor írja felül a koordinátákat, hogyha az megfelel a feltételeknek
                                    item.Y_coordinate_now = y_now;

                                    exists = false;
                                }

                           

                            }

                            

                        }

                    }
                    if (input_.Contains("Y"))
                    {

                        group = 'Y';
                        foreach (Properties_Yellow item in properties_yellow)
                        {
                            if (item.Name == input_)
                            {

                                y_pre = item.Y_coordinate_now;    //csak akkor írja felül a koordinátákat, hogyha az megfelel a feltételeknek

                                x_pre = item.X_coordinate_now;
                                //ide jön a vizsgálat

                                y_now = Convert.ToByte(y_poz - 1);
                                x_now = Convert.ToByte(x_poz - 1);

                                //ide jön a vizsgálat

                                int counter = 0;
                                foreach (Properties_Blue itemY in properties_blue)
                                {
                                    if (itemY.Y_coordinate_now == y_now && itemY.X_coordinate_now == x_now)
                                    {
                                        string name = itemY.Name;
                                       int index = properties_blue.FindIndex(a => a.Name == name);
                                        if (item.Shot > 0)
                                        {
                                            item.Shot--;

                                            if (itemY.Shield > 0)
                                            {
                                                itemY.Shield--;
                                            }
                                            else
                                            {
                                                itemY.Life--;
                                            }

                                        }

                                        if (itemY.Life == 0)
                                        {

                                            //csak akkor írja felül a koordinátákat, hogyha az megfelel a feltételeknek
                                            itemY.Y_coordinate_now = 200;
                                            itemY.X_coordinate_now = 200;

                                            item.X_coordinate_now = x_now;  
                                            item.Y_coordinate_now = y_now;
                                            exists = false;
                                        }
                                    }


                                    if (itemY.Y_coordinate_now == y_now && itemY.X_coordinate_now == x_now)
                                    {
                                        counter++;
                                    }
                                }


                                if (counter == 0)  //tehát nincs a mezőn Y-on
                                {
                                        //csak akkor írja felül a koordinátákat, hogyha az megfelel a feltételeknek
                                    item.Y_coordinate_now = y_now;
                                    item.X_coordinate_now = x_now;
                                    exists = false;
                                }

                               

                            }

                           



                        }

                    }


                }
            }

            

          

            if (exists == false) //ha a mostani nem egyenlő a korábbival, akkor hívja meg a függvényt
            {
                ShowField(FillField(matrix, properties_blue, properties_yellow, y_pre, x_pre, group));

                Console.ForegroundColor = ConsoleColor.Cyan;   //ezeket majd a másiknál is meg kell hívni
                Console.SetCursorPosition(0, 60);
              
            }


        }

        //Kiesett bábúk megjelenítése
        
        static void ShowLost(List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow)
        {


            //Először megszámolom, hogy mennyi elem fog belekerülni a tömbbe, hogy annyi eleme legyen majd,
            //majd ezeket a bábúkat beleteszem a tömbbe

            int counter_b = 0;
            int counter_y = 0;

            /*                KÉK CSAPAT                    */


            foreach (Properties_Blue item in properties_blue)
            {
                if (item.Life == 0)
                {
                    counter_b++;

                }
            }

            string[] arr_blue = new string[counter_b];
            int c = 0;

            foreach (Properties_Blue item in properties_blue)
            {
                if (item.Life == 0)
                {
                    arr_blue[c] = item.Name;
                    c++;

                }
            }

            /*                SÁRGA CSAPAT                    */

            foreach (Properties_Yellow item in properties_yellow)
            {
                if (item.Life == 0)
                {
                    counter_y++;

                }
            }

            string[] arr_yellow = new string[counter_y];
            int cc = 0;

            foreach (Properties_Yellow item in properties_yellow)
            {
                if (item.Life == 0)
                {
                    arr_yellow[cc] = item.Name;
                    cc++;

                }
            }

            Console.SetCursorPosition(60, 5);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Kékek: {counter_y} pont\t Sárgák: {counter_b} pont");    //amennyi kiesett a másik csapatból az lesz a pont

            Console.SetCursorPosition(60, 7);

            Console.WriteLine("-------------------------------------");


            //Itt iratom ki a két csapat kiesett bábúit

            /*                KÉK CSAPAT                    */

            Console.SetCursorPosition(60, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Kék csapat kiesett bábúi:");
            for (int i = 0; i < arr_blue.Length; i++)
            {
                Console.SetCursorPosition(60, 11);
                Console.Write($"{arr_blue[i]}, ");
            }

           


            /*                SÁRGA CSAPAT                    */


            Console.SetCursorPosition(60, 13);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Sárga csapat kiesett bábúi:");
            for (int i = 0; i < arr_yellow.Length; i++)
            {
                Console.SetCursorPosition(60, 14);
                Console.Write($"{arr_yellow[i]}, ");
            }



        }

        static void Actions(List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow, string input)
        {
            
        }


        //This function is check the King's life, beacuse it's 0 the game is end
        static bool Winning(List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow)
        {
            bool lost = false;
            

            int b_counter = 0;
            int y_counter = 0;


            foreach (Properties_Blue item in properties_blue)
            {
                if(item.Life > 0)
                {
                    b_counter++;
                }
            }


            foreach (Properties_Yellow item in properties_yellow)
            {
                if (item.Life > 0)
                {
                    y_counter++;
                }
            }


            if (b_counter == 0 || y_counter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        static void AllProperties(List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Információ a bábúkról:");
            Console.WriteLine("Blue:");
            foreach (Properties_Blue item in properties_blue)
            {
                Console.WriteLine($"{item.Name}:  Life - {item.Life}, Sheild - {item.Shield}, Shot - {item.Shot}, Col - {item.Y_coordinate}, Row - {item.X_coordinate}, Lépés típusa - {item.Steps}, oszlopM - {item.X_coordinate_now}");
            }


            Console.WriteLine();


            Console.WriteLine("Yellow:");
            foreach (Properties_Yellow item in properties_yellow)
            {
                Console.WriteLine($"{item.Name}:  Life - {item.Life}, Sheild - {item.Shield}, Shot - {item.Shot}, Col - {item.Y_coordinate}, Row - {item.X_coordinate}, Lépés típusa - {item.Steps}");
            }
        }

        static string Winner(List<Properties_Blue> properties_blue, List<Properties_Yellow> properties_yellow)
        {
            int b_counter = 0;
            int y_counter = 0;
            string winner = null;

            foreach (Properties_Blue item in properties_blue)
            {
                if (item.Life > 0)
                {
                    b_counter++;
                }
            }



            foreach (Properties_Yellow item in properties_yellow)
            {
                if (item.Life > 0)
                {
                    y_counter++;
                }
            }

            if(b_counter == 0)
            {
                winner = "Sárga";
            }

            if (y_counter == 0)
            {
                winner = "Kék";
            }

            return winner;
        }
    }
}
