using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stationary : SummonObject {

    public bool _isCollidable;
    public bool _isContinuous;


    protected void Initialize()
    {
        _type = Enums.Objects.Type.STATIONARY;
    }
}
