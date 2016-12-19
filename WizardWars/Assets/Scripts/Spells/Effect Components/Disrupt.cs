using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Disrupt : Effect {
    public uint _status;

    protected void ApplyDisruption(GameObject player)
    {
        IControllable control = Utilities.Interfaces.GetControllable(player);
        //Debug.Log(control);
        if (control != null)
        {
            control.ApplyStatus(_status, _casterNumber, _spellID);
        }
    }
}
