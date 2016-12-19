using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDisplace : Displace {
    private GameObject _validTarget = null;

    public bool _atTargetPosition = false; //Outside behavior should set this

    void Start()
    {

    }

    void OnEnable()
    {
        Initialize();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!this.enabled) return;
        if (Utilities.Effects.IsValidTarget(gameObject, other.gameObject, _targetNumber, _type, _isTargeted))
        {
            _validTarget = other.gameObject;
            DoDiscrete();
        }
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

    public override void DoDiscrete()
    {
        ApplyDisplacement(_validTarget);
       // _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        //Projectile cannot be persistent
        yield break;
    }
}
