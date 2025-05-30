using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : APlayerState
{
    public override void Enter()
    {
        _animator.SetBool("IsHurt", true);
        _stateManager.StartCoroutine(_stateManager.HurtTime(1));
    }

    public override void Exit()
    {
        _animator.SetBool("IsHurt", false);
    }

    public override void Init(PlayerStateMachineManager stateManager, Animator animator, SpriteRenderer spriteRenderer, Rigidbody2D rb)
    {
        _stateManager = stateManager;
        _animator = animator;
        _spriteRenderer = spriteRenderer;
        _rb = rb;
    }

    public override void Update()
    {
        if (!_stateManager.IsHurt)
        {
            _stateManager.ChangeState(EPlayerState.IDLE);
        }
    }
}
