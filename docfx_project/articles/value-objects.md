## Value Objects
### What is / what is it for?
A set of common [Value Objects](https://martinfowler.com/bliki/ValueObject.html), with comparison and shallow copy operations.

> Value types that measure, quantify, or describe things are easier to create, test, use, optimize, and maintain.
> - It measures, quantifies, or describes a thing in the domain.
> - It can be maintained as immutable.
> - It models a conceptual whole by composing related attributes as an integral unit.
> - It is completely replaceable when the measurement or description changes.
> - It can be compared with others using Value equality.
> - It supplies its collaborators with Side-Effect-Free Behavior [Evans].
>
> *[Vernon, Vaughn. Implementing Domain-Driven Design. (2013)](https://www.amazon.com/Implementing-Domain-Driven-Design-Vaughn-Vernon-dp-0321834577/dp/0321834577)*

 ### Where should I use it?
 Value Objects are a DDD (Domain-Driven Design) building block used in the domain modeling.

It is great to avoid [primitive obsession](https://refactoring.guru/smells/primitive-obsession) code smell and enrich the [domain model](https://medium.com/cwi-software/domain-driven-design-do-in%C3%ADcio-ao-c%C3%B3digo-569b23cb3d47).

In this library, each Value Object already contains:
- The validation for its value. So when you use, for example, `Nif` or `Email`, you don't have to
worrying about creating a validation for them, thus avoiding separating the logic from the data (e.g. `ValidationHelper`), which would lead to creating anemic classes.
- `Equals` method and `==` and `!=` operators.
- `GetCopy` method to creates a shallow copy of the Value Object.
- `ToString` method to returns the string representation of the Value Object.
- `explicit operator` to performs an explicit conversion from the literal value to the Value Object, for example:
  ```
  Email email = (Email)"foo@bar.com";
  ```
- A `Factory Method` to create a new instance of the Value Object in a convenient way, for example:
  ```
  Email email = Email.NewEmail("foo@bar.com");
  ```
- These are the common members for all Value Objects. Some Value Objects contain other members depending on their type, for example, `Money` has increment and decrement operators, and the `IntegralPart` property:
  ```
  var money = Money.NewMoney(10.25);
  money += 5;
  money -= 2;

  money.Value; // 13.25
  money.IntegralPart; // 13
  ```
---
### Samples
Below are some examples of each `Value Object` contained in this package.

**`Nif`**

> Represents an NIF value object.
> NIF means "Número de Identificação Fiscal", a.k.a "Número de Contribuinte",
> identifies a taxpayer entity in Portugal, whether it is a company or an individual.

**`Email`**

> Represents an email value object.
```
public sealed class BillingData
{
	public BillingData(string name, Email email, Nif nif)
	{
		Guard.Against
			.NullOrWhiteSpace(name, nameof(name))
			.Null(email, nameof(email))
			.Null(nif, nameof(nif));

		Name = name;
		Email = email;
		Nif = nif;
	}

	public string Name { get; }

	public Email Email { get; }

	public Nif Nif { get; }
}
```

**`Money`**

> Represents an money value object.
```
public class OrderItem : Entity
{
    ...

    public Money TotalPrice => Money.NewMoney(Product.Price * Quantity);

	public Money Total => TotalPrice + KindOfPackage.Price;

	...
}

public sealed class Order : Entity, IAggregateRoot
{
	...

	public Money Subtotal => (Money)_orderItems.Sum(i => i.Total);

	public Money Total => Subtotal + DeliveryFee;

	...
}
```

**`Url`**

> Represents an URL (Uniform Resource Locator) value object.
```
public class LessonVideo : Lesson
{
	...

	public Url Link { get; private set; };

	public TimeSpan Duration { get; private set; }

	public VideoType VideoType { get; private set; }

	...
}
```

---

### You can create your own Value Objects by inheriting from the `ValueObject<T>` class:
```
public class Name : ValueObject<string>
{
    public Name(string value)
    {
        Guard.Against
            .NullOrWhiteSpace(value, nameof(value))
            .Length(1, 60, value, nameof(value));

        Value = value;
    }

    // Required for ORM mapping
    private Name()
    {
    }

    public static explicit operator Name(string value) => new Name(value);

    public static Name NewName(string value) => new Name(value);
}
```

```
public sealed class Slug : ValueObject<string>
{
    public Slug(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, nameof(value));
        Value = value.ToSlug();
    }

    // Required for ORM mapping
    private Slug()
    {
    }

    public static explicit operator Slug(string value) => new Slug(value);

    public static Slug NewSlug(string value) => new Slug(value);
}
```

### And for yours Value Objects with multiple property, you can create your own Value Objects by inheriting from the `ValueObject` class, and implements `GetEqualityComponents`:

```
public class Address : ValueObject
{
    public Address(string street, string city, string zipCode)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
    }

    public string Street { get; }

    public string City { get; }

    public string ZipCode { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return ZipCode;
    }
}
```

---

### `Entity Framework` mapping samples
Mapping Value Objects with one value (`Money`, `Name`) and with multiple values (`Address`, `GroupLink`, `Payment`):
```
public sealed class OrderMap : IEntityTypeConfiguration<Order>
{
    ...

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(p => p.Subtotal)
            .HasConversion(p => p.Value, p => new Money(p))
            .IsRequired();

        builder.Property(p => p.Total)
            .HasConversion(p => p.Value, p => new Money(p))
            .IsRequired();

        builder.OwnsOne(o => o.Address, a =>
	    {
		   a.WithOwner();

		   a.Property(p => p.Street)
			.HasColumnName("Address_Street")
			.IsRequired(false);

		   a.Property(p => p.City)
			.HasColumnName("Address_City")
			.IsRequired(false);

           a.Property(p => p.ZipCode)
			.HasColumnName("Address_ZipCode")
			.IsRequired(false);
	    });
    }
}
```

```
public class CourseMap : IEntityTypeConfiguration<Course>
{
	public void Configure(EntityTypeBuilder<Course> builder)
	{
		...

		builder.Property(p => p.Name)
			.HasConversion(p => p.Value, p => (Name)default(Name)!.CreateInstance(p)!)
			.HasMaxLength(60)
			.IsRequired();

		builder.OwnsOne(o => o.GroupLink, a =>
		{
			a.WithOwner();

			a.Property(p => p.LinkWhatsApp)
			 .HasConversion(p => p.Value, p => new Url(p))
			 .HasColumnType("varchar(300)")
			 .HasColumnName("GroupLink_Whatsapp")
			 .IsRequired(false);

			a.Property(p => p.LinkTelegram)
			 .HasConversion(e => e.Value, p => new Url(p))
			 .HasColumnType("varchar(300)")
			 .HasColumnName("GroupLink_Telegram")
			 .IsRequired(false);

			a.Property(p => p.LinkSlack)
			 .HasConversion(p => p.Value, p => new Url(p))
			 .HasColumnType("varchar(300)")
			 .HasColumnName("GroupLink_Slack")
			 .IsRequired(false);
		});

		builder.OwnsOne(o => o.Payment, a =>
	    {
		   a.WithOwner();

		   a.Property(p => p.AccessType)
			.HasColumnName("Payment_AccessType")
			.IsRequired(false);

		   a.Property(p => p.PaymentMethod)
			.HasColumnName("Payment_PaymentMethod")
			.IsRequired(false);

		   a.Property(p => p.Price)
			.HasConversion(p => p.Value, p => new Money(p))
			.HasColumnName("Payment_Price")
			.IsRequired(false);
	   });
	}
}
```

If you are using `lazy loading`, checkout [this sample]().
