using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : Effect {
    public Enums.Cards.Ability _type;
    public bool _isPersistent;
    public bool _isInstant;
    public float _duration;
    public uint _status;
    public float _power;
    public float _powerDropOff;


    [HideInInspector]
    public bool _doneWithPeristent;
    [HideInInspector]
    public bool _runningPersistent;
    [HideInInspector]
    public float _timer;

    public abstract IEnumerator DoContinuous();

    protected void Apply(GameObject target)
    {
        if (!IsValidTarget(target, _target)) return;
        switch (_type)
        {
            case Enums.Cards.Ability.DAMAGE:
                Damage(target);
                break;
            case Enums.Cards.Ability.HEAL:
                Heal(target);
                break;
            case Enums.Cards.Ability.DISRUPT:
                Disrupt(target);
                break;
            case Enums.Cards.Ability.DISPLACE:
                Displace(target);
                break;
            default:
                Debug.LogError("Bad Ability Type. Given: " + _type);
                break;
        }
    }

    protected void Damage(GameObject target)
    {
        IDamageable intf = Utilities.Interfaces.GetDamageable(target);
        if (intf != null)
        {
            intf.TakeDamage(_power);
        }
    }

    protected void Heal(GameObject target)
    {
        IHealable intf = Utilities.Interfaces.GetHealable(target);
        if (intf != null)
        {
            intf.Heal(_power);
        }
    }

    protected void Disrupt(GameObject target)
    {
        IControllable intf = Utilities.Interfaces.GetControllable(target);
        if (intf != null)
        {
            intf.ApplyStatus(_status, _casterNumber);
        }
    }

    protected void Displace(GameObject target)
    {
        IMovable intf = Utilities.Interfaces.GetMovable(target);
        if (intf != null)
        {
            if (_isInstant)
            {
                intf.Teleport(_targetPosition.position);
            }
            else
            {
                Vector3 direction = (target.transform.position - _pointOfEffect.position).normalized;
                intf.Push(direction * _power);
            }
        }
    }
}
