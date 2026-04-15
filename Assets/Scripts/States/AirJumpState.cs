using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirJumpState : AirBaseState
{
    public override void Enter()
    {
        base.Enter();
        _playerController.CanDoubleJump = false;
        _playerController.IsFastFalling = false;
        _playerController.DoubleJump(_playerController.DoubleJumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Init(PlayerController opponent, PlayerStateMachineManager stateManager, Animator animator, SpriteRenderer spriteRenderer, Rigidbody2D rb, PlayerController playerController, PlayerHealth playerHealth)
    {
        base.Init(opponent, stateManager, animator, spriteRenderer, rb, playerController, playerHealth);
    }

    public override void Update()
    {
        base.Update();
    }
}
