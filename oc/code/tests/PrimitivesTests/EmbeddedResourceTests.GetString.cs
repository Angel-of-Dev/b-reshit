// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;

namespace angelof.dev.tests;

public sealed class EmbeddedResourceTests
{
    public sealed class GetString
    {
        [Fact]
        public void GetsResourceString()
        {
            var expected = "ABC" + Environment.NewLine + "123" + Environment.NewLine;
            var actual = EmbeddedResource.GetString(typeof(EmbeddedResourceTests), "text");

            Assert.Equal(expected.NormalizeNewLines(), actual.NormalizeNewLines());
        }

        [Fact]
        public void WhenResourceDoesNotExist_ThrowsExpectationException()
            => Assert.Throws<ExpectationException>(static () => EmbeddedResource.GetString(typeof(EmbeddedResourceTests), "not exists"));

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void WhenResourceNameIsInvalid_ThrowsArgumentException()
        {
#nullable disable
            Assert.Throws<ExpectationException>(static () => EmbeddedResource.GetString(typeof(EmbeddedResourceTests), ""));
            Assert.Throws<ArgumentNullException>(static () => EmbeddedResource.GetString(typeof(EmbeddedResourceTests), name: null));
        }
    }
}
