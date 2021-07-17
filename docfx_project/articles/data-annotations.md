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
