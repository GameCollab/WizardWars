using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Data Container for Cards */
/* Has a Spell Factory */
public abstract class Card : ISpellmaker {

    public static int _globalCardCount = 0;

    /* Card Stuff */
    public string _name;
    public uint _id;
    public string _description;

    public Constants.CardType _type;
    public Constants.CardClass _class;
    public Constants.CardRarity _rarity;

    /* Card Stats */
    public float _damage;
    public float _knockback;
    public float _duration;
    public float _channel;
    public float _range;
    public float _castRange;
    public float _missileSpeed;
    public float _cooldown;
    public Constants.Tag[] _tags;

    /* Stuff for Spell Creator */
    public Constants.SpellType _spellType;
    public Constants.SpellTarget _target;
    public Constants.SpellCast _cast;
    public int _castValue;


    /* Properties */
    

    public string toString()
    {
        return "";
    }

    public Spell MakeSpell(Card c)
    {
        return null;
    }
}
