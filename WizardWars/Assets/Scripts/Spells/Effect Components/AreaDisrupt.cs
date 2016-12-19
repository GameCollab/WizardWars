using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDisrupt : Disrupt {

    public Vector3 _castPoint;

    public Enums.Spells.Cast _area;
    public float _areaSize;
    public float _secondaryAreaValue;

    // Use this for initialization
    void Start()
    {
        
    }

    void OnEnable()
    {
        Initialize();
        if (_isPersistent && !_donePersist && !_runPersist)
        {
            _timer = 0f;
            _runPersist = true;
            StartCoroutine(DoContinuous());
        }
        else if (!_isPersistent && !_doneDiscrete)
        {
            DoDiscrete();
        }
    }

    public override bool Done()
    {
        return _isPersistent ? _donePersist : _doneDiscrete;
    }

    public override void Initialize()
    {
        _isProjectile = false;
        _isTargeted = false;
    }

    public override void DoDiscrete()
    {
        List<GameObject> targets = Utilities.Effects.GetAllOfTypeInCast(_area, _castPoint, _areaSize, _secondaryAreaValue, Utilities.EnumUtil.GetStringTag(_type));
        Debug.Log("List length: " + targets.Count);
        foreach (var target in targets)
        {
            ApplyDisruption(target);
        }

        _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        while (!Utilities.Misc.IsTimerDone(_timer, _duration))
        {
            // Get player info via targetNumber
            // Run Player's take damage function
            List<GameObject> targets = Utilities.Effects.GetAllOfTypeInCast(_area, _castPoint, _areaSize, _secondaryAreaValue, Utilities.EnumUtil.GetStringTag(_type));
            Debug.Log("List length: " + targets.Count);
            foreach (var target in targets)
            {
                ApplyDisruption(target);
            }

            _timer += _timeBetweenTicks;
            yield return new WaitForSeconds(_timeBetweenTicks);
        }
        _runPersist = false;
        _donePersist = true;
        yield break;
    }
}
