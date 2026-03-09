using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStateMachineManager _stateMachineManager;
    [SerializeField] private HealthBar _healthBar;

    private int _maxHealth = 100;
    private int _currentHealth = 100;

    public int MaxHealth
    {
        get { return _maxHealth; }
    }
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set 
        { 
            _currentHealth = value;
            _healthBar.SetHealthValue(_currentHealth);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _stateMachineManager = GetComponent<PlayerStateMachineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
