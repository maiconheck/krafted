## DataAnnotations
### What is / what is it for?
A set of [DataAnnotations](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1) attributes for validations.

### Where should I use it?
DataAnnotations provides validation attributes that are applied declaratively to a ViewModel class or ViewModel property in order to validate
the data.

---
### Samples
Below are some examples of each `DataAnnotations` contained in this package.

**`NifAttribute`**

> Validates whether the specified `nif` is valid.
> NIF means "Número de Identificação Fiscal", a.k.a "Número de Contribuinte", identifies a taxpayer entity in Portugal, whether it is a company or an individual.
```
public class NifViewModelDummy
{
    [Nif]
    public string MyProperty1 { get; set; }

    [Nif(ErrorMessage = "The nif should be valid.")]
    public string MyProperty2 { get; set; }
}
```

**`EmailAddressRegexAttribute`**

> Validates whether the specified <c>email address</c> is valid using regular expression.
```
public class EmailModelDummy
{
    [EmailAddressRegex]
    public string MyProperty1 { get; set; }

    [EmailAddressRegex(ErrorMessage = "The e-mail should be valid.")]
    public string MyProperty2 { get; set; }
}
```

**`MinOneAttribute`**

> Specifies that the value is at minimum one (that is, positive).
```
public class MinOneIntModelDummy
{
    [MinOne]
    public int MyProperty1 { get; set; }

    [MinOne(ErrorMessage = "The number should be positive.")]
    public int MyProperty2 { get; set; }
}

public class MinOneLongModelDummy
{
    [MinOne]
    public long MyProperty1 { get; set; }

    [MinOne(ErrorMessage = "The number should be positive.")]
    public long MyProperty2 { get; set; }
}
```

**`NotEmptyCollectionAttribute`**

> Specifies that at least one item is required in the collection.
```
public class NotEmptyCollectionModelDummy
{
    [NotEmptyCollection]
    public IEnumerable<int> MyProperty1 { get; set; }

    [NotEmptyCollection(ErrorMessage = "Provide at least one item.")]
    public IEnumerable<int> MyProperty2 { get; set; }
}
```

---

### Validation is automatic, but in some cases, you might want to manually validate your ViewModel.
### In this case, you can use the `ModelValidator` helper class:

```
[Fact]
public void IsValid_Empty_False()
{
    var model = new NotEmptyCollectionModelDummy();
    var (isValid, validationResults) = ModelValidator.Validate(model);

    Assert.False(isValid);
    Assert.Equal("At least one item is required.", validationResults[0].ErrorMessage);
    Assert.Equal("Provide at least one item.", validationResults[1].ErrorMessage);
}

[Theory]
[InlineData(new int[] { 1 })]
[InlineData(new int[] { 1, 2 })]
[InlineData(new int[] { 1, 2, 3 })]
public void IsValid_NotEmpty_True(int[] items)
{
    var model = new NotEmptyCollectionModelDummy
    {
        MyProperty1 = items,
        MyProperty2 = items
    };

    var (isValid, validationResults) = ModelValidator.Validate(model);

    Assert.True(isValid);
    Assert.Empty(validationResults);
}
```

