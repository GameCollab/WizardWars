using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectHeal : Heal {

    // Use this for initialization
    void Start () {
		
	}
	
	void OnEnable()
    {
        Initialize();

        if (_isPersistent && !_donePersist && !_runPersist)
        {
            _timer = 0f;
            _runPersist = true;
            StartCoroutine(DoContinuous());
        }
        else if (!_isPersistent && !_doneDiscrete)
        {
            DoDiscrete();
        }

    }

    public override bool Done()
    {
        return _isPersistent ? _donePersist : _doneDiscrete;
    }

    public override void Initialize()
    {
        _isTargeted = true;
        _isProjectile = false;
    }

    public override void DoDiscrete()
    {
        GameObject target = Utilities.Misc.GetTarget(_targetNumber, _type, _casterNumber);
        ApplyHeal(target);

        _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        while (!Utilities.Misc.IsTimerDone(_timer, _duration))
        {
            // Get player info via targetNumber
            // Run Player's take damage function
            GameObject target = Utilities.Misc.GetTarget(_targetNumber, _type, _casterNumber);
            ApplyHeal(target);
            _timer += _timeBetweenTicks;
            _restore += _restoreChange;
            yield return new WaitForSeconds(_timeBetweenTicks);
        }
        _runPersist = false;
        _donePersist = true;
        yield break;
    }
}
