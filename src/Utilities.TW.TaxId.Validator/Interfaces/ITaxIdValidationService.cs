namespace Utilities.TW.TaxId.Validator.Interfaces;

/// <summary>
/// Represents a tax ID validation service.
/// </summary>
public interface ITaxIdValidationService
{
	/// <summary>
	/// Determines whether the specified tax ID is valid.
	/// </summary>
	/// <param name="taxId">The tax ID to validate.</param>
	/// <returns><c>true</c> if the tax ID is valid; otherwise, <c>false</c>.</returns>
	bool IsValid(string? taxId);
}
