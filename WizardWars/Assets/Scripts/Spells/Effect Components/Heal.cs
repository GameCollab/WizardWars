using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Heal : MonoBehaviour
{
    public float _restore;
    public float _restoreChange;
    public Enums.Spells.Target _type;

    public float _duration;
    public float _timer;

    public bool _isProjectile = false;
    public bool _isTargeted = false;
    public bool _isPersistent = false;  //If this is false, don't bother with duration, timer, donePersist, runPersist

    public bool _doneDiscrete = false;
    public bool _donePersist = false;

    public bool _runPersist = false;

    public int _casterNumber = 0;

    /* Abstract Discrete Deal Damage */
    public abstract void RestoreHealth();

    /* Abstract Continuous Deal Damage */
    public abstract IEnumerator RegenerateHealth();

    public abstract bool Done();

    public abstract void Initialize();

    protected void ApplyHeal(GameObject player)
    {
        IHealable heal = Utilities.Interfaces.GetHealable(player);
        if (heal != null)
        {
            heal.Heal(_restore);
        }
    }
}
