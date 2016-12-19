using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Disrupt : Effect {
    public GameObject _status;

    protected void ApplyDisruption(GameObject player)
    {
        IControllable control = Utilities.Interfaces.GetControllable(player);
        //Debug.Log(control);
        if (control != null)
        {
            GameObject copy = (GameObject)Instantiate(_status);
            control.ApplyStatus(copy, _casterNumber);
        }
    }
}
