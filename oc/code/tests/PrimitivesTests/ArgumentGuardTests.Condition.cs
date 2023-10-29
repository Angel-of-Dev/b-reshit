// Copyright (c) Angel-of-Dev. All rights reserved.

using System.Diagnostics.CodeAnalysis;

namespace angelof.dev.tests;

public sealed partial class ArgumentGuardTests
{
    public sealed class Condition
    {
        [Fact]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        public void WhenArgumentFailsConditionCheck_ThrowsArgumentOutOfRangeException()
        {
            const int arg = 13;
            var msg = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Argument.Condition(arg, arg < 7)).Message;
            var expectedMessage = EmbeddedResource.GetString(typeof(Condition), "expected-message").NormalizeNewLines();
            Assert.Equal(expectedMessage, msg.NormalizeNewLines());
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        public void WhenArgumentMeetsCondition_DoesNotThrow()
        {
            const int arg = 13;
            Guard.Argument.Condition(arg, arg > 7);
        }
    }
}
