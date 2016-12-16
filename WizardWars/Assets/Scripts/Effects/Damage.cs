using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Damage : MonoBehaviour {
    public float _damage;
    public float _damageBonus;
    public float _knockback;

    public LayerMask _collideLayer;

    public Transform _origin;

    public float _trueDamage
    {
        get
        {
            return _damage + (_damage * _damageBonus);
        }
    }
    public float _trueKnockBack
    {
        get
        {
            return _knockback * _trueDamage;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Check if this projectile can deal damage to the collider
        if (other.gameObject.layer.CompareTo(_collideLayer) != 0)
            return;

        //Check if the object is damagable, and deal damage
        IDamagable<float> damagable = other.gameObject.GetComponent(typeof(IDamagable<float>)) as IDamagable<float>;
        if (damagable == null) return;
        damagable.TakeDamage(_trueDamage);

        //Check if the object is pushable, and apply knockback
        IForceable forceable = other.gameObject.GetComponent(typeof(IForceable)) as IForceable;
        if (forceable == null) return;
        forceable.Push(_trueKnockBack, _origin);
    }
}
