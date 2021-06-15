![logo](docs/logo.png)

![CI / CD pipeline](https://github.com/maiconheck/krafted/workflows/CI%20/%20CD%20pipeline/badge.svg)

### A clean, simple and extensible, carefully `crafted` set of libraries for general purpose.
### Krafted provides a misc. of useful and reusable pieces of code, in order to increase the productivity. 🚀
### Is reliable, 100% documented and highly test code coverage!
---

## Fine-grained modularity

### Krafted consists in a set of fine-grained libraries targeting `netstandard2.1`:

> **`Krafted.Guards`**
>
> A set of Guard Clauses to validate method arguments, in order to enforce defensive programming practice.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.Guards)](https://www.nuget.org/packages/Krafted.Guards/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.Guards)](https://www.nuget.org/packages/Krafted.Guards/)

> **`Krafted.Extensions`**
>
> A set of extension methods for String, Collections, Guid and other types.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.Extensions)](https://www.nuget.org/packages/Krafted.Extensions/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.Extensions)](https://www.nuget.org/packages/Krafted.Extensions/)

> **`Krafted.ValueObjects`**
>
> A set of common Value Objects, with comparison and shallow copy operations, full tested and ready to use.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.ValueObjects)](https://www.nuget.org/packages/Krafted.ValueObjects/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.ValueObjects)](https://www.nuget.org/packages/Krafted.ValueObjects/)

> **`Krafted.DataAnnotations`**
>
> A set of DataAnnotations attributes for validations.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.DataAnnotations)](https://www.nuget.org/packages/Krafted.DataAnnotations/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.DataAnnotations)](https://www.nuget.org/packages/Krafted.DataAnnotations/)

> **`Krafted.UnitTests`**
>
> Extension methods to enhance the unit tests.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.UnitTests)](https://www.nuget.org/packages/Krafted.UnitTests/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.UnitTests)](https://www.nuget.org/packages/Krafted.UnitTests/)

> **`Krafted.Net`**
>
> A set of utility components for network operations.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.Net)](https://www.nuget.org/packages/Krafted.Net/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.Net)](https://www.nuget.org/packages/Krafted.Net/)

> **`Krafted.DesignPatterns`**
>
> A set of building blocks and participants to implement Design Patterns of GoF and others.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.DesignPatterns)](https://www.nuget.org/packages/Krafted.DesignPatterns/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.DesignPatterns)](https://www.nuget.org/packages/Krafted.DesignPatterns/)

## How to use (some examples):
[To see the complete API documentation check out the docs.]()

## Guard Clauses
> ### Provides a fluent API to apply `guard clauses` to validate method arguments, in order to enforce defensive programming practice.
```
public void Foo(Bar param1, Bar param2, string param3, string param4)
{
   Guard.Against
	  .Null(param1, nameof(param1))
	  .Null(param2, nameof(param2), customErrorMessage: "My custom error message")
	  .NullOrEmpty(param3, nameof(param3))
	  .NullOrWhiteSpace(param3, nameof(param3))
}
```
[See defensive programming](https://en.wikipedia.org/wiki/Defensive_programming)

[See guard clauses](http://wiki.c2.com/?GuardClause)

## Enumerable Extensions
>### Ordinal items
```
var itens = new string[] { "A", "B", "C", "D", "E" };
itens.Second(); // "B"
itens.Third();  // "C"
itens.Fourth(); // "D"
itens.Fifth();  // "E"
```

>### Contains all
```
var source = new int[] { 1, 2, 3 };
var values = new int[] { 1, 2, 3 };
source.ContainsAll(values); // true
```

## String Extensions
> ### Remove / Replace by pattern
```
const string EmailInput = @"the foo@demo.net e-mail";
const string EmailPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

EmailInput.Remove(EmailPattern); // "the  e-mail"
EmailInput.Replace(EmailPattern, "Replaced", RegexOptions.Compiled); // "the Replaced e-mail"
```
## Data Annotations
> ### NotEmptyCollection
```
public class ModelDummy
{
	[NotEmptyCollection]                // "At least one item is required."
	public IEnumerable<int> MyProperty1 { get; set; }

	[NotEmptyCollection(ErrorMessage = "Provide at least one item.")]
	public IEnumerable<int> MyProperty2 { get; set; }
}
```

## Unit Tests
>### DoesNotThrows
```
Assert.DoesNotThrows(() =>
{
	object param = new object();
	Guard.Against.Null(param, nameof(param));
});
```
