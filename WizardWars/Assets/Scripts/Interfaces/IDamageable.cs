using System.Collections;
using UnityEngine;

//For things that can be damaged
public interface IDamageable<T>
{
    void TakeDamage(T damage);
    void Die();
}

