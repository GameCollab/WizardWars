using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : Damage {
    public int _targetNumber = 0;

    private GameObject _validTarget = null;

    public bool _atTargetPosition = false; //Outside behavior should set this

    void Start () {
        Initialize();
	}

    void OnEnable()
    {
        Initialize();
    }
	
	void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got collision");
        if (Utilities.Effects.IsValidTarget(other.gameObject, _targetNumber, _type, _isTargeted))
        {
            if (!_doneDiscrete)
            {
                _validTarget = other.gameObject;
                DealDamage();
            }
        }
    }

    public override IEnumerator DealContinuousDamage()
    {
        //Projectile Damage cannot be persistent
        yield break;
    }

    public override void DealDamage()
    {
        ApplyDamage(_validTarget);
        _doneDiscrete = true;
    }

    public override bool Done()
    {
        return _doneDiscrete;
    }

    public override void Initialize()
    {
        _isProjectile = true;
        _isPersistent = false;
    }

}
