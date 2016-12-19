using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : Effect {
    public Enums.Statuses.Disable _disable;

    public bool _isEnabler; //If you want to set it to false instead

    void OnEnable()
    {
        Initialize();

        if (!Done())
        {
            DoDiscrete();
        }
    }

    public override IEnumerator DoContinuous()
    {
        yield break;
    }

    public override void DoDiscrete()
    {
        //Get the target player info
        //Find the boolean attributed to the disable
        //Set it to isEnabler ? false : true
        _doneDiscrete = true;
    }

    public override bool Done()
    {
        return _doneDiscrete;
    }

    public override void Initialize()
    {
        _isPersistent = false;
        _isProjectile = false;
        _isTargeted = true;
    }
}
