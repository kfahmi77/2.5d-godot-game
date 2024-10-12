using Godot;
using my3dmobilegame.Scripts.Characters.Enemies;
using my3dmobilegame.Scripts.Utils;
using System;
using System.Linq;
using System.Reflection.Metadata;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer timerNode;
    private CharacterBody3D target;
    protected override void EnterState()
    {
        characterNode.animationPlayerNode.Play(GameContants.ANIM_MOVE);
        target = (CharacterBody3D)characterNode.ChaseAreaNode
        .GetOverlappingBodies()
        .First();

        timerNode.Timeout += HandleTimeout;
    }

    protected override void ExitsState()
    {
        timerNode.Timeout -= HandleTimeout;
    }



    public override void _PhysicsProcess(double delta)
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;

        Move();
    }

    private void HandleTimeout()
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
    }
}
