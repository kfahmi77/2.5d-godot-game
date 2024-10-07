using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public float speed = 5;
    [Export] public float jumpSpeed = 10;
    [Export] public float gravity = 10;
    [Export] private AnimationPlayer animationPlayerNode;
    [Export] private Sprite3D sprite3DNode;


    private Vector2 direction = new();


    public override void _Ready()
    {
        animationPlayerNode.Play("Idle");
    }
    public override void _Process(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
          "MoveLeft",
          "MoveRight",
          "MoveForward",
          "MoveBackward"
         );
        if (direction == Vector2.Zero)
        {
            animationPlayerNode.Play("Idle");
        }
        else
        {
            animationPlayerNode.Play("Move");
        }
    }
}

