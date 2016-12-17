using System;
using System.Collections;
using UnityEngine;

/* Store Card Data */
/* Has Spell Effects */
public abstract class Card : IComparable<Card>
{
    /* Card General Data */
    public string _name;
    public uint _id;
    public string _description;

    /* Card Identifiers */
    public Constants.CardType _type;
    public Constants.CardClass _class;
    public Constants.CardRarity _rarity;

    /* Card - Spell */
    public Constants.SpellType _spellType;
    public Constants.SpellTarget _target;
    public Constants.SpellCast _cast;
    public int _castValue;

    /* Card Values */
    public float _damage;
    public float _knockback;
    public float _duration;
    public float _channel;
    public float _range;
    public float _castRange;
    public float _missileSpeed;
    public float _cooldown;

    public Constants.Tag[] _tags;


    public Card(string name, uint id, string description, Constants.CardType type, Constants.CardClass cl, Constants.CardRarity rarity, Constants.SpellType spellType, Constants.SpellTarget target, Constants.SpellCast cast, int castValue, float damage, float knockback, float duration, float channel, float range, float castRange, float missileSpeed, float cooldown, Constants.Tag[] tags)
    {
        _name = name;
        _id = id;
        _description = description;
        _type = type;
        _class = cl;
        _rarity = rarity;
        _spellType = spellType;
        _target = target;
        _cast = cast;
        _castValue = castValue;
        _damage = damage;
        _knockback = knockback;
        _duration = duration;
        _channel = channel;
        _range = range;
        _castRange = castRange;
        _missileSpeed = missileSpeed;
        _cooldown = cooldown;
        _tags = tags;
}

    public string toString()
    {
        return null; //Create a string that summarizes the card
    }

    public int CompareTo(Card other)
    {
        return _id.CompareTo(other._id);
    }

    public abstract void CastSpell(GameObject user, GameObject target);
    public abstract bool UndoEffects(GameObject target);

}