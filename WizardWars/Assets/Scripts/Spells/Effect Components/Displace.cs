using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Displace : Effect {
    public float _magnitude;
    public Transform _displacePoint;
    public Vector3 _force
    {
        get
        {
            return (_displacePoint.position - transform.position).normalized * _magnitude;
        }
    }

    public bool _instant;

    protected void ApplyDisplacement(GameObject player)
    {
        IMovable move = Utilities.Interfaces.GetMovable(player);
        if (move != null)
        {
            _displacePoint = player.transform;
            move.Move(_force);
        }
    }
}
