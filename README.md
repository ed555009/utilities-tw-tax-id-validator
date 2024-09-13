# Utilities.TW.TaxId.Validator

[![GitHub](https://img.shields.io/github/license/ed555009/utilities-tw-tax-id-validator)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/utilities-tw-tax-id-validator?branchName=main)
[![Nuget](https://img.shields.io/nuget/v/Utilities.TW.TaxId.Validator)](https://www.nuget.org/packages/Utilities.TW.TaxId.Validator)

![Coverage](https://sonarcloud.io/api/project_badges/measure?project=utilities-tw-tax-id-validator&metric=coverage)
![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=utilities-tw-tax-id-validator&metric=alert_status)
![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=utilities-tw-tax-id-validator&metric=reliability_rating)
![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=utilities-tw-tax-id-validator&metric=security_rating)
![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=utilities-tw-tax-id-validator&metric=vulnerabilities)

## Installation

```bash
dotnet add package Utilities.TW.TaxId.Validator
```

## Using service

### Register services

```csharp
using Utilities.TW.TaxId.Validator.Interfaces;
using Utilities.TW.TaxId.Validator.Services;

ConfigureServices(IServiceCollection services)
{
	// this injects as SINGLETON
	services.AddSingleton<ITaxIdValidationService, TaxIdValidationService>();
}
```

### Using service

```csharp
using Utilities.TW.TaxId.Validator.Interfaces;

public class MyProcess
{
	private readonly ITaxIdValidationService _taxIdValidationService;

	public MyProcess(ITaxIdValidationService taxIdValidationService) =>
		_taxIdValidationService = taxIdValidationService;

	public bool ValidateTaxId() =>
		_aesService.IsValid("your-tax-id");
}
```
