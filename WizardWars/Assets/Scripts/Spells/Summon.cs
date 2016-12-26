using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Effect {
    public uint _summonObject;

    void Start()
    {

    }

    void OnEnable()
    {
        _target = Enums.Cards.Target.NONE;
        _isTargeted = false;
        DoDiscrete();
    }

    public override void DoDiscrete()
    {
        GameObject summonThis = Utilities.ManagerAccess.GetObjectById(_summonObject);
        GameObject summonedObject = (GameObject)Instantiate(summonThis, _pointOfEffect.position, Quaternion.identity);
        summonedObject.GetComponent<SummonObject>().CastSpell(_targetNumber, _targetPosition, _pointOfEffect, _casterNumber);
        _doneWithDiscrete = true;
    }

    public override bool Done()
    {
        return _doneWithDiscrete;
    }
}
