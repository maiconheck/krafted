## Guard Clauses
### What is / what is it for?
Provides a fluent API to apply [guard clauses](http://wiki.c2.com/?GuardClause) to validate method arguments, in order to enforce [defensive programming](https://en.wikipedia.org/wiki/Defensive_programming) practice.

 ### Where should I use it?
 In the public interface of classes (i.e. `public methods`, including the constructor) and when get information from external files (e.g. `appsettings.json`).

---
### Samples
Below are some examples of the `guard clauses` to protect the public APIs of some classes.

> **P.S.:** For simplicity, the examples only contain code snippets of the classes.
> You can see the full code by clicking on 'See full code'.

```
public static class ListExtension
{
    public static void Move<T>(this IList<T> list, int oldIndex, int newIndex)
    {
        Guard.Against
            .Empty(list, nameof(list))
            .Negative(oldIndex, nameof(oldIndex))
            .Negative(newIndex, nameof(newIndex));

        var item = list[oldIndex];
        list.RemoveAt(oldIndex);
        list.Insert(newIndex, item);
    }

    ...
}
```
See full code: [ListExtension.cs](https://github.com/maiconheck/krafted/blob/master/src/Krafted/Krafted.Extensions/ListExtension.cs)

```
public class Question : EntityBase, ISortable
{
    private readonly List<Answer> _answers = new List<Answer>();

    public Question(string name, IList<Answer> answers)
    {
        Guard.Against
            .Length(5, 500, name, nameof(name))
            .NullOrWhiteSpace(name, nameof(name))
            .Empty(answers, nameof(answers))
            .False(_ => answers.Any(a => a.IsCorrect), "At least one answer must be correct.");

        Name = name;
        _answers = answers.ToList();
    }

    ...
}
```
See full code: [Question.cs](https://gist.github.com/maiconheck/440449696a54157ca34cdc77608df388)

---

In the example below the `guard clauses` are being reused between the `constructor` and the `EditBasicInfo` method, each of which contains specific validations in addition to those present in the `Validate` method:
```
public class Product : EntityBase, IAggregateRoot
{
    public Product(
        ProductType productType,
        Name name,
        string shortDescription,
        Category category,
        Money price,
        ProductCardCover cardCover)
    {
        Validate(name, shortDescription, category, price)
                .Null(cardCover, nameof(cardCover))
                .NotExists<ProductType>(productType);

        ProductType = productType;
        Name = (Name)name.Value.ToLower(CultureInfo.InvariantCulture);
        ShortDescription = shortDescription;
        Category = category;
        Price = price;
        CardCover = cardCover;
        Status = ProductStatus.Draft;
        WarrantyType = WarrantyType.Warranty7Days;
        CreatingDate = DateTime.Now;
    }

    public void SetRating(int rating)
    {
        Guard.Against
            .ZeroOrLess(rating, nameof(rating))
            .GreaterThan(5, rating, nameof(rating));

        Rating = rating;
    }

    public void EditBasicInfo(
            Name name,
            string shortDescription,
            Category category,
            Money price,
            ProductCardCover cardCover,
            ProductStatus status,
            WarrantyType warranty,
            bool expires,
            int? expireInDays)
        {
            Validate(name, shortDescription, category, price)
              .NotExists<ProductStatus>(status)
              .Null(cardCover, nameof(cardCover))
              .NotExists<WarrantyType>(warranty);

            Name = name;
            ShortDescription = shortDescription;
            Category = category;
            Price = price;
            CardCover = cardCover;
            Status = status;
            WarrantyType = warranty;
            Expires = expires;
            ExpireInDays = expireInDays;
        }

    private static Guard Validate(
        Name name,
        string shortDescription,
        Category category,
        Money price)
    {
        return Guard.Against
            .Null(name, nameof(name))
            .NullOrWhiteSpace(shortDescription, nameof(shortDescription))
            .Length(5, 200, shortDescription, nameof(shortDescription))
            .Null(category, nameof(category))
            .Null(price, nameof(price));
    }

    ...
}
```
See full code: [Product.cs](https://gist.github.com/maiconheck/d9f09c6786018c6eb5c151e3bb964f9c)

---


In the example below, since we are getting values from `appsettings.json`, we are also validating them.
Because like the arguments of a public method, `appsettings.json` settings are data that we receive through external input, so we need to ensure that the data is valid, so we can use it with reliability.

```
public class EmailService : IEmailService
{
    private readonly string _host;
    private readonly int _port;
    private readonly SecureSocketOptions _secureSocketOptions;
    private readonly string _fromName;
    private readonly string _fromEmail;
    private readonly string _userName;
    private readonly string _password;

    public EmailService(IConfiguration config)
    {
        Guard.Against.Null(config, nameof(config));

        _host = config["SendGrid:Host"];
        _port = int.Parse(config["SendGrid:Port"]);
        _secureSocketOptions = (SecureSocketOptions)int.Parse(config["SendGrid:SecureSocketOptions"]);
        _fromName = config["SendGrid:FromName"];
        _fromEmail = config["SendGrid:FromEmail"];
        _userName = config["SendGrid:UserName"];
        _password = config["SendGrid:Password"];

        Guard.Against
            .NullOrWhiteSpace(_host, nameof(_host))
            .ZeroOrLess(_port, nameof(_port))
            .NotExists<SecureSocketOptions>(_secureSocketOptions)
            .NullOrWhiteSpace(_fromName, nameof(_fromName))
            .InvalidEmail(_fromEmail)
            .NullOrWhiteSpace(_userName, nameof(_userName))
            .NullOrWhiteSpace(_password, nameof(_password));
    }

    public async Task SendEmailAsync(MailAddress to, string subject, string htmlMessage)
    {
        Guard.Against
            .Null(to, nameof(to))
            .NullOrWhiteSpace(subject, nameof(subject))
            .NullOrWhiteSpace(htmlMessage, nameof(htmlMessage));

        ...
    }

    ...
}
```

---

```
public sealed class Email : ValueObject<string>
{
    public Email(string value)
    {
        Guard.Against.InvalidEmail(value);
        Value = value;
    }

    ...
}
```
See full code: [Email.cs](https://github.com/maiconheck/krafted/blob/master/src/Krafted/Krafted.ValueObjects/Email.cs)

```
public sealed class Money : ValueObject<decimal>
{
    public Money(decimal value)
    {
        Guard.Against.Negative(value, nameof(value));
        Value = value;
    }

    ...
}
```
See full code: [Money.cs](https://github.com/maiconheck/krafted/blob/master/src/Krafted/Krafted.ValueObjects/Money.cs)

---

### Finally, you can create your own `guard clauses` by extending the `Guard` class:
```
namespace Krafted.Guards
{
    public static class GuardExtension
    {
        public static Guard Errors(this Guard guard, IReadOnlyList<Error> errors)
        {
            Guard.Against
                .Null(guard, nameof(guard))
                .Null(errors, nameof(errors));

            if (errors.Any())
            {
                throw new InvalidOperationException(errors.ToMessage());
            }

            return guard;
        }

        public static Guard Errors(this Guard guard, ErrorContext context)
        {
            Guard.Against
                .Null(guard, nameof(guard))
                .Null(context, nameof(context));

            if (context.HasErrors)
            {
                throw new InvalidOperationException(context.Errors.ToMessage());
            }

            return guard;
        }
    }
}
```
See full code: [GuardExtension.cs](https://gist.github.com/maiconheck/6248e870f60e1e4ad9ec64831334392a)

---

### And even combine with `notification pattern` and `CanExecute pattern` to use in your commands:

```
public class Quiz
{
    ...

    private readonly List<Question> _questions = new List<Question>();

    public IReadOnlyList<Question> Questions => _questions.ToList();

    public ErrorContext CanAddQuestion(Question question)
    {
        return ErrorContext.Default
            .AddIf(_ => question.Answers.Count > 6, new Error("Enter max of 6 answers."))
            .AddIf(_ => !question.Answers.Any(a => a.IsCorrect), new Error("Enter almost one correct answer."));
    }

    public void AddQuestion(Question question)
    {
        Guard.Against.Null(question, nameof(question));
        Questions.Load();

        var context = CanAddQuestion(question);
        Guard.Against.Errors(context);

        _questions.Add(question);
    }

    ...
}
```
See full code: [Quiz.cs](https://gist.github.com/maiconheck/616b2174b948eb0c61b7dff75c1d253b)

```
public sealed class RegisterQuestionHandler :
    IRequestHandler<RegisterQuestionCommand, ICommandResult<RegisterQuestionViewModel>>
{
    ...

    public async Task<ICommandResult<RegisterQuestionViewModel>> Handle(
        RegisterQuestionCommand request,
        CancellationToken cancellationToken)
    {
        ...

        var question = new Question(request.Name, request.Answers);

        var context = quiz.CanAddQuestion(question);
        if (context.HasErrors)
        {
            return _commandResult.Errors(context.Errors);
        }

        quiz.AddQuestion(question);

        await _quizRepository.Save(quiz);
        await _quizRepository.UnitOfWork.CommitAsync();

        return _commandResult.Content(_mapper.Map<RegisterQuestionViewModel>(quiz));
    }
}

```

---

### All available `guard clauses`:
- [Empty](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Empty__1_System_Collections_Generic_IEnumerable___0__System_String_)
- [False](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_False_System_Boolean_System_String_)
- [False with predicate](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_False_System_Predicate_System_Boolean__System_String_)
- [True](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_True_System_Boolean_System_String_)
- [True with predicate](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_True_System_Predicate_System_Boolean__System_String_)
- [Length exactLength](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Length_System_UInt32_System_String_System_String_)
- [Length between minLength and maxLength](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Length_System_UInt32_System_UInt32_System_String_System_String_)
- [LessThan](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_LessThan__1___0___0_System_String_)
- [GreaterThan](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_GreaterThan__1___0___0_System_String_)
- [Match](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Match_System_String_System_String_System_String_System_Text_RegularExpressions_RegexOptions_)
- [NotMatch](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_NotMatch_System_String_System_String_System_String_System_Text_RegularExpressions_RegexOptions_)
- [MaxLength](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_MaxLength_System_UInt32_System_String_System_String_)
- [MinLength](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_MinLength_System_UInt32_System_String_System_String_)
- [NotEmpty](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_NotEmpty__1_System_Collections_Generic_IEnumerable___0__System_String_)
- [NotExists](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_NotExists__1___0_)
- [Null](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Null__1___0_System_String_)
- [NullOrEmpty](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_NullOrEmpty_System_String_System_String_)
- [NullOrWhiteSpace](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_NullOrWhiteSpace_System_String_System_String_)
- [NullOrWhiteSpace with message](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_NullOrWhiteSpace_System_String_System_String_System_String_)
- [Positive](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Positive__1___0_System_String_)
- [Zero](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Zero__1___0_System_String_)
- [ZeroOrLess](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_ZeroOrLess__1___0_System_String_)
- [Negative](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_Negative__1___0_System_String_)
- [InvalidEmail](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_InvalidEmail_System_String_)
- [InvalidNif](https://maiconheck.github.io/krafted/api/Krafted.Guards.Guard.html#Krafted_Guards_Guard_InvalidNif_System_String_)
