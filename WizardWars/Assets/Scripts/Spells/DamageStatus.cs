using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageStatus : Status {
    public DirectDamage _continuousDamageEffect; //Set to inactive. ALL effects must be inactive at start

    public float _damagePerSecond;


    void Awake()
    {
        _type = Enums.Statuses.Type.DAMAGE;
        _isInvertible = false;
        _isPermanent = false;
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void DoEffect(Vector3 targetPosition, int originNumber)
    {
        //Statuses MUST have a target player.
        //Do nothing
    }

    public override void DoEffect(int targetNumber, int originNumber)
    {
        _continuousDamageEffect._targetNumber = targetNumber;
        _continuousDamageEffect._casterNumber = originNumber;
        _continuousDamageEffect.enabled = true;
    }

    public override void DoInverse()
    {
        //Ongoing Damage Statuses cannot be inverted
        //Do nothing
    }

    public override bool Done()
    {
        return !_isPermanent && _continuousDamageEffect.Done();
    }
}
