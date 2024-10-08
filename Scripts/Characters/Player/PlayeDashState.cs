using Godot;
using my3dmobilegame.Scripts.Utils;
using System;
using System.Reflection.Metadata;

public partial class PlayeDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export] private float speed = 10;

    public override void _Ready()
    {
        base._Ready();
        dashTimerNode.Timeout += HandleDashTimeout;
    }

    protected override void EnterState()
    {

        {
            characterNode.animationPlayerNode.Play(GameContants.ANIM_DASH);
            characterNode.Velocity = new(
                characterNode.direction.X, 0, characterNode.direction.Y
                );
            if (characterNode.Velocity == Vector3.Zero)
            {
                characterNode.Velocity = characterNode.sprite3DNode.FlipH ? Vector3.Left : Vector3.Right;
            }
            characterNode.Velocity *= speed;
            dashTimerNode.Start();
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print("PlayerDashState _PhysicsProcess");
        characterNode.MoveAndSlide();
        characterNode.FlipSprite();
    }
    private void HandleDashTimeout()
    {
        characterNode.Velocity = Vector3.Zero;
        characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
    }
}
