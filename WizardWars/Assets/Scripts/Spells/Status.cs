using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour, SpellLike {
    public string _name;
    public string _description;
    public uint _id;

    public Enums.Cards.Element _element;
    public Enums.Statuses.Type _type;
    public Enums.Statuses.Stack _stack;

    public float _duration;

    public GameObject _statusVisualizer;

    public uint _originSpell;
    public int _originPlayer;
    public int _originObject;

    public int _targetPlayer;

    public bool _isInvertible;
    public bool _isPermanent;

    public bool _fromPlayer;
    public bool _fromObject;

    public abstract void DoInverse();
    public abstract void DoEffect(int targetNumber, int originNumber);
    public abstract void DoEffect(Vector3 targetPosition, int originNumber);
    public abstract bool Done();

}
