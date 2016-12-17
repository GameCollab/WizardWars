using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedDamage : Damage {

    GameObject _target;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Check if other is the same player number as target, and if not already did damage
        {
            DealDamage(other.gameObject);
        }
    }

    public override void DealDamage(GameObject here)
    {
        IDamageable<float> damageable = GetDamageable(here);
        if(damageable == null)
        {
            Debug.Log("Uh oh. We are trying to deal damage to something that cannot take damage." +
                "IN: dealDamage function " + this.ToString());
            return;
        }
        damageable.TakeDamage(_damage);
        _didDamage = true;
    }
}
