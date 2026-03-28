using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMoveState : AirBaseState
{
    public override void Enter()
    {
        base.Enter();
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
        _playerController.AirMove(_playerController.MovementInput);
    }
}
