using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Enumerations used in the game */
namespace Enums
{
    public static class Cards
    {
        public enum Type
        {
            NONE,
            ABILITY,
            SUPPORT
        }

        public enum Element
        {
            NONE,
            FIRE,
            WATER,
            LIGHTNING,
            GRAVITY,
            UNIVERSAL
        }

        public enum Rarity
        {
            NONE,
            APPRENTICE,
            ADEPT,
            MASTER
        }

        public enum Tag
        {
            NONE,
            FIRE,
            PROJECTILE,
            AOE
        }
    }

    public static class Spells
    {
        public enum Type
        {
            NONE,
            ACTIVE,
            PASSIVE
        }

        public enum SubType
        {
            NONE,
            PROJECTILE,
            OBJECT,
            DIRECT,
            MODIFIER,
            BUFF
        }

        public enum Target
        {
            NONE,
            NOT_SELF,
            ANY,
            SELF
        }

        public enum Shot
        {
            NONE,
            TARGETED,
            DIRECTIONAL,
            POINT,
            VECTOR
        }

        public enum Cast
        {
            NONE,
            ARROW,
            CONE,
            CIRCLE,
            POINT,
            NOVA,
            DISCRETE_NOVA
        }
    }

    public static class Statuses
    {
        public enum Type
        {
            NONE,
            DAMAGE,
            CONTROL,
            CHANGE,
            EFFECT
        }

        public enum Stack
        {
            NONE,
            REFRESH,
            STACK,
            IGNORE
        }

        public enum Disable
        {
            NONE,
            IMMOBILIZE,
            SILENCE,
            INVULNERABLE,
            STUN,
            STASIS
        }
    }

    public static class Objects
    {
        public enum Type
        {
            NONE,
            PROJECTILE,
            STATIONARY
        }
    }

    public static class Players
    {
        public enum Attribute
        {
            NONE,
            LIFE,
            PROJECTILE_COUNT,
            FIRE_DAMAGE,
            FIRE_AOE,
            FIRE_DURATION,
            FIRE_SPEED,
            WATER_DAMAGE,
            WATER_AOE,
            WATER_DURATION,
            WATER_SPEED,
            LIGHTNING_DAMAGE,
            LIGHTNING_AOE,
            LIGHTNING_DURATION,
            LIGHTNING_SPEED,
            GRAVITY_DAMAGE,
            GRAVITY_AOE,
            GRAVITY_DURATION,
            GRAVITY_SPEED,
            FREEZE_CHANCE,
            KNOCKBACK_RESIST,
            COOLDOWN_REDUCION,
            MOVE_SPEED,
            DAMAGE_REDUCTION
        }
    }
}
