using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : APlayerState
{
    private float _dashForce = 3f;
    private Vector2 _recordedInput = Vector2.zero;
    public override void Enter()
    {
        _recordedInput = _stateManager.RecordInput();
        _animator.SetBool("IsDashing", true);
    }

    public override void Exit()
    {
        _animator.SetBool("IsDashing", false);
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
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _stateManager.ChangeState(EPlayerState.IDLE);
        }
        else
        {
            _rb.velocity = new Vector2 (_recordedInput.x * _dashForce, 0);
        }
    }
}
