// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.tests;

public sealed partial class ExpectGuardTests
{
    public sealed class NotNull
    {
        [Fact]
        public void WhenArgumentIsNotNull_ReturnsArgument()
        {
            const string obj = "abc";
            var arg = Guard.Expect.NotNull(obj);
            Assert.NotNull(arg);
        }

        [Fact]
        public void WhenArgumentIsNull_ThrowsExpectationException()
        {
            string? obj = null;
            var msg = Assert.Throws<ExpectationException>(() => Guard.Expect.NotNull(obj)).Message;
            var expectedMessage = EmbeddedResource.GetString(typeof(NotNull), "expected-message").NormalizeNewLines();
            Assert.Equal(expectedMessage, msg);
        }
    }
}
