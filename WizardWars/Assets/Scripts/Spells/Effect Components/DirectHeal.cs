using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectHeal : Heal {
    public int _targetNumber;

    // Use this for initialization
    void Start () {
		
	}
	
	void OnEnable()
    {
        Initialize();

        if (!Done())
        {
            if (!_runPersist)
            {
                _timer = 0f;
                _runPersist = true;
                StartCoroutine(RegenerateHealth());
            }
        }
        else if (!Done())
        {
            RestoreHealth();
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

    public override IEnumerator RegenerateHealth()
    {
        while (!Utilities.Misc.IsTimerDone(_timer, _duration))
        {
            // Get player info via targetNumber
            // Run Player's take damage function
            GameObject target = Utilities.Misc.GetPlayerByNumber(_targetNumber);
            ApplyHeal(target);
            _timer += 1f;
            _restore += _restoreChange;
            yield return new WaitForSeconds(1);
        }
        _runPersist = false;
        _donePersist = true;
        yield break;
    }

    public override void RestoreHealth()
    {
        GameObject target = Utilities.Misc.GetPlayerByNumber(_targetNumber);
        ApplyHeal(target);

        _doneDiscrete = true;
    }
}
