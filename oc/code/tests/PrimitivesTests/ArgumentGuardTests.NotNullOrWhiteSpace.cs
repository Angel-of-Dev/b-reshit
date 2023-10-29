// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.tests;

public sealed partial class ArgumentGuardTests
{
    public sealed class NotNullOrWhiteSpace
    {
        [Fact]
        public void WhenArgumentIsEmpty_ThrowsArgumentOutOfRangeException()
        {
            var obj = string.Empty;
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Argument.NotNullOrWhiteSpace(obj));
        }

        [Fact]
        public void WhenArgumentIsNull_ThrowsArgumentNullException()
        {
            string? obj = null;
            Assert.Throws<ArgumentNullException>(() => Guard.Argument.NotNullOrWhiteSpace(obj));
        }

        [Fact]
        public void WhenArgumentIsValid_DoesNotThrow()
        {
            const string obj = "abc";
            Guard.Argument.NotNullOrWhiteSpace(obj);
        }
    }
}
