# Gobln.Extensions

Gobln.Extensions is a library containing useful extensions.

## Frameworks

* .Net 4.0 and higher
* .Net Core 2.0 and higher
* .Net Core 3.0 and higher

## Extensions

### How to use

Install Gobln.Extensions, trough [Nuget](https://nuget.org/) or other means.

### Examples

```csharp

using Gobln.Extensions;

//examples

if ("Find the word or words in the string".ContainsAll(new[] { "word", "words" }))
{
    //Word or words found
}

var isPrime = 5.IsPrime();

var isLeap = new DateTime(2016, 10, 20).IsLeapYear();

```

For more examples, check the test project

### List of extensions
- DateTime:
    - Elapsed
    - FirstDayOfMonth
    - LastDayOfMonth
    - FirstDayOfWeek
    - FromUnixTimestamp
    - GetAge
    - IsLeapDay
    - IsLeapYear
    - Next
    - Previous
    - RoundToNearestInterval
    - ToUnixTimestamp
    - Truncate
- Dictionary:
    - AddRange
    - IEnumerable
    - ToList
    - ToArray
    - ToHashTable
- DirectoryInfo
    - DirectorySize
    - GetFileExtensions
    - Rename
- Enumerable
    - Median
    - StdDev
    - HasDuplicates
    - GetDuplicates
    - ToBatch
    - ToBatchEvenly
    - Pivot
    - ToCollection
    - RandomItem
    - Randomize
    - WhereIf
    - AnyIf
- Enum
    - GetDescriptionValue
    - GetDisplayValue
- FileInfo
    - IsReady
    - NameWithoutExtension
    - Rename
- UriBuilder
    - AddPath
- Type
    - GetAttribute
    - HasAttribute
    - GetCoreType
    - IsNullableType
- StringBuilder
    - AppendLine
    - Replace
- NameValueCollection
    - GetValue
    - TryGetValue
- Number
    - IsPrime
    - IsPalindrome
    - IsEven
    - Reverse
    - Length
    - LengthAbs
    - GetFirstNumber
    - ToArray
- String
    - Contains
    - ContainsAll
    - FirstUpperRestLower
    - GetLeftFrom
    - GetRightFrom
    - IsNumeric
    - IsPalindrome
    - Repeat
    - Reverse
    - SplitCapitalizedWords
    - ToColor
    - Similarity
    - TrimEnd
    - TrimStart
    - Split
- Xml
    - ToXmlElement
    - ToXmlDocument
    - ToXElement
    - ToXDocument

## Installing Gobln.Extensions

The project is on [Nuget](https://www.nuget.org/packages/Gobln.Extensions/). Install via the NuGet Package Manager.

PM > Install-Package Gobln.Extensions

## License

[Apache License, Version 2.0](http://opensource.org/licenses/Apache-2.0).

## Documentation and Readme file

I'm going to provide an documentation file, but haven't started on one yet.
As for the Readme file, if there are any inconsitencies or grammatical errors feel free to let me know by an pull request. This also counts for problems in de code.

## Issues and Contributions

* If something is broken and you know how to fix it, send a pull request.
* If you have no idea what is wrong, create an issue.

## Any feedback and contributions are welcome

If you have something you'd like to improve do not hesitate to send a Pull Request