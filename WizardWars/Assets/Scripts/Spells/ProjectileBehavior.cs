using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : SpellBehavior {

    public float _speed;
    public float _maxSpeed;
    public float _range;
    public Vector3 _origin;
    public Vector3 _direction;

    public LayerMask _collisionLayer;

    bool _atTarget = false;


    Rigidbody _rb;
    SphereCollider _col;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void init()
    {
        _speed = _cardRef._missileSpeed;
        _maxSpeed = _cardRef._missileSpeed;
        _range = _cardRef._range;
        _origin = _user.transform.position;
        _direction = (_targetLocation.position - _origin).normalized;

        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();
    }

    public bool outOfRange()
    {
        return Vector3.Distance(_origin, transform.position) > _range;
    }
}
