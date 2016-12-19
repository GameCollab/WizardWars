using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDamage : Damage {
    // Use this for initialization
    void Start () {
        //Debug.Log("DIRECT DAMAGE: START!");
        //Initialize();
    }

    void OnEnable()
    {
        //Debug.Log("DIRECT DAMAGE: ON ENABLE!");
        Initialize();

        if (_isPersistent && !_donePersist && !_runPersist)
        {
            //Debug.Log("DIRECT DAMAGE: Dealing Continuous Damage");
            _timer = 0f;
            _runPersist = true;
            StartCoroutine(DoContinuous());
            //Debug.Log("DIRECT DAMAGE: Control out of Coroutine.");
        }
        else if(!_isPersistent && !_doneDiscrete)
        {
            //Debug.Log("DIRECT DAMAGE: Dealing Discete Damage");
            DoDiscrete();
        }
    }

    public override bool Done()
    {
        return _isPersistent ? _donePersist : _doneDiscrete;
    }

    public override void Initialize()
    {
        //Debug.Log("DIRECT DAMAGE: Initialized!");
        _isTargeted = true;
        _isProjectile = false;
    }

    public override void DoDiscrete()
    {
        // Get player info via targetNumber
        // Run Player's take damage function
        //GameObject target = new GameObject();
        GameObject target = Utilities.Misc.GetTarget(_targetNumber, _type, _casterNumber);
        ApplyDamage(target);

        _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        while (!Utilities.Misc.IsTimerDone(_timer, _duration))
        {
            //Debug.Log("DIRECT DAMAGE: Timer is Not Done.");
            //Debug.Log("DIRECT DAMAGE: Timer: " + _timer);
            // Get player info via targetNumber
            // Run Player's take damage function
            //Debug.Log("Target: " + _targetNumber);
            GameObject target = Utilities.Misc.GetTarget(_targetNumber, _type, _casterNumber);
            ApplyDamage(target);
            _timer += _timeBetweenTicks;
            _damage += _damageChange;
            yield return new WaitForSeconds(_timeBetweenTicks);
        }
        //Debug.Log("DIRECT DAMAGE: Timer is Done.");
        _runPersist = false;
        _donePersist = true;
        //Debug.Log("DIRECT DAMAGE: Done with Coroutine");
        yield break;
    }
}
