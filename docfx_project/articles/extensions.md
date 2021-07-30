## Extension Methods
### What is / what is it for?
A set of extension methods for String, Collections, Guid and other types.

---
### Samples
Below are some examples of using the `extension methods`.

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
