using System.Collections;
using UnityEngine;

//For things that will create spells
//For Cards, but might be used for other things
public interface ISpellmaker
{
    Spell MakeSpell(Card c);
}

