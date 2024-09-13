using System.Text.RegularExpressions;
using Utilities.TW.TaxId.Validator.Interfaces;

namespace Utilities.TW.TaxId.Validator.Services;

public partial class TaxIdValidationService : ITaxIdValidationService
{
	public bool IsValid(string? taxId)
	{
		ArgumentNullException.ThrowIfNull(taxId);

		if (!IsLegalFormat(taxId))
			return false;

		return Validate(taxId);
	}

	static bool Validate(string data)
	{
		int[] digits = data.Select(c => c - '0').ToArray();
		int[] multipliers = [1, 2, 1, 2, 1, 2, 4, 1];
		var factors = new List<int>();

		for (int i = 0; i < multipliers.Length; i++)
			factors.Add(SumOfDigits(digits[i] * multipliers[i]));

		if (factors.Sum() % 5 == 0)
			return true;

		if (digits[6] == 7)
		{
			factors[6] = 1;
			var sum = factors.Sum();

			if (sum % 5 == 0 || (sum - 1) % 5 == 0)
				return true;
		}

		return false;
	}

	static int SumOfDigits(int number) =>
		(number < 10) ? number : (number % 10) + 1;

	static bool IsLegalFormat(string data) =>
		TaxIdRegex().IsMatch(data);

	[GeneratedRegex(@"^\d{8}$")]
	private static partial Regex TaxIdRegex();
}
