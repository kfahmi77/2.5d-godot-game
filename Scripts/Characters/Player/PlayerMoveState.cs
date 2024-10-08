using Godot;
using my3dmobilegame.Scripts.Utils;
using System;

public partial class PlayerMoveState : Node
{

    private Player characterNode;
    public
    override void _Ready()
    {
        characterNode = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            characterNode.animationPlayerNode.Play(GameContants.ANIM_MOVE);
        }

    }
}
