using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : Effect {
    public Enums.Statuses.Disable _disable;

    void OnEnable()
    {
        _isTargeted = true;

        DoDiscrete();
    }

    public override void DoDiscrete()
    {
        //Get the target player info
        //Find the boolean attributed to the disable
        //Toggle it
        _doneWithDiscrete = true;
    }

    public override bool Done()
    {
        return _doneWithDiscrete;
    }
}
