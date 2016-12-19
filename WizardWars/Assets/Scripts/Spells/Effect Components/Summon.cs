using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Effect {
    public uint _whatToSummon;

    public Transform _summonPoint;

    public GameObject _summonedObject;

    public float _delayInSeconds;

    public bool _cancelSummon = false;

    // Use this for initialization
    void Start () {
		
	}
	
	void OnEnable()
    {
        Initialize();

        if (!Done())
        {
            StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        Debug.Log("Waiting for seconds");
        yield return new WaitForSeconds(_delayInSeconds);
        if (_cancelSummon) yield break;
        DoDiscrete();
        yield break;
    }
    public override IEnumerator DoContinuous()
    {
        //There is no continuous summon
        yield break;
    }

    public override void DoDiscrete()
    {
        GameObject summonThis = Utilities.ManagerAccess.GetObjectById(_whatToSummon);
        _summonedObject = (GameObject)Instantiate(summonThis, _summonPoint.position, new Quaternion());
        _doneDiscrete = true;
    }

    public override bool Done()
    {
        return _doneDiscrete;
    }

    public override void Initialize()
    {
        _isTargeted = false;
        _isPersistent = false;
        _isProjectile = false;
        _type = Enums.Spells.Target.NONE;
    }
}
