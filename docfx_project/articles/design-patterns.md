## Design Patterns
### What is / what is it for / where should I use it?
A set of building blocks and participants to implement Design Patterns of `GoF` and others.

> Design patterns make it easier to reuse successful designs and architectures.
> Expressing proven techniques as design patterns makes them more accessible to
> developers of new systems. Design patterns help you choose design alternatives
> that make a system reusable and avoid alternatives that compromise reusability.
> Design patterns can even improve the documentation and maintenance of existing
> systems by furnishing an explicit specification of class and object interactions
> and their underlying intent. Put simply, design patterns help a designer get
> a design "right" faster.
>
> *[Gamma, Helm, Johnson, Vlissides. Design Patterns: Elements of Reusable Object-Oriented Software. (1994)](https://www.amazon.com/Design-Patterns-Elements-Reusable-Object-Oriented/dp/0201633612)*
---
### Samples
Below are some examples of each `Design Pattern` contained in this package.

**`Specification Pattern`**

> A Specification Pattern implementation.
>
> > This implementation is based on the excellent course: Specification Pattern in C# Pluralsight by Vladimir Khorikov.
> >
> > Course: https://app.pluralsight.com/library/courses/csharp-specification-pattern/table-of-contents
> >
> > Source: https://github.com/vkhorikov/SpecPattern
> *Retrieved in July 2020.*
```

[Fact]
public void JobForSeniorEngineerSpecification_IsSatisfiedByJobApplicant_True()
{
    // Arrange
    var applicant = new JobApplicant("John", EngineeringLevel.SeniorEngineer, ProgrammingLanguage.JavaScript, 10);

    var spec = new JobForSeniorEngineerSpecification();

    // Act - Assert
    Assert.True(spec.IsSatisfiedBy(applicant));
}

[Fact]
public void JobForCompositeSpecification_IsSatisfiedByJobApplicant_True()
{
    // Arrange
    var applicant = new JobApplicant("Peter", EngineeringLevel.SeniorEngineer, ProgrammingLanguage.CSharp, 15);

    var spec = Specification<JobApplicant>.Default
        .And(new JobForLevelSpecification(EngineeringLevel.SoftwareEngineer))
        .Or(new JobForLevelSpecification(EngineeringLevel.SeniorEngineer))
        .Or(new JobForLevelSpecification(EngineeringLevel.StaffEngineer))
        .And(new JobForCSharpSpecification())
        .And(new MinimumYearsOfExperienceSpecification(10));

    // Act - Assert
    Assert.True(spec.IsSatisfiedBy(applicant));
}

[Fact]
public void GetJobsWithCompositeSpecification_CompositeSpecification_NotNull()
{
    // Arrange

    var spec = Specification<JobApplicant>.Default
        .And(new JobForLevelSpecification(EngineeringLevel.SoftwareEngineer))
        .Or(new JobForLevelSpecification(EngineeringLevel.SeniorEngineer))
        .Or(new JobForLevelSpecification(EngineeringLevel.StaffEngineer))
        .And(new JobForCSharpSpecification())
        .And(new MinimumYearsOfExperienceSpecification(10));

    var jobs = await _jobRepository.ListAsync(spec);

    // Act - Assert
    Assert.NotNull(jobs);
}
```
