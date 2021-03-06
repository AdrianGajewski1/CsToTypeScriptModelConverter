﻿using Converter.Core.Extensions;
using FluentAssertions;
using Xunit;

namespace Converter.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("String", "string")]
        [InlineData("Boolean", "boolean")]
        [InlineData("Int32", "number")]
        [InlineData("Decimal", "number")]
        [InlineData("Double", "number")]
        [InlineData("Int64", "number")]
        public void ShouldConvertCSharpTypeToTSType(string csType, string tsType)
        {
            var convertedType = csType.ConvertToTS();

            convertedType.Should().Be(tsType);
        }

        [Theory]
        [InlineData("String[]", "string[]")]
        [InlineData("Int32[]", "number[]")]
        public void ShouldConvertCSharpArrayTypeToTSType(string csType, string tsType)
        {
            var convertedType = csType.ConvertToTS();

            convertedType.Should().Be(tsType);
        }

        [Theory]
        [InlineData("Dictionary<string,string>", "{[key: string]: string}")]
        [InlineData("Dictionary<int,ApplicationUser>", "{[key: number]: ApplicationUser}")]
        [InlineData("Dictionary<DateTime,string>", "{[key: Date]: string}")]
        public void ShouldConvertCSharpDictionaryTypeToTSDictionaryType(string csType, string tsType)
        {
            var convertedType = csType.ConvertToTS();

            convertedType.Should().Be(tsType);
        }
    }
}
