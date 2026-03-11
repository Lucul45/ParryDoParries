using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private int _maxHealth = 100;
    private int _currentHealth = 100;

    public int MaxHealth
    {
        get { return _maxHealth; }
    }
    public int CurrentHealth
    {
        get { return Mathf.Clamp(_currentHealth, 0, 100); }
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealthValue(_currentHealth);
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetHealthValue(_currentHealth);
    }
}
