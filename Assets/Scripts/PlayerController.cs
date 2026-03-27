using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player ID")]
    [SerializeField] private int _playerID;

    [Header("Refs")]
    [SerializeField] private GameObject _capsule;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private AttackData[] _attacksData;

    [SerializeField] private float _playerSpeed = 10f;
    private Vector2 _movementInput = Vector2.zero;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _playerJumpForce = 10f;
    private bool _canJump = true;

    private AttackData _currentAttack = null;
    private bool _canAttack = true;
    private int _attackIndex = 1;
    private bool _shouldCombo = false;

    private bool _isHitting = false;

    private int _deathCooldown = 5;

    public int PlayerID
    {
        get { return _playerID; }
    }
    public Animator Animator
    {
        get { return _animator; }
    }
    public Rigidbody2D Rb
    {
        get { return _rb; }
    }
    public SpriteRenderer SpriteRenderer
    {
        get { return _spriteRenderer; }
    }
    public PlayerHealth PlayerHealth
    {
        get { return _playerHealth; }
    }
    public AttackData[] AttacksData
    {
        get
        {
            return _attacksData;
        }
    }
    public Vector2 MovementInput
    {
        get { return _movementInput; }
    }
    public bool CanJump
    {
        get { return _canJump; }
        set { _canJump = value; }
    }
    public AttackData CurrentAttack
    {
        get { return _currentAttack; }
        set
        {
            _currentAttack = value;
        }
    }
    public bool CanAttack
    {
        get { return _canAttack; }
        set { _canAttack = value; }
    }
    public int AttackIndex
    {
        get { return _attackIndex; }
        set { _attackIndex = value; }
    }
    public bool ShouldCombo
    {
        get { return _shouldCombo; }
        set { _shouldCombo = value; }
    }
    public bool IsHitting
    {
        get { return _isHitting; }
        set { _isHitting = value; }
    }
    public int DeathCooldown
    {
        get { return Mathf.Clamp(_deathCooldown, 0, 100); }
        set { _deathCooldown = value; }
    }

    #region Events
    private event Action _attackPressed = null;
    public event Action AttackPressed
    {
        add
        {
            _attackPressed -= value;
            _attackPressed += value;
        }
        remove { _attackPressed -= value; }
    }
    private event Action _jumpPressed = null;
    public event Action JumpPressed
    {
        add
        {
            _jumpPressed -= value;
            _jumpPressed += value;
        }
        remove
        {
            _jumpPressed -= value;
        }
    }
    #endregion Events

    public void GetMovementInput(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void GetJumpInput(InputAction.CallbackContext context)
    {
        if (_jumpPressed != null && context.started)
        {
            _jumpPressed();
        }
    }

    public void GetAttackInput(InputAction.CallbackContext context)
    {
        if (_attackPressed != null && context.started)
        {
            _attackPressed();
        }
    }

    /// <summary>
    /// Move the character based on a vector2 input. Also makes the character faced the right direction
    /// </summary>
    /// <param name="dir"></param>
    public void Move(Vector2 dir)
    {
        _rb.velocity = new Vector2(dir.x * _playerSpeed, _rb.velocity.y);
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (dir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _playerJumpForce);
    }

    /// <summary>
    /// Reset the combo counter
    /// </summary>
    public void ResetCombo()
    {
        _attackIndex = 1;
        _shouldCombo = false;
        _animator.SetBool("IsAttacking1", false);
        _animator.SetBool("IsAttacking2", false);
        _animator.SetBool("IsAttacking3", false);
    }

    /// <summary>
    /// Checks if the player is grounded
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        Bounds bounds = _capsule.GetComponent<BoxCollider2D>().bounds;
        RaycastHit2D hit = Physics2D.BoxCast(bounds.center, bounds.size, 0, Vector2.down, 0.2f, _groundLayer);
        // Debug
        Color rayColor = (hit.collider != null) ? Color.green : Color.red;
        Debug.DrawRay(bounds.center + new Vector3(bounds.extents.x, 0), Vector2.down * (bounds.extents.y + 0.2f), rayColor);
        Debug.DrawRay(bounds.center - new Vector3(bounds.extents.x, 0), Vector2.down * (bounds.extents.y + 0.2f), rayColor);
        Debug.DrawRay(bounds.center - new Vector3(bounds.extents.x, bounds.extents.y + 0.2f), Vector2.right * (bounds.size.x), rayColor);
        return hit;
    }
}