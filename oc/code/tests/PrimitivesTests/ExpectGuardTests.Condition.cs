// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;

namespace angelof.dev.tests;

[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Simplifies the test code for the class under test.")]
public sealed partial class ExpectGuardTests
{
    public sealed class Condition
    {
        [Fact]
        public void WhenConditionIsFalse_ThrowsExpectationException()
        {
            const string obj = "abc";
            var msg = Assert.Throws<ExpectationException>(() => Guard.Expect.Condition(obj, obj == "ABC")).Message;
            var expectedMessage = EmbeddedResource.GetString(typeof(Condition), "expected-message").NormalizeNewLines();
            Assert.Equal(expectedMessage, msg);
        }

        [Fact]
        public void WhenConditionIsTrue_andNoContextProvided_DoesNotThrow()
        {
            const string obj = "abc";
            Guard.Expect.Condition(obj == "abc");
        }

        [Fact]
        public void WhenConditionIsTrue_ReturnsAnonymousTypeContext()
        {
            const string obj = "abc";
            var arg = Guard.Expect.Condition(new {input = obj}, obj == "abc");
            Assert.Equal(obj, arg.input);
        }

        [Fact]
        public void WhenConditionIsTrue_ReturnsContext()
        {
            const string obj = "abc";
            var arg = Guard.Expect.Condition(obj, obj == "abc");
            Assert.Equal(obj, arg);
        }
    }
}
