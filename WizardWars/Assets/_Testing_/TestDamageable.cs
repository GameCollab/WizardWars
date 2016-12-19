using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageable : MonoBehaviour, IDamageable, IHealable, IControllable, IMovable {
    public Rigidbody _rigidbody;
    public float _health;
    public bool _isDead;

    public int _number;

    public List<GameObject> _statuses;
    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < _statuses.Count; i++)
        {
            if(_statuses[i].GetComponent<Status>().Done())
            {
                _statuses[i].GetComponent<Status>().DoInverse();
                _statuses.RemoveAt(i);
                i--;
            }
        }
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

    public void ApplyStatus(uint status, int from, uint spell)
    {
        GameObject copy = (GameObject)Instantiate(Utilities.ManagerAccess.GetStatusById(status));
        Debug.Log("Got status: " + copy.GetComponent<Status>()._name);
        copy.GetComponent<Status>()._targetPlayer = _number;
        copy.GetComponent<Status>()._originPlayer = from;
        copy.GetComponent<Status>()._originSpell = spell;
        _statuses.Add(copy);
        _statuses[_statuses.Count - 1].GetComponent<Status>().DoEffect();

    }

    public void Move(Vector3 force)
    {
        Debug.Log("Adding Force: " + force);
        _rigidbody.velocity *= 0;
        _rigidbody.AddForce(force);
    }
}
