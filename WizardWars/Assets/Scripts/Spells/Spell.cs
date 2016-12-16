using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour {
    public string _name;
    public uint _id;
    public string _description;

    public Constants.CardType _type;
    public Constants.CardClass _class;
    public Constants.CardRarity _rarity;

    public float _damage;
    public float _knockback;
    public float _duration;
    public float _channel;
    public float _range;
    public float _castRange;
    public float _missileSpeed;
    public float _cooldown;
    public Constants.Tag[] _tags;

    public Constants.SpellType _spellType;
    public Constants.SpellTarget _target;
    public Constants.SpellCast _cast;
    public int _castValue;

    //Visuals, Sounds, Physics


    //Properties

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void ApplyEffects();

    public abstract void UndoEffects();
}
