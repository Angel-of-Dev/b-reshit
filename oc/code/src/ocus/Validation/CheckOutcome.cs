// Copyright (c) Angel-of-Dev. All rights reserved.

namespace angelof.dev.ocus.Validation;

internal sealed record CheckOutcome
{
    public CheckOutcome(string sut,
                        string condition,
                        bool isSuccess,
                        bool shouldRun = true,
                        string? runCondition = null)
    {
        Sut = sut;
        Condition = condition;
        IsSuccess = isSuccess;
        ShouldRun = shouldRun;
        RunCondition = runCondition;
    }

    public bool ShouldRun { get; }
    public bool? IsSuccess { get; }
    public string Condition { get; }
    public string Sut { get; }
    public string? RunCondition { get; }
}
