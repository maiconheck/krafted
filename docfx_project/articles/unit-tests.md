## Unit Tests
### What is / what is it for?
Extension methods, DataAnnotations and Test Doubles to enhance the unit tests.

### Where should I use it?
In your unit tests.

---

## Samples
Below are some examples.

### Xunit

**`DoesNotThrows`**

> Verifies that no exception was thrown.
```
[Fact]
public void GuardAgainstEmpty_NotEmpty_DoesNotThrows()
{
    Assert.DoesNotThrows(() =>
    {
        var myCollection1 = new List<int> { 1 };
        Guard.Against.Empty(myCollection1, nameof(myCollection1));

        var myCollection2 = new List<string> { "A" };
        Guard.Against.Empty(myCollection1, nameof(myCollection2));
    });
}
```

**`UseCultureAttribute`**

> A attribute to replace the CurrentCulture with another culture.
>
> > This class was obtained from the Xunit samples.
> > Source: https://raw.githubusercontent.com/xunit/samples.xunit/main/UseCulture/UseCultureAttribute.cs
> >
> > *Retrieved in November 2020.*
```
[Theory]
[InlineData("it-IT")]
[InlineData("ja-JP")]
[InlineData("nb-NO")]
public void CultureIsChangedWithinTest(string culture)
{
    var originalCulture = Thread.CurrentThread.CurrentCulture;
    var attr = new UseCultureAttribute(culture);

    attr.Before(null);

    Assert.Equal(attr.Culture, Thread.CurrentThread.CurrentCulture);

    attr.After(null);

    Assert.Equal(originalCulture, Thread.CurrentThread.CurrentCulture);
}
```

---

### Test Double

**`HttpClientMockFactory`**

> Provides a Factory Method to create a `mock` for `HttpClient`.
```
[Fact]
public void New_ValidParameters_ProperInstantiated()
{
    var httpClient = HttpClientMockFactory.New(string.Empty, HttpStatusCode.OK);
    Assert.NotNull(httpClient);
}

[Fact]
public async Task Get_ResponseAndHttpStatus200OK_ResponseAndHttpStatus200OKGet()
{
    // Arrange
    const string response = @"
{
  ""age"": 35,
  ""name"": ""Maicon Heck"",
  ""enabled"": true
}";

    var httpClient = HttpClientMockFactory.New(response, HttpStatusCode.OK);

    // Act
    var getResponse = await httpClient.GetAsync("/api/nothing");
    var getResponseDeserialized = await getResponse.DeserializeAsync<ViewModelDummy>();

    // Assert
    Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
    Assert.Equal(35, getResponseDeserialized.Age);
    Assert.Equal("Maicon Heck", getResponseDeserialized.Name);
    Assert.True(getResponseDeserialized.Enabled);
}
```
