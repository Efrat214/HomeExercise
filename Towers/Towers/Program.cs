internal class Program
{
    private static void Main(string[] args)
    {

        int selectOption = 0, height = 0, width = 0, choose = 0;
        while (selectOption != 3)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Rectangular tower");
            Console.WriteLine("2. Triangular tower");
            Console.WriteLine("3. Exit");
            selectOption = int.Parse(Console.ReadLine());
            if (selectOption < 1 || selectOption > 3)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }
            switch (selectOption)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("enter the height of the tower at least 2");
                        height = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the width of the tower");
                        width = int.Parse(Console.ReadLine());
                    } while (height < 2 || width < 0);
                    if (height == width)
                        Console.WriteLine("the tower is square and the area is: " + height * width);
                    else
                    {
                        if (Math.Abs(height - width) >= 5)
                            Console.WriteLine("the tower is Rectangular and the area is : " + height * width);
                        else
                            Console.WriteLine("tower is Rectangular and the perimeter: " + (height + width) * 2);
                    }

                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("enter the height of the tower at least 2");
                        height = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the width of the tower");
                        width = int.Parse(Console.ReadLine());
                    } while (height < 2 || width < 0);
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. calculate the perimeter");
                    Console.WriteLine("2. print the Triangular tower");
                    choose = int.Parse(Console.ReadLine());
                    if (choose < 1 || choose > 3)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }
                    switch (choose)
                    {
                        case 1:
                            //משפט פיתגורס
                            double equalSize = Math.Sqrt(Math.Pow(width / 2, 2) + Math.Pow(height, 2));
                            Console.WriteLine("the perimeter of the Triangular tower is: " + (equalSize * 2 + width));
                            break;
                        case 2:
                            if (width % 2 == 0 || (height * 2) < width)
                                Console.WriteLine("cant print the triangle tower");
                            else
                            {
                                printTower(height, width);
                            }
                            break;
                    }
                    break;
                case 3:
                    break;
            }
        }
    }
    public static void printTower(int height, int width)
    {
        bool flag = false;
        int allLines = 0, remind = 0;
        if (width == 3)
        {
            flag = true;
            remind = 0;
            allLines = 1;
        }
        //numOfMiddleLines:height - 2,allOddNumbersInTheMiddle:((width+1) /2-2
        if (!flag)
        {
            allLines = (height - 2) / (((width + 1) / 2) - 2);
            remind = (height - 2) % (((width + 1) / 2) - 2);
        }
        //מטרת משתנה זה להדפיס על לגובה המגדל
        int rows = 0;
        for (int i = 1, j = (width / 2); i <= width; i += 2, j--)
        {
            if (i == 1)
            {
                for (int k = 0; k < j; k++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                Console.WriteLine();
                rows++;
            }
            else
            {
                ////הדפסה בשורות העליונות את השארית+מס' השורות כמו שאר השורות
                if (i == 3)
                {
                    for (int h = 0; h < allLines + remind && rows <= height; h++)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 0; k < i; k++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                        rows++;
                    }
                }
                else
                {
                    for (int h = 0; h < allLines && rows < height; h++)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 0; k < i; k++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                        rows++;
                    }
                }
            }
        }

    }
}