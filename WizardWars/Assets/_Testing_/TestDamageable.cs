using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageable : MonoBehaviour, IDamageable, IHealable {
    public float _health;
    public bool _isDead;

    public int _number;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        if (_isDead)
        {
            Debug.Log("DEAD!");
        }
    }

    public void TakeDamage(float damage)
    {
        if (!_isDead && damage > 0)
        {
            Debug.Log("Old Health: " + _health);
            Debug.Log("Damage Taken: " + damage);
            _health -= damage;
            Debug.Log("New Health: " + _health);
            if (_health <= 0)
            {
                Debug.Log("Uh oh! Out of Health!");
                _isDead = true;
            }
        }
    }

    public void Heal(float amount)
    {
        if(!_isDead && _health > 0 && amount > 0)
        {
            Debug.Log("Old Health: " + _health);
            Debug.Log("Health Restored: " + amount);
            _health += amount;
            Debug.Log("New Health: " + _health);
        }
    }
}
