using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public enum CardType
    {
        DEFAULT,
        ABILITY,
        SUPPORT,
        SPECIAL
    } 

   public enum CardClass
    {
        DEFAULT,
        FIRE,
        WATER,
        LIGHTNING,
        GRAVITY,
        UNIVERSAL,
        SPECIAL
    }

    public enum CardRarity
    {
        DEFAULT,
        APPRENTICE,
        ADEPT,
        MASTER
    }

    public enum Tag
    {
        DEFAULT,
        FIRE,
        PROJECTILE,
        AOE
    }

    public enum SpellType
    {
        DEFAULT,
        ACTIVE_PROJECTILE,
        ACTIVE_OBJECT,
        ACTIVE_DIRECT,
        PASSIVE_MODIFY,
        PASSIVE_BUFF
    }

    public enum SpellTarget
    {
        DEFAULT,
        TARGETED,
        SELF,
        SKILLSHOT
    }

    public enum SpellCast
    {
        DEFAULT,
        NONE,
        LINE,
        CONE,
        MULTILINE,
        CIRCLE,
        RECTANGLE,
        NOVA
    }


    /* Fireball Spell Values */
    public const string FIREBALL_NAME = "Fireball";
    public const uint FIREBALL_ID = 001;
    public const string FIREBALL_DESC = "Shoot a fast projectile in a straight line that explodes at target location or on impact.";
    public const CardType FIREBALL_TYPE = CardType.ABILITY;
    public const CardClass FIREBALL_CLASS = CardClass.FIRE;
    public const CardRarity FIREBALL_RARITY = CardRarity.APPRENTICE;
    public const SpellType FIREBALL_SPELLTYPE = SpellType.ACTIVE_PROJECTILE;
    public const SpellTarget FIREBALL_TARGET = SpellTarget.SKILLSHOT;
    public const SpellCast FIREBALL_CAST = SpellCast.LINE;
    public const int FIREBALL_CASTVAL = 1;
    public const float FIREBALL_DAMAGE = 10f;
    public const float FIREBALL_KNOCKBACK = 1f;
    public const float FIREBALL_DURATION = 0f;
    public const float FIREBALL_CHANNEL = 0f;
    public const float FIREBALL_RANGE = 10f;
    public const float FIREBALL_CASTRANGE = 0f;
    public const float FIREBALL_SPEED = 20f;
    public const float FIREBALL_COOLDOWN = 4f;
    public static readonly Tag[] FIREBALL_TAGS = new Tag[] { Tag.FIRE, Tag.PROJECTILE, Tag.AOE };

    public const float FIREBALL_RADIUS = 3f;

}
