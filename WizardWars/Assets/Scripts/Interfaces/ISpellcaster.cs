using System.Collections;
using UnityEngine;

//For things that can cast spells
public interface Spellcaster
{
    IEnumerator CastSpell(Spell s); //Parameter Spell to cast
}
