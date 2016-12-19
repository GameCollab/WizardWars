using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpellLike
{
    void DoEffect(int targetNumber, int originNumber);
    void DoEffect(Vector3 targetPosition, int originNumber);
}
