![Krafted Guards](https://raw.githubusercontent.com/maiconheck/krafted-guards/master/docfx_project/images/main/logo.png)

# Krafted Guards

[![CI / CD pipeline](https://github.com/maiconheck/krafted-guards/actions/workflows/ci-cd-pipeline.yml/badge.svg)](https://github.com/maiconheck/krafted-guards/actions/workflows/ci-cd-pipeline.yml)
[![NuGet](https://img.shields.io/nuget/v/Krafted.Guards.svg)](https://www.nuget.org/packages/Krafted.Guards/)
[![NuGet downloads](https://img.shields.io/nuget/dt/Krafted.Guards.svg)](https://www.nuget.org/packages/Krafted.Guards/)
[![License: MIT](https://img.shields.io/github/license/maiconheck/krafted-guards)](https://github.com/maiconheck/krafted-guards/blob/master/LICENSE)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=maiconheck_krafted-guards&metric=alert_status)](https://sonarcloud.io/dashboard?id=maiconheck_krafted-guards)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=maiconheck_krafted-guards&metric=coverage)](https://sonarcloud.io/dashboard?id=maiconheck_krafted-guards)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=maiconheck_krafted-guards&metric=code_smells)](https://sonarcloud.io/dashboard?id=maiconheck_krafted-guards)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=maiconheck_krafted-guards&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=maiconheck_krafted-guards)

### Fluent guard clauses for argument validation and precondition enforcement in .NET

Krafted Guards is a .NET guard clause library with a fluent API for argument validation and precondition enforcement, making it easier to apply defensive programming and the fail-fast principle.

Enforce preconditions where they apply, fail fast when a method contract is violated, and replace repetitive `if`/`throw` blocks with declarations that read like intent.

## Why Krafted Guards?

Consider an invoice operation that requires a non-empty customer ID, an 8–30-character invoice number, at least one line, and a defined status.

The examples below enforce the same preconditions and use the same exception types for corresponding failures:

### Manual guard clauses

```csharp
if (customerId == Guid.Empty)
    throw new ArgumentException("Customer ID cannot be empty.", nameof(customerId));

if (number is null)
    throw new ArgumentNullException(nameof(number));

if (string.IsNullOrWhiteSpace(number))
    throw new ArgumentException("Invoice number cannot be empty or contain only whitespace.", nameof(number));

if (number.Length is < 8 or > 30)
    throw new ArgumentOutOfRangeException(nameof(number), "Invoice number must contain between 8 and 30 characters.");

if (lines is null)
    throw new ArgumentNullException(nameof(lines));

if (lines.Count == 0)
    throw new ArgumentException("Invoice must contain at least one line.", nameof(lines));

if (!Enum.IsDefined(status))
    throw new ArgumentException("Invoice status is not defined.", nameof(status));
```

### Built-in .NET throw helpers

```csharp
if (customerId == Guid.Empty)
    throw new ArgumentException("Customer ID cannot be empty.", nameof(customerId));

ArgumentException.ThrowIfNullOrWhiteSpace(number);
ArgumentOutOfRangeException.ThrowIfLessThan(number.Length, 8, nameof(number));
ArgumentOutOfRangeException.ThrowIfGreaterThan(number.Length, 30, nameof(number));
ArgumentNullException.ThrowIfNull(lines);

if (lines.Count == 0)
    throw new ArgumentException("Invoice must contain at least one line.", nameof(lines));

if (!Enum.IsDefined(status))
    throw new ArgumentException("Invoice status is not defined.", nameof(status));
```

### Fluent guard clauses with Krafted Guards

```csharp
Guard.Against
    .Empty(customerId)
    .Null(number)
    .EmptyOrWhiteSpace(number)
    .Length(8, 30, number)
    .Null(lines)
    .NotAny(lines)
    .NotExists<InvoiceStatus>(status);
```

**Krafted Guards** dramatically reduces the boilerplate required for argument validation, while reusable extensions encapsulate shared validation contracts—keeping preconditions consistent, readable, and maintainable as the codebase grows. Its core benefits include:

- **Fluent by design** — compose multiple preconditions in a single readable chain.
- **Comprehensive validation API** — validate nulls, text, collections, numbers, GUIDs, enums, predicates, regular expressions, email addresses, tax identification numbers, and other common validation scenarios.
- **Customizable failures** — override the default exception message when domain context matters.
- **Extensible at the right scope** — reuse class-specific guards locally or add reusable guard clauses through extension methods.
- **Small binary footprint** — a 28 KB assembly with no external NuGet package dependencies.

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/Krafted.Guards/):

```shell
dotnet add package Krafted.Guards
```

> *This package is compatible with .NET 8, .NET 9, and .NET 10.*

Then import the namespace:

```csharp
using Krafted.Guards;
```

## Quick start

Start a chain with `Guard.Against` and describe the conditions that make a call invalid:

```csharp
public class Invoice
{
    public Invoice(Guid customerId, string billingEmail, string number, IReadOnlyCollection<InvoiceLine> lines)
    {
        Guard.Against
            .Empty(customerId)
            .Null(billingEmail)
            .InvalidEmail(billingEmail)
            .NullOrWhiteSpace(number)
            .Length(8, 30, number)
            .Null(lines)
            .NotAny(lines);

        CustomerId = customerId;
        BillingEmail = billingEmail;
        Number = number;
        Lines = lines;
        Status = InvoiceStatus.PendingApproval;
    }

    public Guid CustomerId { get; }
    public string BillingEmail { get; }
    public string Number { get; }
    public IReadOnlyCollection<InvoiceLine> Lines { get; }
    public InvoiceStatus Status { get; private set; }
    public decimal? ApprovedAmount { get; private set; }
    public string? ApprovalCode { get; private set; }
    public PaymentPriority? Priority { get; private set; }

    public void ApproveForPayment(decimal approvedAmount, string approvalCode, PaymentPriority priority)
    {
        Guard.Against
            .ZeroOrLess(approvedAmount)
            .NullOrWhiteSpace(approvalCode)
            .NotMatch(approvalCode, @"^APR-\d{8}$")
            .NotExists<PaymentPriority>(priority);

        ApprovedAmount = approvedAmount;
        ApprovalCode = approvalCode;
        Priority = priority;
        Status = InvoiceStatus.ApprovedForPayment;
    }

    // Other members omitted for brevity.
}
```

If a guard fails, it stops the chain immediately and throws a clear exception that explains the problem and identifies the invalid argument.

For example, an empty `customerId` produces `Guid cannot be empty. (Parameter 'customerId')`.

Each guard method validates an argument against a specific invalid condition. In this example:

- `Empty(customerId)` rejects an empty GUID.
- `Null(billingEmail)` and `InvalidEmail(billingEmail)` require a non-null email address and reject empty, whitespace-only, or incorrectly formatted values.
- `NullOrWhiteSpace(number)` and `Length(8, 30, number)` require an invoice number between 8 and 30 characters.
- `Null(lines)` and `NotAny(lines)` require a non-null collection containing at least one invoice line.
- `ZeroOrLess(approvedAmount)` rejects a zero or negative approved amount.
- `NullOrWhiteSpace(approvalCode)` and `NotMatch(approvalCode, @"^APR-\d{8}$")` require an approval code such as `APR-12345678`.
- `NotExists<PaymentPriority>(priority)` rejects an undefined `PaymentPriority` value.

### Custom error messages

Every built-in guard accepts an optional custom message that overrides its default exception message:

```csharp
public void ChangePostalCode(string postalCode)
{
    var message = $"Invalid postal code: {postalCode}.";

    Guard.Against
        .NullOrWhiteSpace(postalCode, message)
        .NotMatch(postalCode, @"^\d{8}$", message: message);

    PostalCode = postalCode;
}
```

If either guard fails, the custom message replaces its default exception message while preserving the original argument name. For example, a `postalCode` value of `"123"` produces `Invalid postal code: 123. (Parameter 'postalCode')`.

### Validating optional parameters

Except for `Null`, `NullOrEmpty`, and `NullOrWhiteSpace`, every other built-in guard method skips validation when the value being validated is `null`. This allows optional parameters to be validated without explicit null checks: **only non-null values are evaluated**.

```csharp
public class Appointment
{
    // Other members omitted for brevity.

    public void Reschedule(AppointmentPeriod period, string? reason = null, string? referenceCode = null)
    {
        Guard.Against
            .Null(period)
            .EmptyOrWhiteSpace(reason)
            .MaxLength(500, reason)
            .EmptyOrWhiteSpace(referenceCode)
            .MaxLength(50, referenceCode);

        Period = period;
        RescheduleReason = reason;
        ReferenceCode = referenceCode;
    }
}
```

In the `Reschedule` operation, `period` is required, while `reason` and `referenceCode` are optional. If an optional argument is omitted—or explicitly passed as `null`—the corresponding validations are skipped.

When provided, `reason` and `referenceCode` cannot be empty or whitespace-only; `reason` cannot exceed 500 characters, and `referenceCode` cannot exceed 50 characters.

## Built-in guard clauses

| Category | Guard clauses |
|---|---|
| Null values | `Null` |
| Text | `NullOrEmpty`, `NullOrWhiteSpace`, `EmptyOrWhiteSpace`, `Length`, `MinLength`, `MaxLength` |
| Collections | `NotAny`, `Any` |
| Numbers | `Negative`, `Positive`, `Zero`, `ZeroOrLess`, `LessThan`, `GreaterThan` |
| GUIDs | `Empty`, `NotEmpty` |
| Enums | `NotExists<TEnum>` |
| Boolean values and predicates | `True`, `False` |
| Regular expressions | `Match`, `NotMatch` |
| Email addresses | `InvalidEmail` |
| Tax identification numbers | `InvalidCpf`, `InvalidCnpj`, `InvalidNif` |

See the [API reference](https://maiconheck.github.io/krafted-guards/api/) for complete signatures, overloads, and default messages.

## Extensibility

Krafted Guards supports two ways to reuse validation logic:

### 1. Reuse class-specific guards locally

When a set of preconditions belongs to a single class, extract it into a local method that returns `Guard`. The caller can reuse the shared checks and continue the chain with operation-specific guards:

```csharp
public sealed class Employee
{
    // Other members omitted for brevity.

    public Employee(string name, string phoneNumber, string email, EmployeeRole role, string? notes)
    {
        ThrowIfProfileInvalid(name, phoneNumber, notes)
            .NullOrWhiteSpace(email)
            .InvalidEmail(email)
            .NotExists<EmployeeRole>(role);

        // Initialize the employee...
    }

    public void UpdateProfile(string name, string phoneNumber, string? notes)
    {
        ThrowIfProfileInvalid(name, phoneNumber, notes);

        // Update the profile...
    }

    private static Guard ThrowIfProfileInvalid(string name, string phoneNumber, string? notes)
    {
        return Guard.Against
            .NullOrWhiteSpace(name)
            .NullOrWhiteSpace(phoneNumber)
            .NotMatch(phoneNumber, @"^\+?[1-9]\d{7,14}$")
            .EmptyOrWhiteSpace(notes);
    }
}
```

Here, the constructor adds `email` and `role` validations to the shared `ThrowIfProfileInvalid` validation method, while `UpdateProfile` reuses only the validations relevant to that operation.

### 2. Create reusable guard clause extensions

When multiple guard clauses define a cohesive contract, encapsulate them in a well-named extension method on `Guard`. This lets callers express intent while centralizing the policy and preserving fluent chaining.

Each extension should return the same `Guard` instance, allowing custom and built-in guard clauses to remain in the same fluent chain.

The extensions below centralize an application's image-upload and resizing policies:

```csharp
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Krafted.Guards;
using Microsoft.AspNetCore.Http;

public static class GuardExtensions
{
    private const long MaximumImageFileSize = 10 * 1024 * 1024;
    private const int MaximumImageDimension = 4096;

    public static Guard InvalidImageUploadRequest(this Guard guard, [NotNull] IFormFile? file, [CallerArgumentExpression("file")] string? parameterName = null)
    {
        return guard
            .Null(file, parameterName: parameterName)
            .ZeroOrLess(file.Length)
            .GreaterThan(MaximumImageFileSize, file.Length, message: "Image file size cannot exceed 10 MB.")
            .NullOrWhiteSpace(file.FileName)
            .MaxLength(255, file.FileName)
            .Match(file.FileName, @"[\\/:*?""<>|\x00-\x1F]", message: "File name contains unsupported characters.")
            .Match(file.FileName, @"[. ]$", message: "File name cannot end with a dot or space.")
            .NotMatch(file.FileName, @"\.(jpe?g|png|webp)$", message: "File name must use a supported image extension.")
            .NullOrWhiteSpace(file.ContentType)
            .NotMatch(file.ContentType, @"^image/(jpeg|png|webp)$", message: "Only JPEG, PNG, and WebP images are supported.");
    }

    public static Guard InvalidResizeOptions(this Guard guard, [NotNull] ResizeOptions? options, [CallerArgumentExpression("options")] string? parameterName = null)
    {
        return guard
            .Null(options, parameterName: parameterName)
            .ZeroOrLess(options.Width, message: "Resize width must be greater than zero.")
            .GreaterThan(MaximumImageDimension, options.Width, message: $"Resize width cannot exceed {MaximumImageDimension} pixels.")
            .ZeroOrLess(options.Height, message: "Resize height must be greater than zero.")
            .GreaterThan(MaximumImageDimension, options.Height, message: $"Resize height cannot exceed {MaximumImageDimension} pixels.")
            .LessThan(1, options.Quality, message: "Image quality must be between 1 and 100.")
            .GreaterThan(100, options.Quality, message: "Image quality must be between 1 and 100.")
            .NotExists<ResizeMode>(options.Mode, message: "Resize mode is not supported.");
    }
}
```

`InvalidImageUploadRequest` and `InvalidResizeOptions` are reusable and express complete contracts instead of exposing their individual validation rules.

Custom guards remain chainable with built-in guards:

```csharp
public async Task UploadImageAsync(IFormFile file, ResizeOptions resizeOptions, ImageCategory category)
{
    Guard.Against
        .InvalidImageUploadRequest(file)
        .InvalidResizeOptions(resizeOptions)
        .NotExists<ImageCategory>(category);

    await _imageStorage.UploadAsync(file.OpenReadStream(), file.FileName, resizeOptions, category);
}
```

Detailed policies stay cohesive and reusable while the caller remains clean and focused on the operation.

## Documentation

- [API reference](https://maiconheck.github.io/krafted-guards/api/Krafted.Guards.Guard.html)
- [NuGet package](https://www.nuget.org/packages/Krafted.Guards/)
- [Release notes](https://github.com/maiconheck/krafted-guards/releases)

## Contributing

Contributions that strengthen argument validation, precondition enforcement, documentation, or the quality of the existing guards are welcome.

For questions, bug reports, or feature requests, open an [issue](https://github.com/maiconheck/krafted-guards/issues/new). Discuss new guard clauses and public API changes before implementation. For fixes and agreed improvements, submit a [pull request](https://github.com/maiconheck/krafted-guards/pulls).

## License

Krafted Guards is available under the [MIT License](https://github.com/maiconheck/krafted-guards/blob/master/LICENSE).
