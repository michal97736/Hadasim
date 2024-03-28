using System;

namespace HadasimTwitterTower
{
	internal class Program
	{
		//טיפול במקרה שנבחר מלבן
		public static void RectangleCase(int widthRectangle, int heightRectangle)
		{
			Console.WriteLine("Enter the width of the rectangle tower:");
			widthRectangle = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the height of the rectangle tower:");
			heightRectangle = int.Parse(Console.ReadLine());

			while (heightRectangle < 2)
			{
				Console.WriteLine("The tower's height must be greater than or equal to two, Please enter again");
				heightRectangle = int.Parse(Console.ReadLine());
			}
			//אם המלבן הוא ריבוע
			if (widthRectangle == heightRectangle)
				Console.WriteLine($"This tower is a square. Area: {widthRectangle * heightRectangle}");
			//אם ההפרש גדול מחמש
			else if (Math.Abs(widthRectangle - heightRectangle) > 5)
				Console.WriteLine($"Rectangle Tower area: {widthRectangle * heightRectangle}");
			else
				Console.WriteLine($"Rectangle Tower Perimeter: {(widthRectangle + heightRectangle) * 2}");


		}

		//בנית המחרוזת לפי count
		public static string CalcStr(string str, int count)
		{
			string newstr = "";
			for (int i = 0; i < count; i++)
			{
				newstr += str;
			}
			return newstr;
		}

		//טיפול במקרה שנבחר משולש
		public static void TrianglCase(int widthTriangle, int heightTriangle)
		{
			double calf;//שוק המשולש
			int choiceForTriangle = 0;
			int copyLine = 1;
			int midHeight;//מספר שורות באמצע
			int midOddNum;//מספר הספרות האיזוגי שצריך להשתמש
			int count = 1;
			int three = 0;
			int leftCopyLine = 0;
			string str = "";
			Console.WriteLine("Enter the base of the triangle tower:");
			widthTriangle = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the height of the triangle tower:");
			heightTriangle = int.Parse(Console.ReadLine());
			while (heightTriangle < 2)
			{
				Console.WriteLine("The tower's height must be greater than or equal to two, Please enter again");
				heightTriangle = int.Parse(Console.ReadLine());
			}
			Console.WriteLine("Choose an option:");
			Console.WriteLine("1. Triangle Perimeter ");
			Console.WriteLine("2. Print the Triangle Tower");
			choiceForTriangle = int.Parse(Console.ReadLine());
			switch (choiceForTriangle)
			{

				case 1:
					calf = Math.Pow(widthTriangle / 2, 2) + Math.Pow(heightTriangle, 2);
					calf = Math.Sqrt(calf);
					Console.WriteLine($"Triangle Tower Perimeter: {(calf * 2) + widthTriangle}");
					break;
				case 2:
					if (widthTriangle % 2 == 0 || widthTriangle > heightTriangle * 2)
						Console.WriteLine("There is not option to print the Triangle");
					else
					{
						midHeight = (heightTriangle) - 2;
						midOddNum = (widthTriangle / 2) - 1;

						if (midOddNum < midHeight)
						{
							copyLine = midOddNum > 0 ? midHeight / midOddNum : midHeight;//כמה שורות כל מספר
							leftCopyLine = midOddNum > 0 ? midHeight % midOddNum : 0;//שארית להוסיף לספרה 3
						}
						if (widthTriangle == 3)
							copyLine += 1;
						while (count <= widthTriangle)
						{
							if (count == 3)
								three = leftCopyLine;

							for (int i = 0; i < copyLine + three; i++)
							{
								int space = (widthTriangle - count) / 2;///הרווחים לפני ואחרי
								str = CalcStr(" ", space);
								str += CalcStr("*", count);
								str += CalcStr(" ", space);
								Console.WriteLine(str);

								if ((count == 1 && widthTriangle != 3) || count == widthTriangle)
									break;

							}
							three = 0;
							count += 2;
						}

					}
					break;

			}
		}


		static void Main(string[] args)
		{
			int choice = 0, widthRectangle = 0, heightRectangle = 0, widthTriangle = 0, heightTriangle = 0;

			while (choice != 3)
			{
				Console.WriteLine("Choose an option:");
				Console.WriteLine("1. Rectangle Tower");
				Console.WriteLine("2. Triangle Tower");
				Console.WriteLine("3. Exit");

				choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						RectangleCase(widthRectangle, heightRectangle);
						break;
					case 2:
						TrianglCase(widthTriangle, heightTriangle);
						break;
					case 3:
						Console.WriteLine("Exiting the program.");
						break;
					default:
						Console.WriteLine("Invalid choice. Please choose again.");
						break;
				}
			}
		}
	}
}