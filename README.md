![logo](docfx_project/images/main/logo.png)

![CI / CD pipeline](https://github.com/maiconheck/krafted/workflows/CI%20/%20CD%20pipeline/badge.svg)

# What is Krafted?
A clean, decoupled and extensible, carefully crafted set of libraries for general purpose.

Krafted provides a toolkit of useful and reusable pieces of code, in order to increase your productivity. 🚀

Is reliable, 100% documented and highly test code coverage. ✅

# Why another library?
There are some very good toolkit libraries, however, there is a problem with many toolkits (especially the general purpose ones):

As they get new features, naturally,
they get more dependencies on other 3rd packages, and when we install these toolkits, we end up relying on a number of nuget packages that we don't need, which causes unnecessary coupling, and in the worst case dependency conflict.

Well, this problem doesn't just happen with toolkits. Remember `System.Web.dll`?
This assembly, over time, became a large monolith that contained several ASP.net (full framework) modules.

In fact, one of the problems that were solved by the .NET team through the new .NET Core / ASP.net Core, was precisely the granularization of the modules, thus solving problems such as the old `System.Web.dll` monolith.

When looking at the architecture and fine-grained distribution strategy of the `.NET Core` and `ASP.net Core` packages, I came up with the idea of creating a toolkit with this fine-grained strategy, providing high decoupling, independent evolution, and long life to the modules.

Another way to solve this problem would not be to create several toolkits, each one with a specific purpose?

In fact, and if you look at every Krafted package, you'll see that it's just that. Each package is independent and has a very specific purpose.
However, I wanted to keep all packages under the same umbrella of the Krafted project, because in addition to being high-decoupled, Krafted has other quality criteria, and all it's packages are consistent with them:

- 100% documented (docs, API e IntelliSense).
- Highly test code coverage.
- Targeting `netstandard2.0` ([see all supported platforms](https://dotnet.microsoft.com/platform/dotnet-standard)).
- Almost all packages have zero nuget dependencies.
- Code quality analyzed by [.NET Analyzers](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/overview) and [StyleCop Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers).

# Getting started
Check out the [**docs**](https://maiconheck.github.io/krafted/articles/guards.html) to get some samples of how Krafted can help you.

To get more details, check out the [**API reference**](https://maiconheck.github.io/krafted/api/).

# Features / where can I get?
As explained above, Krafted consists in a set of fine-grained modules, each one is delivered as a nuget package (targeting `netstandard2.0`).

So get the packages according to the features you want:

> **`Krafted.Guards`**
>
> A set of Guard Clauses to validate method arguments, in order to enforce defensive programming practice.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.Guards)](https://www.nuget.org/packages/Krafted.Guards/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.Guards)](https://www.nuget.org/packages/Krafted.Guards/)

> **`Krafted.Extensions`**
>
> A set of extension methods for String, Collections, Guid and other types.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.Extensions)](https://www.nuget.org/packages/Krafted.Extensions/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.Extensions)](https://www.nuget.org/packages/Krafted.Extensions/)

> **`Krafted.ValueObjects`**
>
> A set of common Value Objects, with comparison and shallow copy operations.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.ValueObjects)](https://www.nuget.org/packages/Krafted.ValueObjects/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.ValueObjects)](https://www.nuget.org/packages/Krafted.ValueObjects/)

> **`Krafted.DataAnnotations`**
>
> A set of DataAnnotations attributes for validations.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.DataAnnotations)](https://www.nuget.org/packages/Krafted.DataAnnotations/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.DataAnnotations)](https://www.nuget.org/packages/Krafted.DataAnnotations/)

> **`Krafted.UnitTests`**
>
> Extension methods, DataAnnotations and Test Doubles to enhance the unit tests.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.UnitTests)](https://www.nuget.org/packages/Krafted.UnitTests/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.UnitTests)](https://www.nuget.org/packages/Krafted.UnitTests/)

> **`Krafted.Net`**
>
> A set of utility components for network operations.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.Net)](https://www.nuget.org/packages/Krafted.Net/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.Net)](https://www.nuget.org/packages/Krafted.Net/)

> **`Krafted.DesignPatterns`**
>
> A set of building blocks and participants to implement Design Patterns of GoF and others.
>
> [![Nuget](https://img.shields.io/nuget/v/Krafted.DesignPatterns)](https://www.nuget.org/packages/Krafted.DesignPatterns/) [![Nuget](https://img.shields.io/nuget/dt/Krafted.DesignPatterns)](https://www.nuget.org/packages/Krafted.DesignPatterns/)

# How can I get help?
If you have a question, I suggest [Stack Overflow](https://stackoverflow.com/) as the fastest way to get help.

For bugs, issues or feature requests, please, create a [GitHub Issue](https://github.com/maiconheck/krafted/issues/new).

# How can I contribute?
> Annoyed for copying and pasting your utility code between your projects? 😩
>
> How about being able to reuse your code through the Krafted? 😎

Krafted was created to be a home of useful and reusable pieces of code for the .NET community.
So if you have any code snippet that is useful, clean, decoupled and tested,
and want to contribute to this goal, please make a [pull request!](https://github.com/maiconheck/krafted/pulls) 💜
