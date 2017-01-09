using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour, ISpellLike, IComparable<Card>
{
    public string _name;
    public string _description;
    public uint _id;

    public Enums.Cards.Type _type;
    public Enums.Cards.Element _element;
    public Enums.Cards.Rarity _rarity;
    public Enums.Cards.Target _target;
    public Enums.Cards.Cast _cast;
    public Enums.Cards.Shot _shot;

    public float _castSize;
    public float _arrowNumber;

    public float _damage;
    public float _knockback;
    public float _cooldown;
    public float _duration;
    public float _channel;
    public float _range;
    public float _speed;

    public List<Enums.Cards.Tag> _tags;
    public Dictionary<uint, bool> _modifiers;

    public string _display
    {
        get
        {
            return null; //DEpends on how the card is displayed
        }
    }

    public void CastSpell(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber)
    {
        StartCoroutine(DoEffect(targetNumber, targetPosition, castPosition, casterNumber));
    }

    public abstract IEnumerator DoEffect(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber);

    public int CompareTo(Card other)
    {
        return _id.CompareTo(other._id);
    }
}