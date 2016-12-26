using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour {
    public Enums.Cards.Target _target;
    public bool _isTargeted;
    [HideInInspector]
    public Transform _pointOfEffect;
    [HideInInspector]
    public int _casterNumber;
    [HideInInspector]
    public int _targetNumber;
    [HideInInspector]
    public Transform _targetPosition;
    [HideInInspector]
    public bool _doneWithDiscrete = false;

    protected bool IsValidTarget(GameObject target, Enums.Cards.Target type)
    {
        if (_isTargeted)
        {
            //Check if the target given is indeed our target
            return _targetNumber == target.GetComponent<PlayerStats>()._playerNumber;
        }
        else
        {
            switch (type)
            {
                case Enums.Cards.Target.ANY:
                    //Check if the target is a player
                    return target.CompareTag(Constants.Tags.PLAYER_TAG);
                case Enums.Cards.Target.NOT_SELF:
                    //Check if the target is a player AND not the caster
                    return target.CompareTag(Constants.Tags.PLAYER_TAG) && target.GetComponent<PlayerStats>()._playerNumber != _casterNumber;
                case Enums.Cards.Target.SELF:
                    //Check if the target is the caster
                    return target.GetComponent<PlayerStats>()._playerNumber == _casterNumber;
                case Enums.Cards.Target.SIGNAL:
                    //Check if the target is instead a signal
                    Signal source = target.GetComponent<Signal>();
                    ProjectileMove moving = GetComponent<ProjectileMove>(); //Is this ability a projectile?
                    if (source == null || moving == null) return false;
                    return source._id == moving._signal;
                default:
                    Debug.LogError("Bad Target Type!");
                    break;
            }
            return false;
        }
    }

    public abstract bool Done();

    public abstract void DoDiscrete();
}
