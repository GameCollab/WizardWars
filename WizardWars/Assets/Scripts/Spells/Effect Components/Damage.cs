using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Generic Damage Effect */
public abstract class Damage : MonoBehaviour
{
    public float _damage = 0f;
    public float _damageChange = 0f;
    public Enums.Spells.Target _type = Enums.Spells.Target.NONE;

    public float _duration = 0f;
    public float _timer = 0f;

    public bool _isProjectile = false;
    public bool _isTargeted = false; 
    public bool _isPersistent = false;  //If this is false, don't bother with duration, timer, donePersist, runPersist

    public bool _doneDiscrete = false;
    public bool _donePersist = false;

    public bool _runPersist = false;

    public int _casterNumber = 0;

    /* Abstract Discrete Deal Damage */
    public abstract void DealDamage();

    /* Abstract Continuous Deal Damage */
    public abstract IEnumerator DealContinuousDamage();

    public abstract bool Done();

    public abstract void Initialize();

    protected void ApplyDamage(GameObject player)
    {
        IDamageable<float> dmg = GetInterface(player);
        if(dmg != null)
        {
            dmg.TakeDamage(_damage);
        }
    }



    public IDamageable<float> GetInterface(GameObject obj)
    {
        return obj.GetComponent(typeof(IDamageable<float>)) as IDamageable<float>;
    }
}