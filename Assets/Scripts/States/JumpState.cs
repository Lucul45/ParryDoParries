using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : APlayerState
{
    public override void Enter()
    {
        if (_playerController.PlayerID == 1)
        {
            StateFrameP1 = 0;
        }
        else if (_playerController.PlayerID == 2)
        {
            StateFrameP2 = 0;
        }
        _playerController.CanJump = false;
        _playerController.Jump();
        _animator.SetBool("IsJumping", true);
    }

    public override void Exit()
    {
        _playerController.CanJump = true;
        _animator.SetBool("IsJumping", false);
    }

    public override void Init(PlayerController opponent, PlayerStateMachineManager stateManager, Animator animator, SpriteRenderer spriteRenderer, Rigidbody2D rb, PlayerController playerController, PlayerHealth playerHealth)
    {
        _opponent = opponent;
        _stateManager = stateManager;
        _animator = animator;
        _spriteRenderer = spriteRenderer;
        _rb = rb;
        _playerController = playerController;
        _playerHealth = playerHealth;
    }

    public override void Update()
    {
        if (_playerController.PlayerID == 1)
        {
            StateFrameP1++;
            if (_playerHealth.CurrentHealth <= 0)
            {
                _stateManager.ChangeStateP1(EPlayerState.DEAD);
            }
            if (_playerController.IsGrounded)
            {
                _stateManager.ChangeStateP1(EPlayerState.IDLE);
            }
        }
        else if (_playerController.PlayerID == 2)
        {
            StateFrameP2++;
            if (_playerHealth.CurrentHealth <= 0)
            {
                _stateManager.ChangeStateP2(EPlayerState.DEAD);
            }
            if (_playerController.IsGrounded)
            {
                _stateManager.ChangeStateP2(EPlayerState.IDLE);
            }
        }
    }
}
