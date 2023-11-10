using System;
internal class Context : IState
{
    private IState currentState;

    public Context(IState initialState)
    {
        currentState = initialState;
    }

    public string TextOnFirstButton => currentState.TextOnFirstButton;
    public string TextOnSecondButton => currentState.TextOnSecondButton;
    public IState PressFirstButton()
    {
        currentState = currentState.PressFirstButton();
        return currentState;
    }

    public IState PressSecondButton()
    {
        currentState = currentState.PressSecondButton();
        return currentState;
    }
}

internal interface IState
{
    string TextOnFirstButton { get; }
    string TextOnSecondButton { get; }

    IState PressFirstButton();
    IState PressSecondButton();
}

internal class InitialScreenState : IState
{
    public string TextOnFirstButton => "Start";
    public string TextOnSecondButton => "Lap";

    public IState PressFirstButton() => new RunningState();
    public IState PressSecondButton() => this;
}

internal class RunningState : IState
{
    public string TextOnFirstButton => "Stop";
    public string TextOnSecondButton => "Lap";

    public IState PressFirstButton() => new DisplayingResultState();
    public IState PressSecondButton() => new LappingState();
}

internal class LappingState : IState
{
    public string TextOnFirstButton => "Stop";
    public string TextOnSecondButton => "Lap";

    public IState PressFirstButton() => new DisplayingResultState();
    public IState PressSecondButton() => this;
}

internal class DisplayingResultState : IState
{
    public string TextOnFirstButton => "Start";
    public string TextOnSecondButton => "Reset";

    public IState PressFirstButton() => new RunningState();
    public IState PressSecondButton() => new InitialScreenState();
}

class Program
{
    static void Main()
    {
        IState stopwatch = new Context(new InitialScreenState());

        Console.WriteLine($"Current State: {stopwatch.GetType().Name}, Button1 [{stopwatch.TextOnFirstButton}], Button2 [{stopwatch.TextOnSecondButton}]");

        stopwatch = stopwatch.PressSecondButton();
        Console.WriteLine($"Current State: {stopwatch.GetType().Name}, Button1 [{stopwatch.TextOnFirstButton}], Button2 [{stopwatch.TextOnSecondButton}]");

        // Continue with other button presses as described in the specification.
    }
}
