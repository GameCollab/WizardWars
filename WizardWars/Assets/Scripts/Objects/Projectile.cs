using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : SummonObject
{
    public ProjectileMove _moveEffect;

    protected void ActivateMove()
    {
        _moveEffect.enabled = true;
    }

    protected void Initialize()
    {
        _type = Enums.Objects.Type.PROJECTILE;
    }
}
