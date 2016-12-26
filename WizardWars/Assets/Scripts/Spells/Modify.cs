using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modify : Effect {
    public bool _modifyCard;
    public uint _cardToModify;
    public uint _modificationID;
    public Enums.Players.Attribute _stat;
    public float _modificationAmount;

    void Start()
    {

    }

    void OnEnable()
    {
        _isTargeted = true;
        DoDiscrete();
    }

    public override void DoDiscrete()
    {
        if (_modifyCard)
        {
            //Get player deck info.
            //Get card modifiers list via card ID
            //Set boolean of this modicationID
        }
        else
        {
            //Get player stats info
            //Set Attribute += amount
        }
        _doneWithDiscrete = true;
    }

    public override bool Done()
    {
        return _doneWithDiscrete;
    }
}
