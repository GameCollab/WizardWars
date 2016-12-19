using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Utility functions */
namespace Utilities
{
    public static class EnumUtil
    {
        public static string GetStringTag(Enums.Spells.Target target)
        {
            switch (target)
            {
                case Enums.Spells.Target.ANY:
                case Enums.Spells.Target.NOT_SELF:
                case Enums.Spells.Target.SELF:
                    return Constants.Tags.PLAYER_TAG;
                default:
                    Debug.Log("Bad target type in GetStringTag");
                    return null;
            }
        }
    }

    public static class Misc
    {
        public static bool IsTimerDone(float timer, float duration)
        {
            return timer >= duration;
        }

        public static GameObject GetPlayerByNumber(int number)
        {
            //Debug.Log("Number: " + number);
            //Debug.Log(TestManager._manager);
            return TestManager._manager._players[number];
        }

        public static GameObject GetTarget(int number, Enums.Spells.Target type, int caster)
        {
            //Debug.Log(number + ", " + caster + ", " + type);
            GameObject target;
            if (type == Enums.Spells.Target.SELF && false)
            {
                target = Utilities.Misc.GetPlayerByNumber(caster);
            }
            else
            {
                target = Utilities.Misc.GetPlayerByNumber(number);
            }
            return target;
        }
    }

    public static class Interfaces
    {
        public static IDamageable GetDamageable(GameObject obj)
        {
            return obj.GetComponent(typeof(IDamageable)) as IDamageable;
        }

        public static IHealable GetHealable(GameObject obj)
        {
            return obj.GetComponent(typeof(IHealable)) as IHealable;
        }

        public static IControllable GetControllable(GameObject obj)
        {
            return obj.GetComponent(typeof(IControllable)) as IControllable;
        }

        public static IMovable GetMovable(GameObject obj)
        {
            return obj.GetComponent(typeof(IMovable)) as IMovable;
        }
    }

    public static class Effects
    {
        public static bool IsValidTarget(GameObject origin, GameObject other, int targetNumber, Enums.Spells.Target type, bool targeted)
        {
            if (targeted)
            {
                return CheckIfTarget(other, targetNumber);
            }
            else
            {
                return CheckValidTarget(origin, other, type);
            }
        }

        public static bool CheckIfTarget(GameObject other, int targetNumber)
        {
            TestDamageable td = other.GetComponent<TestDamageable>();
            if(td == null)
            {
                return false;
            }
            else
            {
                return td._number == targetNumber;
            }
        }

        public static bool CheckValidTarget(GameObject origin, GameObject other, Enums.Spells.Target type)
        {
            //Debug.Log("Checking non-targeted target of type " + type);
            //Debug.Log("Origin: " + origin);
            //Debug.Log("Other: " + other);
            switch (type)
            {
                case Enums.Spells.Target.ANY: return other.CompareTag(Constants.Tags.PLAYER_TAG);
                case Enums.Spells.Target.NOT_SELF: return other.CompareTag(Constants.Tags.PLAYER_TAG);//&& other.GetComponent<Player...>().getNumber()... != _casterNumber;
                case Enums.Spells.Target.SELF: return true; //return other.GetComponent<Player...>().getNumber()... == _casterNumber;
                case Enums.Spells.Target.SIGNAL:
                    Signal source = other.GetComponent<Signal>();
                    ProjectileMove moving = origin.GetComponent<ProjectileMove>();
                    //Debug.Log("Checking signal + source: " + source + "," + moving);
                    if (source == null || moving == null) return false;
                    return source._id == moving._signal;
                default:
                    Debug.Log("Bad Target Type!");
                    break;
            }
            return false;
        }

        public static List<GameObject> GetAllOfTypeInCast(Enums.Spells.Cast cast, Vector3 castPoint, float castSize, float secondValue, string tag)
        {
            switch (cast)
            {
                case Enums.Spells.Cast.CIRCLE: return GetAllOfTypeInCircle(castPoint, castSize, tag);
                case Enums.Spells.Cast.NOVA: return GetAllOfTypeInCircle(castPoint, castSize, tag);
                default:
                    Debug.Log("Bad Cast Type in GetAllOfTypeInCast.");
                    return null;
            }
        }

        public static List<GameObject> GetAllOfTypeInCircle(Vector3 castPoint, float radius, string tag)
        {
            List<GameObject> targets = new List<GameObject>();
            Collider[] list = Physics.OverlapSphere(castPoint, radius, Constants.Layers.GAME_LAYER);
            for (int i = 0; i < list.Length; i++)
            {
                if(list[i].gameObject.CompareTag(tag))
                    targets.Add(list[i].gameObject);
            }
            return targets;
        }

    }
}
