using System;
using Godot;
using my3dmobilegame.Scripts.Characters.Enemies;
using my3dmobilegame.Scripts.Utils;

public partial class EnemyPatrolState : EnemyState
{
    private int PointIndex = 0;

    [Export] private Timer idleTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")] private float maxIdleTime = 4;

    public override void _PhysicsProcess(double delta)
    {
        if (!idleTimerNode.IsStopped()) { return; }
        Move();
    }

    protected override void EnterState()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_MOVE);
        PointIndex = 1;
        destination = GetGlobalPosition(PointIndex);
        characterNode.AgentNode.TargetPosition = destination;

        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
        idleTimerNode.Timeout += HandleIdleTimerTimeout;

        characterNode.ChaseAreaNode.BodyEntered += HanldeChaseAreaBodyEntered;

    }
    protected override void ExitsState()
    {
        characterNode.AgentNode.NavigationFinished -= HandleNavigationFinished;
        idleTimerNode.Timeout -= HandleIdleTimerTimeout;

        characterNode.ChaseAreaNode.BodyEntered -= HanldeChaseAreaBodyEntered;

    }



    private void HandleNavigationFinished()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_IDLE);

        RandomNumberGenerator randomNumberGenerator = new();
        idleTimerNode.WaitTime = randomNumberGenerator.RandfRange(1, maxIdleTime);

        idleTimerNode.Start();
    }
    private void HandleIdleTimerTimeout()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_MOVE);
        PointIndex = Mathf.Wrap(PointIndex + 1, 0,
         characterNode.PathNode.Curve.PointCount);

        destination = GetGlobalPosition(PointIndex);
        characterNode.AgentNode.TargetPosition = destination;
    }
}
