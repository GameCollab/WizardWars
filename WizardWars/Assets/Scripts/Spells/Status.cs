using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour, ISpellLike {
    public string _name;
    public string _description;
    public uint _id;
    public Enums.Cards.Element _element;
    public Enums.Statuses.Type _type;
    public Enums.Statuses.Stack _stack;
    public bool _isInvertible;
    public bool _isPermanent;
    public bool _fromPlayer;
    public float _duration;
    public uint _originSpell;

    public GameObject _statusVisualizer;
    [HideInInspector]
    public int _originPlayer;
    [HideInInspector]
    public int _targetPlayer;


    public abstract void DoInverse();
    public void CastSpell(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber)
    {
        StartCoroutine(DoEffect(targetNumber, targetPosition, castPosition, casterNumber));
    }
    public abstract IEnumerator DoEffect(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber);
    public abstract bool Done();
    
}
