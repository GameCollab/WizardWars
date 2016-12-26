using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : Effect {
    public GameObject _signalPrefab;
    public float _speed;
    public float _range;
    public bool _disperseOnContact;
    public bool _disperseOnRange;

    [HideInInspector]
    public Transform _originPosition;
    [HideInInspector]
    public uint _signal;
    [HideInInspector]
    public bool _collidedWithValidFlag, _collidedWithTargetFlag, _collidedWithPositionFlag, _outOfRangeFlag;
    Rigidbody _rigidbody;

    [SerializeField]
    public float _distanceMoved
    {
        get
        {
            return Vector3.Distance(_originPosition.position, this.transform.position);
        }
    }
    [SerializeField]
    public Vector3 _direction
    {
        get
        {
            return (_originPosition.position - _targetPosition.position).normalized;
        }
    }
    
    void Start () {
		
	}
	
    void OnEnable()
    {
        if (!_isTargeted)
        {
            CreateSignal();
        }

        DoDiscrete();
    }

	void Update () {
        if (Done())
        {
            Stop();
            return;
        }
        else
        {
            if (_distanceMoved >= _range)
            {
                _outOfRangeFlag = true;
            }
            else if (_isTargeted)
            {
                AcquireTarget();
                UpdateDirection();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!this.enabled || Done()) return;
        if (IsValidTarget(other.gameObject, _target))
        {
            _collidedWithValidFlag = true;
            if (_isTargeted)
                _collidedWithTargetFlag = true;
        }
        if (IsValidTarget(other.gameObject, Enums.Cards.Target.SIGNAL))
        {
            _collidedWithValidFlag = true;
            _collidedWithTargetFlag = true;
            _collidedWithPositionFlag = true;
        }
    }

    private void Stop()
    {
        _rigidbody.velocity *= 0;
    }

    private void AcquireTarget()
    {
        GameObject target = Utilities.ManagerAccess.GetPlayerByNumber(_targetNumber);
        _targetPosition = target.transform;
    }

    private void UpdateDirection()
    {
        Vector3 force = _direction;
        force *= _rigidbody.velocity.magnitude;
        _rigidbody.velocity = force * -1;
    }

    private void CreateSignal()
    {
        GameObject signal = (GameObject)Instantiate(_signalPrefab, _targetPosition.position, Quaternion.identity);
        signal.GetComponent<Signal>()._id = Signal._nextID;
        _signal = signal.GetComponent<Signal>()._id;
    }

    public override bool Done()
    {
        if (_disperseOnRange && _outOfRangeFlag)
        {
            return true;
        }
        if (_disperseOnContact)
        {
            if (_isTargeted)
            {
                return _collidedWithTargetFlag;
            }
            else
            {
                return _collidedWithValidFlag || _collidedWithPositionFlag;
            }
        }
        else
        {
            if (_isTargeted)
            {
                return _collidedWithTargetFlag;
            }
            else
            {
                return _collidedWithPositionFlag;
            }
        }
    }

    public override void DoDiscrete()
    {
        //Move this projectile
        Vector3 force = _direction;
        force *= _speed;
        _rigidbody.velocity = force * -1;
    }
}
