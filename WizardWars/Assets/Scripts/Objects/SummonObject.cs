using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonObject : MonoBehaviour, ISpellLike {
    public string _name;
    public string _description;
    public uint _id;
    public Enums.Cards.Element _element;
    public Enums.Objects.Type _type;
    public uint _originSpell;

    [HideInInspector]
    public int _originPlayer;

    public void CastSpell(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber)
    {
        StartCoroutine(DoEffect(targetNumber, targetPosition, castPosition, casterNumber));
    }

    public abstract IEnumerator DoEffect(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber);
}
