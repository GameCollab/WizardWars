using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonObject : MonoBehaviour, ISpellLike {
    public string _name;
    public string _description;
    public uint _id;

    public Enums.Cards.Element _element;
    public Enums.Objects.Type _type;

    GameObject _objectVisualPrefab;

    public uint _originSpell;
    public uint _originPlayer;

    public abstract void DoEffect();
}
