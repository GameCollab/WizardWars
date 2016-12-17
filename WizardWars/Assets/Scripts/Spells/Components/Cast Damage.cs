using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastDamage : Damage {

    public Constants.SpellCast _cast;
    public Vector3 _castPoint;
    public float _castValue;
    public float _secondaryValue;
    public float _range;

    public bool _includeContact;

    public float _duration;

    public Vector3 _direction;

    public bool _canDoDamage;

    public bool _startedDot = false;

    public float _internalClock = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_canDoDamage)
        {
            if (!_didDamage)
            {
                List<GameObject> valid = CreateCast();
                foreach (var item in valid)
                {
                    DealDamage(item);
                }
            }
            else if(_duration > 0 && _startedDot)
            {
                StartCoroutine("DealContinuousDamage");

                _startedDot = true;
            }
        }
        if (_internalClock > _duration)
        {
            StopCoroutine("DealContinuousDamage");
        }
    }

    public override void DealDamage(GameObject here)
    {
        IDamageable<float> d = GetDamageable(here);
        if (d != null)
        {
            d.TakeDamage(_damage);
        }

    }

    public IEnumerator DealContinuousDamage()
    {
        while(_internalClock <= _duration)
        {
            List<GameObject> valid = CreateCast();
            foreach (var item in valid)
            {
                DealDamage(item);
            }
            yield return new WaitForSeconds(1);
            _internalClock += 1f;
        }
       
        yield return null;
    }

    public List<GameObject> CreateCast()
    {
        switch (_cast)
        {
            case Constants.SpellCast.LINE: return Utilities.GetAllTypeInLine(_castValue, _range, _direction, _castPoint, _validTargetTag);
            case Constants.SpellCast.CONE: return Utilities.GetAllTypeInCone(_castValue, _range, _direction, _castPoint, _validTargetTag);
            case Constants.SpellCast.MULTILINE: return Utilities.GetAllTypeInMultiLine((int)_castValue, _secondaryValue, _range, _direction, _castPoint, _validTargetTag);
            case Constants.SpellCast.CIRCLE: return Utilities.GetAllTypeInCircle(_castValue, _castPoint, _validTargetTag);
            case Constants.SpellCast.RECTANGLE: return Utilities.GetAllTypeInRectangle(_castValue, _secondaryValue, _castPoint, _validTargetTag);
            case Constants.SpellCast.NOVA: return Utilities.GetAllTypeInCircle(_castValue, _castPoint, _validTargetTag);
            default: return null;
        }
    }
}
