using Godot;

namespace my3dmobilegame.Scripts.Characters.Enemies;

public abstract partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    protected Vector3 GetGlobalPosition(int index)
    {
        Vector3 localPos = characterNode.PathNode.Curve
        .GetPointPosition(index);
        Vector3 globalPos = characterNode.PathNode.GlobalPosition;
        return localPos + globalPos;
    }

    public void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition
        .DirectionTo(destination);

        characterNode.MoveAndSlide();
        characterNode.FlipSprite();
    }

    protected void HanldeChaseAreaBodyEntered(Node3D body)
    {
        characterNode.stateMachineNode.SwitchState<EnemyChaseState>();
    }
}
