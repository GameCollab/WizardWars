using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpellLike
{
    void CastSpell(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber);
    IEnumerator DoEffect(int targetNumber, Transform targetPosition, Transform castPosition, int casterNumber);
}
