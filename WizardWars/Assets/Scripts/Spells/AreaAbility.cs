using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAbility : Ability {
    Enums.Cards.Cast _cast;
    float _castSize;
    float _arrowNumber;

    void Start()
    {

    }

    void OnEnable()
    {
        _isTargeted = true;

        if (_isPersistent)
        {
            if (!_runningPersistent)
            {
                _timer = 0f;
                _runningPersistent = true;
                StartCoroutine(DoContinuous());
            }
        }
        else
        {
            DoDiscrete();
        }
    }

    public override IEnumerator DoContinuous()
    {
        while (!Utilities.Misc.IsTimerDone(_timer, _duration))
        {
            List<GameObject> targets = Utilities.Effects.GetAllOfTypeInCast(_cast, _pointOfEffect.position, _castSize, _arrowNumber, Utilities.EnumUtil.GetStringTag(_target));
            Debug.Log("List length: " + targets.Count);
            foreach (var target in targets)
            {
                Apply(target);
            }

            _timer += 1f;
            _power -= _powerDropOff;
            yield return new WaitForSeconds(1);
        }
        _runningPersistent = false;
        _doneWithPeristent = true;
        yield break;
    }

    public override void DoDiscrete()
    {
        List<GameObject> targets = Utilities.Effects.GetAllOfTypeInCast(_cast, _pointOfEffect.position, _castSize, _arrowNumber, Utilities.EnumUtil.GetStringTag(_target));
        foreach (var target in targets)
        {
            Apply(target);
        }

        _doneWithDiscrete = true;
    }

    public override bool Done()
    {
        return _isPersistent ? _doneWithPeristent : _doneWithDiscrete;
    }
}
