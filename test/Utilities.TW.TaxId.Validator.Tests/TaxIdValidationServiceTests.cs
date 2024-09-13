using Utilities.TW.TaxId.Validator.Services;
using Xunit.Abstractions;

namespace Utilities.TW.TaxId.Validator.Tests;

public class TaxIdValidationServiceTests(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	[Fact]
	public void NullData_ShouldThrow()
	{
		// Given
		var service = new TaxIdValidationService();

		// When
		var ex = Assert.Throws<ArgumentNullException>(() => service.IsValid(null));

		// Then
		Assert.NotNull(ex);
	}

	[Theory]
	[InlineData("22555003")]
	[InlineData("04541302")]
	[InlineData("22099131")]
	[InlineData("47217677")]
	[InlineData("23525730")]
	[InlineData("12461415")]
	[InlineData("27124010")]
	[InlineData("54545508")]
	public void LegalTaxId_ShouldSucceed(string data)
	{
		// Given
		var service = new TaxIdValidationService();

		// When
		var result = service.IsValid(data);

		// Then
		Assert.True(result);
	}

	[Theory]
	[InlineData("12345678")]
	[InlineData("98765432")]
	[InlineData("09876543")]
	[InlineData("01234578")]
	[InlineData("99990000")]
	[InlineData("999900")]
	[InlineData("abc1231")]
	[InlineData("99990000123")]
	public void IllegalTaxId_ShouldFailed(string data)
	{
		// Given
		var service = new TaxIdValidationService();

		// When
		var result = service.IsValid(data);

		// Then
		Assert.False(result);
	}
}
