using Godot;
using my3dmobilegame.Scripts.Utils;

public partial class PlayerIdleState : PlayerState
{


    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Player Idle State");
        base._PhysicsProcess(delta);
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
        }
    }



    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionPressed(GameContants.INPUT_DASH))
        {
            characterNode.stateMachineNode.SwitchState<PlayeDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.animationPlayerNode.Play(GameContants.ANIM_IDLE);
    }

}
