using Godot;
using my3dmobilegame.Scripts.Characters;
using my3dmobilegame.Scripts.Utils;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Player : Character
{
    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
          GameContants.INPUT_MOVE_LEFT,
          GameContants.INPUT_MOVE_RIGHT,
          GameContants.INPUT_MOVE_FORWARD,
          GameContants.INPUT_MOVE_BACKWARD
         );

    }
}

