// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.tests;

public sealed partial class ArgumentGuardTests
{
    public sealed class NotNull
    {
        [Fact]
        public void WhenArgumentIsNotNull_DoesNotThrow()
        {
            const string obj = "abc";
            Guard.Argument.NotNull(obj);
        }

        [Fact]
        public void WhenArgumentIsNull_ThrowsArgumentNullException()
        {
            string? obj = null;
            Assert.Throws<ArgumentNullException>(() => Guard.Argument.NotNull(obj));
        }
    }
}
