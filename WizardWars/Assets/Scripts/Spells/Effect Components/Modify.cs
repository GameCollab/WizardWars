using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modify : Effect {
    public uint _cardToModify;
    public uint _modificationID;

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
        //Find the card via cardToModify
        //Find the boolean for this modification
        //Set it to true
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
