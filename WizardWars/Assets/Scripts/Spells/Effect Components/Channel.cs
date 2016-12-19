using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : Effect
{
    public Enums.Spells.Interrupt _interrupt;

    public bool _isInterrupted; // Outsiders should check this flag to see the status.

    void OnEnable()
    {
        Initialize();
        if(!Done() && !_runPersist)
        {
            StartCoroutine(DoContinuous());
        }
    }

    public bool CheckForInterrupts()
    {
        switch (_interrupt)
        {
            case Enums.Spells.Interrupt.ANY:
                //If you have a Disable of type Stun, Silence, or Stasis, return true;
                //If you have the flags: moving, casting true, return true;
                return false;
            case Enums.Spells.Interrupt.SELF:
                //Check only flags for moving and cast
                return false;
            default:
                return false;
        }
    }

    public override IEnumerator DoContinuous()
    {
        while (!Utilities.Misc.IsTimerDone(_timer, _duration))
        {
            _isInterrupted = CheckForInterrupts();
            if (_isInterrupted)
            {
                _runPersist = false;
                _donePersist = true;
                yield break;
            }
            _timer += _timeBetweenTicks;
            yield return new WaitForSeconds(_timeBetweenTicks);
        };
        _runPersist = false;
        _donePersist = true;
        yield break;
    }

    public override void DoDiscrete()
    {
        //You cannot just check for channel interrupt once.
    }

    public override bool Done()
    {
        return _donePersist; //Channel is done whether it is successful or interrupted
    }

    public override void Initialize()
    {
        _isPersistent = true;
        _isProjectile = false;
        _isTargeted = true;
    }
}
