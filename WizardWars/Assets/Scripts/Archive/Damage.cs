using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
/*
public class Damage : MonoBehaviour {
    public float _damage;
    public float _damageBonus;
    public float _knockback;

    public LayerMask _collideLayer;

    public Transform _knockBackPoint;

    public bool _forProjectile;

    public float _trueDamage
    {
        get
        {
            return _damage + (_damage * _damageBonus);
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
        if (!_forProjectile) return;

        //Check if this projectile can deal damage to the collider
        if (other.gameObject.layer.CompareTo(_collideLayer) != 0)
            return;

        dealDamage(other.gameObject);
    }

    //For non-projectile damaging (probably never going to be used)
    public void damage(GameObject target)
    {
        if (_forProjectile) return;

        dealDamage(target);
    }

    void dealDamage(GameObject target)
    {
        IDamagable<float> damagable = target.GetComponent(typeof(IDamagable<float>)) as IDamagable<float>;
        if (damagable == null) return;
        damagable.TakeDamage(_trueDamage);

        //Check if the object is pushable, and apply knockback
        IForceable forceable = target.GetComponent(typeof(IForceable)) as IForceable;
        if (forceable == null) return;
        forceable.Push(_knockback, _knockBackPoint);
    }
}
*/