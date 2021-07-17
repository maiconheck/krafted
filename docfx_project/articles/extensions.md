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
