using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour {
    public uint _cardID;
    public GameObject _target;
    public GameObject _user;
    public Transform _targetLocation;


    protected Card _cardRef
    {
        get
        {
            return CardDatabase.cardDatabase[_cardID];
        }
    }
    protected bool _isSkillShot
    {
        get
        {
            return _cardRef._target == Constants.SpellTarget.SKILLSHOT;
        }
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
