using System;
using UnityEngine;

public static class CardDatabase
{
    //The List, organized by ID
    public static Card[] cardDatabase = new Card[]
    {
        null, //First spot empty for error check
        new Cards._001_FIREBALL()
    };

}

/* This is where all of the Cards are */
/* They all have this format: _ + ID + _ + NAME */
namespace Cards
{
    public class _001_FIREBALL : Card
    {
        public float _radius;
        public GameObject _prefab;
        //Move values to Constants for ez changing
        public _001_FIREBALL() 
            : base(Constants.FIREBALL_NAME, Constants.FIREBALL_ID, Constants.FIREBALL_DESC, Constants.FIREBALL_TYPE, Constants.FIREBALL_CLASS, Constants.FIREBALL_RARITY, Constants.FIREBALL_SPELLTYPE, Constants.FIREBALL_TARGET, Constants.FIREBALL_CAST, Constants.FIREBALL_CASTVAL, Constants.FIREBALL_DAMAGE, Constants.FIREBALL_KNOCKBACK, Constants.FIREBALL_DURATION, Constants.FIREBALL_CHANNEL, Constants.FIREBALL_RANGE, Constants.FIREBALL_CASTRANGE, Constants.FIREBALL_SPEED, Constants.FIREBALL_COOLDOWN, Constants.FIREBALL_TAGS)
        {
            //Extra stuff
            _radius = Constants.FIREBALL_RADIUS;
            //_prefab = Resources.Load( ....);
        }

        public override void CastSpell(GameObject user, GameObject target)
        {
            //Instantiate fireball
            //Set user as origin
        }

        public override bool UndoEffects(GameObject target)
        {
            //You cannot undo a fireball, silly
            return false;
        }
    }
}
