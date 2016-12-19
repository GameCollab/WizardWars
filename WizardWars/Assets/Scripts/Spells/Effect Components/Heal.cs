using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Heal : Effect
{
    public float _restore;
    public float _restoreChange;

    protected void ApplyHeal(GameObject player)
    {
        IHealable heal = Utilities.Interfaces.GetHealable(player);
        if (heal != null)
        {
            heal.Heal(_restore);
        }
    }
}
