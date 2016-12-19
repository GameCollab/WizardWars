using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour {

    public Enums.Spells.Target _type;

    public float _duration = 0f;
    public float _timer = 0f;

    public bool _isProjectile;
    public bool _isTargeted;
    public bool _isPersistent;  //If this is false, don't bother with duration, timer, donePersist, runPersist

    public bool _doneDiscrete = false;
    public bool _donePersist = false;

    public bool _runPersist = false;

    public int _casterNumber = 0;

    public abstract bool Done();

    public abstract void Initialize();

    public abstract void DoDiscrete();

    public abstract IEnumerator DoContinuous();
}
