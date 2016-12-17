using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_001_Fireball : ProjectileBehavior, IMovable, IDispersible, IDamager<float> {
    //Explosion stuff

    //Burning Ground stuff

    bool _isMoving = false;
	// Use this for initialization
	void Start () {
        //Initialize stuff

	}
	
	// Update is called once per frame
	void Update () {
        if(!_isMoving)
        {
            Move(_speed, _direction);
        }
        //If out or range
        if (outOfRange())
        {
            Destroy(this);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.CompareTo(_collisionLayer) == 0) //Collided with a valid target.
        {
            Damage(_cardRef._damage);
            Disperse();
        }
    }

    void OnDestroy()
    {
        //Create explosion
        //If Molten Crater was active, create Burning Ground at position
    }

    public void Move(float value, Vector3 direction)
    {
        
    }

    public void Disperse()
    {
        Destroy(this);
    }

    public void Damage<T>(T amount)
    {
        //Calculate true damage
        //Calculate reduction
        //Deal that much damage
        //Calculate knockback - resist
        //Knockback by that much
    }
}
