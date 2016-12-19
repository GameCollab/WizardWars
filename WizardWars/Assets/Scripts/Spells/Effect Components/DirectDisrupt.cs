using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDisrupt : Disrupt {

	// Use this for initialization
	void Start () {
		
	}
	
    void OnEnable()
    {
        Initialize();

        if (!Done())
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
        _isPersistent = false;
    }

    public override void DoDiscrete()
    {
        GameObject target = Utilities.Misc.GetTarget(_targetNumber, _type, _casterNumber);
        //Debug.Log("Got disrupt target: " + target + "\n");
        ApplyDisruption(target);

        _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        //Direct Disruptions cannot be continuous
        yield break;
    }
}
