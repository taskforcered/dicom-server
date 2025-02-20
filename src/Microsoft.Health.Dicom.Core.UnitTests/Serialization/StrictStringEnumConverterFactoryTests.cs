﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Microsoft.Health.Dicom.Core.Features.ExtendedQueryTag;
using Microsoft.Health.Dicom.Core.Serialization;
using Xunit;
using Xunit.Sdk;

namespace Microsoft.Health.Dicom.Core.UnitTests.Serialization
{
    public class StrictStringEnumConverterFactoryTests
    {
        private readonly JsonSerializerOptions _defaultOptions;

        public StrictStringEnumConverterFactoryTests()
        {
            _defaultOptions = new JsonSerializerOptions();
            _defaultOptions.Converters.Add(new StrictStringEnumConverterFactory());
        }

        [Fact]
        public void GivenInvalidTypes_WhenCheckingCanConvert_ThenReturnFalse()
        {
            var factory = new StrictStringEnumConverterFactory();
            Assert.False(factory.CanConvert(typeof(int)));
            Assert.False(factory.CanConvert(typeof(string)));
            Assert.False(factory.CanConvert(typeof(object)));
        }

        [Fact]
        public void GivenValidTypes_WhenCheckingCanConvert_ThenReturnTrue()
        {
            var factory = new StrictStringEnumConverterFactory();
            Assert.True(factory.CanConvert(typeof(SeekOrigin)));
            Assert.False(factory.CanConvert(typeof(BindingFlags?)));
        }

        [Theory]
        [InlineData("\"1\"", false)]
        [InlineData("2", false)]
        [InlineData("[ 1, 2, 3 ]", false)]
        [InlineData("\"1\"", true)]
        [InlineData("2", true)]
        [InlineData("[ 1, 2, 3 ]", true)]
        public void GivenInvalidJson_WhenReadingJson_ThenThrowJsonException(string jsonValue, bool nullable)
        {
            var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes($"{{ \"Level\": {jsonValue} }}"));

            try
            {
                if (nullable)
                {
                    JsonSerializer.Deserialize<Example>(ref jsonReader, _defaultOptions);
                }
                else
                {
                    JsonSerializer.Deserialize<NullableExample>(ref jsonReader, _defaultOptions);
                }

                throw new ThrowsException(typeof(JsonException));
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(JsonException))
                {
                    throw new ThrowsException(typeof(JsonException), e);
                }
            }
        }

        [Theory]
        [InlineData("INSTANCE", QueryTagLevel.Instance, false)]
        [InlineData("series", QueryTagLevel.Series, false)]
        [InlineData("StUdY", QueryTagLevel.Study, false)]
        [InlineData("INSTANCE", QueryTagLevel.Instance, true)]
        [InlineData("series", QueryTagLevel.Series, true)]
        [InlineData("StUdY", QueryTagLevel.Study, true)]
        public void GivenValidJson_WhenReadingJson_ThenReturnParsedValue(string name, QueryTagLevel expected, bool nullable)
        {
            var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes($"{{ \"Level\": \"{name}\" }}"));

            QueryTagLevel actual = nullable
                ? JsonSerializer.Deserialize<NullableExample>(ref jsonReader, _defaultOptions).Level.GetValueOrDefault()
                : JsonSerializer.Deserialize<Example>(ref jsonReader, _defaultOptions).Level;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenNullValue_WhenReadingNullableJson_ThenReturnNull()
        {
            var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes($"{{ \"Level\": null }}"));

            NullableExample actual = JsonSerializer.Deserialize<NullableExample>(ref jsonReader, _defaultOptions);
            Assert.Null(actual.Level);
        }

        [Theory]
        [InlineData(QueryTagLevel.Instance, "\"Instance\"", false)]
        [InlineData(QueryTagLevel.Series, "\"Series\"", false)]
        [InlineData(QueryTagLevel.Study, "\"Study\"", false)]
        [InlineData(QueryTagLevel.Instance, "\"Instance\"", true)]
        [InlineData(QueryTagLevel.Series, "\"Series\"", true)]
        [InlineData(QueryTagLevel.Study, "\"Study\"", true)]
        public void GivenEnumValue_WhenWritingJson_ThenWriteName(QueryTagLevel value, string expected, bool nullable)
        {
            string actual = nullable
                ? JsonSerializer.Serialize(new NullableExample { Level = value }, _defaultOptions)
                : JsonSerializer.Serialize(new Example { Level = value }, _defaultOptions);

            Assert.Equal($"{{\"Level\":{expected}}}", actual);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void GivenUndefinedEnumValue_WhenWritingJson_ThenThrowJsonException(bool nullable)
        {
            object obj = nullable
                ? new NullableExample { Level = (QueryTagLevel)12 }
                : new Example { Level = (QueryTagLevel)12 };

            Assert.Throws<JsonException>(() => JsonSerializer.Serialize(obj, _defaultOptions));
        }

        private sealed class Example
        {
            public QueryTagLevel Level { get; set; }
        }

        private sealed class NullableExample
        {
            public QueryTagLevel? Level { get; set; }
        }
    }
}
