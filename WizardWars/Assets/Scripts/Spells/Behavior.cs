using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Base Behavior */
public abstract class Behavior : MonoBehaviour {
    /* What created this Behavior */
    public uint _refID = 0;
    public Card _refCard;
    public GameObject _target;
    public GameObject _origin; //Where the behavior came from

    /* How does this behavior behave? */
    public Constants.BehaviorType _type; //What kind of behavior is it?
    public Constants.SpellTarget _targetType; //How should the behavior target?

    public Component[] _components; //Load this up via inspector

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void getCard()
    {
        _refCard = CardDatabase.cardDatabase[_refID];
    }

    public abstract void castSpell();
}
