using Godot;
using my3dmobilegame.Scripts.Utils;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public float speed = 5;
    [Export] public float jumpSpeed = 10;
    [Export] public float gravity = 10;
    [Export] public AnimationPlayer animationPlayerNode;
    [Export] public Sprite3D sprite3DNode;
    [Export] public StateMachine stateMachineNode;



    public Vector2 direction = new();

    public override void _Process(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;

        MoveAndSlide();
        FlipSprite();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
          GameContants.INPUT_MOVE_LEFT,
          GameContants.INPUT_MOVE_RIGHT,
          GameContants.INPUT_MOVE_FORWARD,
          GameContants.INPUT_MOVE_BACKWARD
         );

    }

    private void FlipSprite()
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

