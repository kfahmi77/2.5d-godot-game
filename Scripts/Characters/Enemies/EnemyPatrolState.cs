using Godot;
using my3dmobilegame.Scripts.Characters.Enemies;
using my3dmobilegame.Scripts.Utils;

public partial class EnemyPatrolState : EnemyState
{
    private int PointIndex = 0;
    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    protected override void EnterState()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_MOVE);
        PointIndex = 1;
        destination = GetGlobalPosition(PointIndex);
        characterNode.AgentNode.TargetPosition = destination;

        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;

    }

    private void HandleNavigationFinished()
    {
        PointIndex = Mathf.Wrap(PointIndex + 1, 0,
         characterNode.PathNode.Curve.PointCount);

        destination = GetGlobalPosition(PointIndex);
        characterNode.AgentNode.TargetPosition = destination;
    }
}
