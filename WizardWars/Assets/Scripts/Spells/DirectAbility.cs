using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectAbility : Ability {


    // Use this for initialization
    void Start () {
		
	}
	
	void OnEnable() {
        _isTargeted = true;
        if (_type == Enums.Cards.Ability.DISRUPT || _type == Enums.Cards.Ability.DISPLACE)
            _isPersistent = false;

        if (_isPersistent)
        {
            if (!_runningPersistent)
            {
                _timer = 0f;
                _runningPersistent = true;
                StartCoroutine(DoContinuous());
            }  
        }
        else
        {
            DoDiscrete();
        }
    }

    public override bool Done()
    {
        return _isPersistent ? _doneWithPeristent : _doneWithDiscrete;
    }

    public override void DoDiscrete()
    {
        GameObject target = Utilities.ManagerAccess.GetPlayerByNumber(_targetNumber);
        Apply(target);
        _doneWithDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        while (!Utilities.Misc.IsTimerDone(_timer, _duration))
        {
            GameObject target = Utilities.ManagerAccess.GetPlayerByNumber(_targetNumber);
            Apply(target);
            _timer += 1f;
            _power -= _powerDropOff;
            yield return new WaitForSeconds(1);
        }
        _runningPersistent = false;
        _doneWithPeristent = true;
        yield break;
    }
}
