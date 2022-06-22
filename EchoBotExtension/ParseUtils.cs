namespace EchoBotExtension
{
	public static class ParseUtils
	{
		private static readonly char[] Operations = {'+', '-', '*', '/', '%'};

		public static bool TryParseArithmeticOperation(
			string source, out int num1, out int num2, out int result, out char operation)
		{
			num1 = num2 = result = 0;
			operation = ' ';
			
			// Find operator in string and send substring before and after operator to int.TryParse()
			var operationIndex = source.IndexOfAny(Operations);
			if (operationIndex == -1)
			{
				return false;
			}

			var s1 = source.Substring(0, operationIndex);
			var s2 = source.Substring(operationIndex + 1);
			operation = source[operationIndex];

			if (int.TryParse(s1, out num1) && int.TryParse(s2, out num2))
			{
				try
				{
					result = GetResult(num1, num2, operation);
					
					return true;
				}
				catch
				{
					return false;
				}
			}

			return false;
		}
		
		private static int GetResult(int num1, int num2, char operation)
		{
			return operation switch
			{
				'+' => num1 + num2,
				'-' => num1 - num2,
				'*' => num1 * num2,
				'/' => num1 / num2,
				'%' => num1 % num2,
				_ => 0
			};
		}
	}
}