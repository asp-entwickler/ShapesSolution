using System;
using ShapesLib;

namespace ConsoleDialog
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintGreetingHeader();
			RunUserInteractionFlow();
		}

		private static void PrintGreetingHeader()
		{
			Console.WriteLine("---------------------------------------------------------------------");
			Console.WriteLine("Calcon Code Exercise");
			Console.WriteLine();
			Console.WriteLine("Calculates and prints information for a user-supplied shape and width");
			Console.WriteLine("---------------------------------------------------------------------");
		}

		private static void RunUserInteractionFlow()
		{
			while (true)
			{
				ProcessShapeArea();

				Console.Write("\nCalculate another area? Press 'Y' if yes. ");
				var userChoice = Console.ReadKey();
				if (userChoice.Key != ConsoleKey.Y)
				{
					Console.WriteLine("\n\nThe program complet. Press any key to exit.");
					Console.ReadKey();
					Environment.Exit(0);
				}
			}
		}

		private static void ProcessShapeArea()
		{
			Console.WriteLine("\n---------------------------------------------------------------------");
			Console.WriteLine("Do you want a square (1), circle (2), or equilateral triangle (3): ");

			var userInputShapeType = GetUserInputInt();
			ShapeTypeEnum type = (ShapeTypeEnum)userInputShapeType;

			Console.WriteLine("Enter the shape's primary dimension (width, radius, or base): ");

			var userInputShapeWith = GetUserInputInt();

			Shape s = new Shape(type, userInputShapeWith);

			Console.WriteLine();
			var area = s.CalculateArea();
			if (area == -1)
			{
				Console.WriteLine("Unknown type of shape. ");
			}
			else
			{
				Console.WriteLine("Shape properties:");
				Console.WriteLine("\tWidth: " + s.Width);
				Console.WriteLine("\tArea: " + area);
			}
		}

		private static int GetUserInputInt()
		{
			var rawUserInput = Console.ReadLine();
			int clearUserInput = 0;

			while (!Int32.TryParse(rawUserInput, out clearUserInput))
			{
				Console.WriteLine("Bad integer. Try again.");
				rawUserInput = Console.ReadLine();
			}

			return clearUserInput;
		}
	}
}
