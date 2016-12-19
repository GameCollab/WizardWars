using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDisplace : Displace {

	void Start () {
		
	}

    void OnEnable()
    {
        //Debug.Log("DIRECT DAMAGE: ON ENABLE!");
        Initialize();

        if (_isPersistent && !_donePersist && !_runPersist)
        {
            //Debug.Log("DIRECT DAMAGE: Dealing Continuous Damage");
            _timer = 0f;
            _runPersist = true;
            StartCoroutine(DoContinuous());
            //Debug.Log("DIRECT DAMAGE: Control out of Coroutine.");
        }
        else if (!_isPersistent && !_doneDiscrete)
        {
            //Debug.Log("DIRECT DAMAGE: Dealing Discete Damage");
            DoDiscrete();
        }
    }

    public override bool Done()
    {
        return _isPersistent ? _donePersist : _doneDiscrete;
    }

    public override void Initialize()
    {
        //Debug.Log("DIRECT DAMAGE: Initialized!");
        _isTargeted = true;
        _isProjectile = false;
        _isPersistent = false;
    }

    public override void DoDiscrete()
    {
        // Get player info via targetNumber
        // Run Player's take damage function
        //GameObject target = new GameObject();
        GameObject target = Utilities.Misc.GetTarget(_targetNumber, _type, _casterNumber);
        ApplyDisplacement(target);

        _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        //Continuous Displacement only occurs in Area
        yield break;
    }
}
