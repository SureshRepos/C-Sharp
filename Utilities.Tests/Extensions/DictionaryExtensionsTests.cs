using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Extensions;

namespace Utilities.Tests.Extensions;

public class DictionaryExtensionsTests
{
    [Test]
    public void AddMany_ShouldThrowArgumentException_WhenKeyAlreadyExists()
    {
        var dictionary = new Dictionary<string, int> { ["one"] = 1 };
        var enumerable = new[] { ("one", 1), ("two", 2) };

        var action = () => dictionary.AddMany(enumerable);

        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void AddMany_ShouldAddAllKeyValuePairs()
    {
        var dictionary = new Dictionary<string, int> { ["one"] = 1 };
        var enumerable = new[] { ("two", 2), ("three", 3) };

        dictionary.AddMany(enumerable);

        dictionary.Should().HaveCount(3);

        // Post update change
        dictionary.Should().ContainKey("one");
        dictionary.Should().ContainKey("two");
        dictionary.Should().ContainKey("three");

    }
}
