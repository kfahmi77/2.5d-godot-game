using Godot;
using my3dmobilegame.Scripts.Utils;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states;

    public override void _Ready()
    {
        currentState.Notification(5001);
    }

    public void SwitchState<T>()
    {
        Node newState = null;
        foreach (Node state in states)
        {
            if (state is T)
            {
                newState = state;
            }
        }
        if (newState == null) { return; }


        currentState.Notification(GameContants.NOTIFICATION_EXIT_STATE);
        currentState = newState;
        currentState.Notification(GameContants.NOTIFICATION_ENTER_STATE);

    }


}
