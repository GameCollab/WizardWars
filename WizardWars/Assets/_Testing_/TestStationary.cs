using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class TestStationary : Stationary {
    public AreaDisplace _displaceEffect;

    public AreaDamage _onDeathEffect;

    // Use this for initialization
    void Start () {
        Initialize();
        DoEffect(-1, transform, transform);
	}
	
	// Update is called once per frame
	void Update () {
        if (_displaceEffect.Done())
        {
            _onDeathEffect.enabled = true;
        }
        if (_onDeathEffect.Done())
        {
            Destroy(gameObject);
        }
	}

    public override void DoEffect(int targetNumber, Transform targetPosition, Transform castPosition)
    {
        //Ignore targetPosition. 
        //This Test Stationary will apply a small force to all Players around it towards it continuously.

        _displaceEffect.enabled = true; //This should do pulling of all Players around it.
    }

}
*/
