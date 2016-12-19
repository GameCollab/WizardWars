using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : Effect {
    public Enums.Players.Attribute _attribute;
    public float _change;

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
        //Find attribute
        //Add change to it
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
