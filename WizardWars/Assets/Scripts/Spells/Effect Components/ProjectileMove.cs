using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : Effect {
    public Rigidbody _rigidbody;
    public GameObject _signalPrefab;

    public Transform _originPosition;
    public Transform _targetPosition;
    int _targetNumber;

    public float _speed;
    public Vector3 _direction;
    public float _range;

    public uint _signal;

    public bool _disperseOnContact;

    public bool _collidedWithValid = false;
    public bool _collidedWithTarget = false;
    public bool _collidedWithPosition = false;
    public bool _outOfRange = false;
    public bool _startedMove = false;

    [SerializeField]
    public float _distanceMoved
    {
        get
        {
            Debug.Log("Origin position: " + _originPosition.position);
            Debug.Log("Current position: " + transform.position);
            Debug.Log("Distance Traveled: " + Vector3.Distance(_originPosition.position, transform.position));
            return Vector3.Distance(_originPosition.position, transform.position);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
    void OnEnable()
    {
        Initialize();
        _direction = (_originPosition.position - _targetPosition.position).normalized;

        //Create a signal object
        GameObject signal = (GameObject)Instantiate(_signalPrefab, _targetPosition.position, new Quaternion());
        signal.GetComponent<Signal>()._id = Signal._nextID;

        if(!_startedMove)
        {
            DoDiscrete();
        }
    }
	// Update is called once per frame
	void Update () {
        if (Done())
        {
            Stop();
            return;
        }
        
		if(_distanceMoved >= _range)
        {
            _outOfRange = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Got collision!");
        if (!this.enabled) return;
        if (Done()) return;
        if (Utilities.Effects.IsValidTarget(gameObject, other.gameObject, _targetNumber, _type, _isTargeted))
        {
            Debug.Log("Found a valid target or the target");
            _collidedWithValid = true;
            if (_isTargeted)
                _collidedWithTarget = true;
        }
        if(Utilities.Effects.IsValidTarget(gameObject, other.gameObject, _targetNumber, Enums.Spells.Target.SIGNAL, false))
        {
            Debug.Log("Found the signal");
            _collidedWithValid = true;
            _collidedWithTarget = true;
            _collidedWithPosition = true;
        }
    }

    public void Stop()
    {
        _rigidbody.velocity *= 0;
    }

    public override IEnumerator DoContinuous()
    {
        //Cannot do continuous projectile move
        yield break;
    }

    public override void DoDiscrete()
    {
        Debug.Log("Do Discrete");
        //Move this projectile
        Vector3 force = _direction;
        force *= _speed;
        //_rigidbody.AddForce(force);
        _startedMove = true;

        _rigidbody.velocity = force * -1;
    }

    public override bool Done()
    {
        if (_outOfRange)
        {
            return true;
        }
        else if (_disperseOnContact)
        {
            if (_isTargeted)
            {
                return _collidedWithTarget;
            }
            else
            {
                return _collidedWithValid || _collidedWithPosition;
            }
        }
        else
        {
            if (_isTargeted)
            {
                return _collidedWithTarget;
            }
            else
            {
                return _collidedWithPosition;
            }
        }
    }

    public override void Initialize()
    {
        _isPersistent = false;
        _isProjectile = true;
    }
}
