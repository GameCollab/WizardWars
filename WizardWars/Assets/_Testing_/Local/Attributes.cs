using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes {
    float _health;
    float _speed;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if(value >= 0)
                _health = value;
        }
    }
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            if (value >= 0)
                _speed = value;
        }
    }
}
