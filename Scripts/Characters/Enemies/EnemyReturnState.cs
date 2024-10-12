using Godot;
using my3dmobilegame.Scripts.Characters.Enemies;
using my3dmobilegame.Scripts.Utils;

public partial class EnemyReturnState : EnemyState
{

    public override void _Ready()
    {
        base._Ready();

        destination = GetGlobalPosition(0);
    }
    protected override void EnterState()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_MOVE);
        characterNode.AgentNode.TargetPosition = destination;

        characterNode.ChaseAreaNode.BodyEntered += HanldeChaseAreaBodyEntered;
    }

    protected override void ExitsState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HanldeChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.AgentNode.IsNavigationFinished())
        {
            characterNode.stateMachineNode.SwitchState<EnemyPatrolState>();
            return;
        }
        Move();

    }
}
