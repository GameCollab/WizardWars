using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _001_Fireball : Card
{
    public Summon _primaryEffect;

    void Start()
    {
        //Initialize the Tags
        _tags = new List<Enums.Cards.Tag>();
        _tags.Add(Enums.Cards.Tag.FIRE);
        _tags.Add(Enums.Cards.Tag.PROJECTILE);
        _tags.Add(Enums.Cards.Tag.AOE);

        //Initialize the Modifiers (Later)
        _modifiers = new Dictionary<uint, bool>();
        //Add the Molten Crater Modifier
    }

    public override IEnumerator DoEffect(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber)
    {
        //The Fireball spell's primary job is to instantiate a Fireball projectile
        //Summon Effects only want the owner (the caster of the summon), and where to summon.
        _primaryEffect._casterNumber = casterNumber;
        _primaryEffect._targetPosition = targetPosition;
        _primaryEffect.enabled = true;
        yield break;
    }
}
