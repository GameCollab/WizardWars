using System.Collections;
using UnityEngine;

//For things that can be damaged
public interface IDamagable<T>
{
    void TakeDamage(T damage);
    void Die();
}

