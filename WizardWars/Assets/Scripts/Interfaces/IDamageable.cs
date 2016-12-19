using System.Collections;
using UnityEngine;

//For things that can be damaged
public interface IDamageable
{
    void TakeDamage(float damage);
    void Die();
}

