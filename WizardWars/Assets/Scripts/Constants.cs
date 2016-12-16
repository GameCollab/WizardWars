using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public enum CardType
    {
        DEFAULT,
        ABILITY,
        SUPPORT
    } 

   public enum CardClass
    {
        DEFAULT,
        FIRE,
        WATER,
        LIGHTNING,
        GRAVITY,
        UNIVERSAL
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
        DEFAULT
    }

    public enum SpellType
    {
        DEFAULT,
        ACTIVE,
        STATIC,
        CONTINUOUS
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
}
