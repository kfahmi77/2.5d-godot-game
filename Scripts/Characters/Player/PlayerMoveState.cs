using Godot;
using my3dmobilegame.Scripts.Utils;
using System;

public partial class PlayerMoveState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        GD.Print("PlayerMoveState _PhysicsProcess");
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }
        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= characterNode.speed;

        characterNode.MoveAndSlide();
        characterNode.FlipSprite();
    }

    protected override void EnterState()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_MOVE);
    }
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionPressed(GameContants.INPUT_DASH))
        {
            characterNode.stateMachineNode.SwitchState<PlayeDashState>();
        }
    }
}
