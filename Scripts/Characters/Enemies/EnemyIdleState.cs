using Godot;
using my3dmobilegame.Scripts.Characters.Enemies;
using my3dmobilegame.Scripts.Utils;
using System;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_IDLE);

        characterNode.ChaseAreaNode.BodyEntered += HanldeChaseAreaBodyEntered;
    }

    protected override void ExitsState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HanldeChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.stateMachineNode.SwitchState<EnemyReturnState>();
    }
}
