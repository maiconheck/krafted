![logo](docs/logo.png)

![CI / CD pipeline](https://github.com/maiconheck/krafted/workflows/CI%20/%20CD%20pipeline/badge.svg)
![coverage](coverage-results/report/badge_shieldsio_linecoverage_brightgreen.svg)
![wip](https://camo.githubusercontent.com/a646be419b04e4d0f790613e408d79f991476fab/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f73746162696c6974792d776f726b5f696e5f70726f67726573732d6c69676874677265792e737667)

### A clean, simple and extensible, carefully `crafted` set of libraries for general purpose.
### Krafted provides a misc. of useful and reusable pieces of code, in order to increase the productivity. 🚀
### Is reliable, 100% documented and 100% test code coverage!
---

## Architecture

### Krafted consists in a set of fine-grained libraries targeting `netstandard2.1` (each of one is a nuget package):
- Krafted
- Krafted.Configuration
- Krafted.DesignPatterns
- Krafted.Net
- Krafted.UnitTests

### Each library contains a set of clean, documented and extensible APIs:
- Krafted
  - Krafted.Guards
  - Krafted.Extensions
  - Krafted.DataAnnotations
- Krafted.Configuration
- Krafted.DesignPatterns
  - Specification
  - Strategy
  - Factory Method
  - Abstract Factory
  - Notification
- Krafted.Net
  - NetworkInformation
- Krafted.UnitTests
  - Xunit

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
	[NotEmptyCollection]               // "At least one item is required."
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
