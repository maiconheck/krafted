## Extension Methods
### What is / what is it for?
A set of extension methods for String, Collections, Guid and other types.

---
### Samples
Below are some examples of using `extension methods`.

### Enumerable
Provides extension methods to `IEnumerable<T>.`

**`ContainsAll`**

> Verifies if the enumerable contains all the values:
```
[Fact]
public void ContainsAll_Itens_True()
{
	var source = new int[] { 1, 2, 3 };
	var values = new int[] { 1, 2, 3 };
	Assert.True(source.ContainsAll(values));

	source = new int[] { 1, 2, 3 };
	values = new int[] { 1, 2 };
	Assert.True(source.ContainsAll(values));
}

[Fact]
public void ContainsAll_Itens_False()
{
	var source = new int[] { 1, 2, 3 };
	var values = new int[] { 1, 2, 3, 4 };
	Assert.False(source.ContainsAll(values));

	source = new int[] { 1, 2, 3 };
	values = new int[] { 4 };
	Assert.False(source.ContainsAll(values));
}
```

**`Second`, `Third`, `Fourth`, `Fifth`**
> Like the items.First(), returns the element of a sequence by their ordinal number.
```
[Fact]
public void Ordinal_Itens_Ok()
{
	var itens1 = new int[] { 1, 2, 3, 4, 5 };
	Assert.Equal(2, itens1.Second());
	Assert.Equal(3, itens1.Third());
	Assert.Equal(4, itens1.Fourth());
	Assert.Equal(5, itens1.Fifth());

	var itens2 = new string[] { "A", "B", "C", "D", "E" };
	Assert.Equal("B", itens2.Second());
	Assert.Equal("C", itens2.Third());
	Assert.Equal("D", itens2.Fourth());
	Assert.Equal("E", itens2.Fifth());
}
```

**`Empty`**
> Determines whether a sequence not contains any elements (a cleaner alternative to `!items.Any()`).
```
[Fact]
public void Empty_SourceContainsElements_False()
{
	var source = new int[] { 1, 2, 3, 4, 5 };
	Assert.False(source.Empty());
}

[Fact]
public void Empty_SourceNotContainsElements_True()
{
	var source = new int[] { };
	Assert.True(source.Empty());
}
```

### Guid
Provides extension methods to `Guid`.

**`IsEmpty`**
> Checks whether a `Guid` is a `Guid.Empty`.

```
[Fact]
public void IsEmpty_EmptyGuid_True()
{
	var emptyGuid1 = Guid.Empty;
	Assert.True(emptyGuid1.IsEmpty());

	var emptyGuid2 = new Guid("00000000-0000-0000-0000-000000000000");
	Assert.True(emptyGuid2.IsEmpty());
}

[Fact]
public void IsEmpty_NotEmptyGuid_False()
{
	var notEmptyGuid = new Guid("5c246e85-c1af-4654-be86-81da9ab808bf");
	Assert.False(notEmptyGuid.IsEmpty());
}
```

### HttpResponseMessage
Provides extension methods to `HttpResponseMessage`.

**`EnsureContentType`**
> Throws an exception if the `System.Net.Http.HttpResponseMessage.Headers.ContentType` property for
> the HTTP response is different of `defaultContentType` argument,
> whose default value is `"application/json; charset=utf-8"`.

```
[Fact]
public void EnsureContentType_DefaultContentType_DoesNotThrowsException()
{
	var response1 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.UTF8, "application/json") };
	Assert.DoesNotThrows(() => response1.EnsureContentType());

	var response2 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.ASCII, "text/html") };
	Assert.DoesNotThrows(() => response2.EnsureContentType("text/html; charset=us-ascii"));
}

[Theory]
[InlineData("ASCII", "application/json")]
[InlineData("UTF-8", "text/html")]
public void EnsureContentType_NotUtf8ApplicationJson_ThrowsException(string encoding, string mediaType)
{
	var response = new HttpResponseMessage(HttpStatusCode.OK)
	{
		Content = new StringContent(string.Empty, Encoding.GetEncoding(encoding), mediaType)
	};

	Assert.Throws<HttpRequestException>(() => response.EnsureContentType());
}
```

**`DeserializeAsync`**
> Deserializes the `HttpResponseMessage` into a `T`.

```
public class ViewModelDummy
{
	public int Age { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
}

[Fact]
public async Task DeserializeAsync_Poco_PocoDeserialized()
{
	// Arrange
	const string json = @"{
							""age"": 35,
							""name"": ""Peter"",
							""enabled"": true
						  }";

	// Act
	var response = new HttpResponseMessage
	{
		Content = new StringContent(json, Encoding.UTF8, "application/json")
	};

	var result = await response.DeserializeAsync<ViewModelDummy>();

	// Assert
	Assert.Equal(35, result.Age);
	Assert.Equal("Peter", result.Name);
	Assert.True(result.Enabled);
}
```

### List
Provides extension methods to `IList<T>`.

**`Move`**
> Moves an item from a specified old index to a specified new index.

```
[Theory]
[InlineData(2, 0, new int[] { 3, 1, 2 })]
[InlineData(2, 1, new int[] { 1, 3, 2 })]
[InlineData(0, 2, new int[] { 2, 3, 1 })]
[InlineData(0, 1, new int[] { 2, 1, 3 })]
[InlineData(1, 0, new int[] { 2, 1, 3 })]
public void Move_NewOrder_Reordered(int oldIndex, int newIndex, int[] orderExpected)
{
	// Arrange
	var source = new List<int> { 1, 2, 3 };

	// Act
	source.Move(oldIndex, newIndex);

	// Assert
	Assert.Equal(orderExpected[0], source[0]);
	Assert.Equal(orderExpected[1], source[1]);
	Assert.Equal(orderExpected[2], source[2]);
}
```

### String
Provides extension methods to `string`.

**`Replace`**
> In a specified input string, replaces all strings that match a specified regular
> expression with a specified replacement string.

```
[Fact]
public void Replace_InputCorrectPattern_ReplacementReplaced()
{
    Assert.Equal("ReplacedView all titlesReplaced", _linkInput.Replace(_linkPattern, "Replaced", RegexOptions.Compiled));
    Assert.Equal("the Replaced e-mail", _emailInput.Replace(_emailPattern, "Replaced", RegexOptions.Compiled));
    Assert.Equal("Replaced is the hour", _hourInput.Replace(_hourPattern, "Replaced", RegexOptions.Compiled));
}

[Fact]
public void Replace_InputIncorrectPattern_ReplacementNotReplaced()
{
    Assert.Equal(
        @"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>",
        _linkInput.Replace(_hourPattern, "Replaced", RegexOptions.Compiled));

    Assert.Equal("the foo@demo.net e-mail", _emailInput.Replace(@"\/\*[\s\S]*?\*\/|\/\/.*", "Replaced", RegexOptions.Compiled));
    Assert.Equal("14:00 is the hour", _hourInput.Replace(@"\/\*[\s\S]*?\*\/|\/\/.*", "Replaced", RegexOptions.Compiled));
}
```

**`Remove`**
> In a specified input string, removes all strings that match a specified regular
> expression with a specified replacement string.
```
[Fact]
        public void Remove_InputCorrectPattern_Removed()
        {
            Assert.Equal("View all titles", _linkInput.Remove(_linkPattern));
            Assert.Equal("the  e-mail", _emailInput.Remove(_emailPattern));
            Assert.Equal(" is the hour", _hourInput.Remove(_hourPattern));
        }

        [Fact]
        public void Remove_InputIncorrectPattern_NotRemoved()
        {
            Assert.Equal(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>", _linkInput.Remove(_hourPattern));
            Assert.Equal("the foo@demo.net e-mail", _emailInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
            Assert.Equal("14:00 is the hour", _hourInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
        }
```

**`Format`**
> Replaces the format items in a string with the string representations of corresponding
> objects in a specified array. A parameter supplies culture-specific formatting information.

```
[Fact]
public void Format_Input_Formated()
{
    string input = "Replace {0} {1} in this {2}".Format("some", "words", "phrase");
    Assert.Equal("Replace some words in this phrase", input);
}
```

**`PascalCaseToSnakeCase`**
> Converts a specified PascalCase string to its Snake_Case representation (that is. underscore separation).

```
[Theory]
[InlineData("EscolheUmTrabalhoDeQueGostes,ENãoTerásQueTrabalharNemUmDiaNaTuaVida.", "Escolhe_Um_Trabalho_De_Que_Gostes,_E_Não_Terás_Que_Trabalhar_Nem_Um_Dia_Na_Tua_Vida.")] // - Confúcio
[InlineData("EuNãoFalhei.SóDescobri10MilCaminhosQueNãoEramOCerto", "Eu_Não_Falhei._Só_Descobri10_Mil_Caminhos_Que_Não_Eram_O_Certo")] // - Thomas Edison
[InlineData("OSucessoNormalmenteVemParaQuemEstáOcupadoDemaisParaProcurarPorEle", "O_Sucesso_Normalmente_Vem_Para_Quem_Está_Ocupado_Demais_Para_Procurar_Por_Ele")] // – Henry David Thoreau
public void PascalCaseToSnakeCase_InputPascalCase_OutputSnakeCase(string input, string expectedSnakeCase)
{
    Assert.Equal(expectedSnakeCase, input.PascalCaseToSnakeCase());
}
```

**`EncodeToBase64String`**
> Converts an string to its equivalent encoded with base-64.

```
[Fact]
public void EncodeToBase64String_Input_Base64StringEncoded()
{
    string plainString = "A clean, simple and extensible, carefully crafted set of libraries for general purpose.";
    string base64String = plainString.EncodeToBase64String();

    Assert.Equal("QSBjbGVhbiwgc2ltcGxlIGFuZCBleHRlbnNpYmxlLCBjYXJlZnVsbHkgY3JhZnRlZCBzZXQgb2YgbGlicmFyaWVzIGZvciBnZW5lcmFsIHB1cnBvc2Uu", base64String);
}
```

**`DecodeFromBase64String`**
> Converts a base-64 string to its equivalent decoded string.

```
[Fact]
public void DecodeFromBase64String_Input_Base64StringDecoded()
{
    string base64String = "QSBjbGVhbiwgc2ltcGxlIGFuZCBleHRlbnNpYmxlLCBjYXJlZnVsbHkgY3JhZnRlZCBzZXQgb2YgbGlicmFyaWVzIGZvciBnZW5lcmFsIHB1cnBvc2Uu";
    string plainString = base64String.DecodeFromBase64String();

    Assert.Equal("A clean, simple and extensible, carefully crafted set of libraries for general purpose.", plainString);
}
```

**`ToSlug`**
> Converts a phrase to its slug representation.

```
[Theory]
[InlineData("Escolhe um trabalho de que gostes, e não terás que trabalhar nem um dia na tua vida.", "escolhe-um-trabalho-de-que-gostes-e-nao-teras-que-trabalhar-nem-um-dia-na-tua-vida")] // - Confúcio
[InlineData("A vida vai ficando cada vez mais dura perto do topo", "a-vida-vai-ficando-cada-vez-mais-dura-perto-do-topo")] // - Nietzsche
[InlineData("O sucesso normalmente vem para quem está ocupado demais para procurar por ele", "o-sucesso-normalmente-vem-para-quem-esta-ocupado-demais-para-procurar-por-ele")] // – Henry David Thoreau
public void ToSlug_InputMaxLength300_Slug(string input, string expectedSlug)
{
    Assert.Equal(expectedSlug, input.ToSlug(maxLength: 300));
}

[Theory]
[InlineData("Escolhe um trabalho de que gostes, e não terás que trabalhar nem um dia na tua vida.", "escolhe-um-trabalho-de-que-gostes-e-nao-teras-que-trabalhar")] // - Confúcio
[InlineData("Eu não falhei. Só descobri 10 mil caminhos que não eram o certo", "eu-nao-falhei-so-descobri-10-mil-caminhos-que-nao-eram-o-cer")] // - Thomas Edison
[InlineData("O sucesso normalmente vem para quem está ocupado demais para procurar por ele", "o-sucesso-normalmente-vem-para-quem-esta-ocupado-demais-para")] // – Henry David Thoreau
public void ToSlug_InputLengthDefault60_Slug(string input, string expectedSlug)
{
    Assert.Equal(expectedSlug, input.ToSlug());
}
```
