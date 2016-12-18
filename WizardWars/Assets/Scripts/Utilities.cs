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

    public static class Effects
    {
        public static bool IsTimerDone(float timer, float duration)
        {
            return timer > duration;
        }

        public static bool IsValidTarget(GameObject other, int targetNumber, Enums.Spells.Target type, bool targeted)
        {
            if (targeted)
            {
                return CheckIfTarget(other, targetNumber);
            }
            else
            {
                return CheckValidTarget(other, type);
            }
        }

        public static bool CheckIfTarget(GameObject other, int targetNumber)
        {
            return true;
        }

        public static bool CheckValidTarget(GameObject other, Enums.Spells.Target type)
        {
            switch (type)
            {
                case Enums.Spells.Target.ANY: return other.CompareTag("Player");
                case Enums.Spells.Target.NOT_SELF: return other.CompareTag("Player");//&& other.GetComponent<Player...>().getNumber()... != _casterNumber;
                case Enums.Spells.Target.SELF: return true; //return other.GetComponent<Player...>().getNumber()... == _casterNumber;
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
