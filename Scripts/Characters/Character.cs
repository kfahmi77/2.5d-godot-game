using System;
using Godot;

namespace my3dmobilegame.Scripts.Characters;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public float speed = 5;
    [Export] public float jumpSpeed = 10;
    [Export] public float gravity = 10;
    [Export] public AnimationPlayer animationPlayerNode;
    [Export] public Sprite3D sprite3DNode;
    [Export] public StateMachine stateMachineNode;

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode { get; private set; }
    [Export] public NavigationAgent3D AgentNode { get; private set; }
    [Export] public Area3D ChaseAreaNode { get; private set; }

    public Vector2 direction = new();

    public void FlipSprite()
    {
        bool isNotMovingHorizontal = Math.Abs(Velocity.X) < 0.01;

        if (isNotMovingHorizontal)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0;
        sprite3DNode.FlipH = isMovingLeft;

    }
}
