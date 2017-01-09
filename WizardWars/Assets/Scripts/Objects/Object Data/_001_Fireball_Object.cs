using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _001_Fireball_Object : SummonObject
{
    public ProjectileMove _projectileEffect;
    public AreaAbility _primaryEffect;

    void Start()
    {

    }

    void Update()
    {
        if(_projectileEffect.Done() && _primaryEffect.Done())
        {
            this.gameObject.SetActive(false);
            _projectileEffect.enabled = false;
            _primaryEffect.enabled = false;
            Destroy(this.gameObject);
        }
    }

    public override IEnumerator DoEffect(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber)
    {
        _originPlayer = casterNumber;
        //Start Projectile Move
        _projectileEffect._casterNumber = _originPlayer;
        _projectileEffect._originPosition = castPosition;
        _projectileEffect._targetNumber = targetNumber;
        _projectileEffect._targetPosition = targetPosition;
        _projectileEffect.enabled = true;
        //Wait until the projectile hits a valid target, hits the target position, or goes out of range
        while (!_projectileEffect.Done()) //Is it ready to explode?
        {
            yield return null;
        }
        //Do Primary Ability
        _primaryEffect._casterNumber = _originPlayer;
        _primaryEffect._targetPosition = this.transform;
        _primaryEffect.enabled = true;
        yield break;
    }
}
