using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Generic Damage Effect */
public abstract class Damage : Effect
{
    public float _damage = 0f;
    public float _damageChange = 0f;

    protected void ApplyDamage(GameObject player)
    {
        IDamageable dmg = Utilities.Interfaces.GetDamageable(player);
        if(dmg != null)
        {
            dmg.TakeDamage(_damage);
        }
    }
}