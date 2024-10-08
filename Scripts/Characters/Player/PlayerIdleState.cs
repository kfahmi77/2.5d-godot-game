using Godot;
using my3dmobilegame.Scripts.Utils;

public partial class PlayerIdleState : Node
{
    private Player characterNode;
    public
     override void _Ready()
    {
        characterNode = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {

            characterNode.animationPlayerNode.Play(GameContants.ANIM_IDLE);
        }

    }


}
