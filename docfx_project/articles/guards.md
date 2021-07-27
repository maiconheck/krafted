## Guard Clauses
### What is / what is it for?
Provides a fluent API to apply [guard clauses](http://wiki.c2.com/?GuardClause) to validate method arguments, in order to enforce [defensive programming](https://en.wikipedia.org/wiki/Defensive_programming) practice.

 ### Where should I use it?
 In the public interface of classes (i.e. `public methods`, including the constructor) and when get information from external files (e.g. `appsettings.json`).

---
### Samples
Below are some examples of using the `guard clauses` to protect the public APIs of some classes.

>***P.S.:** For simplicity, the examples only contain code snippets of the classes.
>You can see the full code by clicking on 'See full code'.*

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
See full code: [ListExtension.cs]()

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
See full code: [Question.cs]()

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

    private static Guard Validate(Name name, string shortDescription, Category category, Money price)
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
See full code: [Product.cs]()

---


In the example below, since we are getting values from `appsettings.json`, we are also validating them.
Because like the arguments of a public method, `appsettings.json` settings are data that we receive through external input, so we need to ensure that the data is valid so that we can use it with reliability.

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

        _host = config["Office365:Host"];
        _port = int.Parse(config["Office365:Port"], CultureInfo.InvariantCulture);
        _secureSocketOptions = (SecureSocketOptions)int.Parse(config["Office365:SecureSocketOptions"], CultureInfo.InvariantCulture);
        _fromName = config["Office365:FromName"];
        _fromEmail = config["Office365:FromEmail"];
        _userName = config["Office365:UserName"];
        _password = config["Office365:Password"];

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
See full code: [EmailService.cs]()

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
See full code: [Email.cs]()

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
See full code: [Money.cs]()

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
See full code: [GuardExtension.cs]()

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
See full code: [Quiz.cs]()

```
public sealed class RegisterQuestionHandler : IRequestHandler<RegisterQuestionCommand, ICommandResult<RegisterQuestionViewModel>>
{
    ...

    public async Task<ICommandResult<RegisterQuestionViewModel>> Handle(RegisterQuestionCommand request, CancellationToken cancellationToken)
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
 See full code: [SaveQuestionCommand.cs]()

---

### All available `guard clauses`:
- [Empty]()
- [False]()
- [False with predicate]()
- [True]()
- [True with predicate]()
- [Length exactLength]()
- [Length between minLength and maxLength]()
- [LessThan]()
- [GreaterThan]()
- [Match]()
- [NotMatch]()
- [MaxLength]()
- [MinLength]()
- [NotEmpty]()
- [NotExists]()
- [Null]()
- [NullOrEmpty]()
- [NullOrWhiteSpace]()
- [NullOrWhiteSpace with message]()
- [Positive]()
- [Zero]()
- [ZeroOrLess]()
- [Negative]()
- [InvalidEmail]()
- [InvalidNif]()
