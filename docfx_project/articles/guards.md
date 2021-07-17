## Guard Clauses
> ### Provides a fluent API to apply `guard clauses` to validate method arguments, in order to enforce defensive programming practice.
[See defensive programming](https://en.wikipedia.org/wiki/Defensive_programming)

[See guard clauses](http://wiki.c2.com/?GuardClause)
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
