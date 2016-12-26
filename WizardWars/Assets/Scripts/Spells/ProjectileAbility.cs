using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability {
    [HideInInspector]
    GameObject _collidedTarget;

	void Start () {
       
	}

    void OnEnable()
    {
        _isPersistent = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!this.enabled) return;
        if (IsValidTarget(other.gameObject, _target))
        {
            _collidedTarget = other.gameObject;
            DoDiscrete();
        }
    }

    public override IEnumerator DoContinuous()
    {
        //Continuous projectile effects make no sense. This should never be called.
        Debug.LogError("Calling Continuous Coroutine in a Projectile Ability.");
        yield break;
    }

    public override bool Done()
    {
        return _doneWithDiscrete;
    }

    public override void DoDiscrete()
    {
        Apply(_collidedTarget);
        _doneWithDiscrete = true;
    }
}
