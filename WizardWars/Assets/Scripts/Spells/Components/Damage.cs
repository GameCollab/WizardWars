using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damage : MonoBehaviour {
    /* Fields */
    public float _damage;
    public float _knockback;
    public Constants.SpellTarget _targetType;

    public string _validTargetTag;

    public Transform _knockbackPoint;
    

    public bool _isProjectile;
    public bool _isTargeted;

    public bool _didDamage = false;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void DealDamage(GameObject here);

    public IDamageable<float> GetDamageable(GameObject d)
    {
        return d.GetComponent(typeof(IDamageable<float>)) as IDamageable<float>;
    }
}
