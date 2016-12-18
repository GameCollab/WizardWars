using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : Damage {

    public Vector3 _castPoint;

    public Enums.Spells.Cast _area;
    public float _areaSize;
    public float _secondaryAreaValue;

    // Use this for initialization
    void Start () {
        Initialize();
	}

    void OnEnable()
    {
        Initialize();

        if (_isPersistent && !_donePersist && !_runPersist)
        {
            Debug.Log("Do Continuous");
            _timer = 0f;
            _runPersist = true;
            StartCoroutine(DealContinuousDamage());
        }
        else if (!_isPersistent && !_doneDiscrete)
        {
            Debug.Log("Do Discrete");
            DealDamage();
        }
    }

    public override IEnumerator DealContinuousDamage()
    {
        while (!Utilities.Effects.IsTimerDone(_timer, _duration))
        {
            // Get player info via targetNumber
            // Run Player's take damage function
            List<GameObject> targets = Utilities.Effects.GetAllOfTypeInCast(_area, _castPoint, _areaSize, _secondaryAreaValue, Utilities.EnumUtil.GetStringTag(_type));
            Debug.Log("List length: " + targets.Count);
            foreach (var target in targets)
            {
                ApplyDamage(target);
            }

            _timer += 1f;
            _damage += _damageChange;
            yield return new WaitForSeconds(1);
        }
        _runPersist = false;
        _donePersist = true;
        yield break;
    }

    public override void DealDamage()
    {
        List<GameObject> targets = Utilities.Effects.GetAllOfTypeInCast(_area, _castPoint, _areaSize, _secondaryAreaValue, Utilities.EnumUtil.GetStringTag(_type));
        Debug.Log("List length: " + targets.Count);
        foreach (var target in targets)
        {
            ApplyDamage(target);
        }

        _doneDiscrete = true;
    }

    public override bool Done()
    {
        return _isPersistent ? _donePersist : _doneDiscrete;
    }

    public override void Initialize()
    {
        _isProjectile = false;
        _isTargeted = false;
    }
}
