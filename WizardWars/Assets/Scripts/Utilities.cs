using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Utility functions */
namespace Utilities
{
    public static class EnumUtil
    {
        public static string GetStringTag(Enums.Cards.Target target)
        {
            switch (target)
            {
                case Enums.Cards.Target.ANY:
                case Enums.Cards.Target.NOT_SELF:
                case Enums.Cards.Target.SELF:
                    return Constants.Tags.PLAYER_TAG;
                default:
                    Debug.Log("Bad target type in GetStringTag");
                    return null;
            }
        }
    }

    public static class ManagerAccess
    {
        public static GameObject GetPlayerByNumber(int number)
        {
            //Debug.Log("Number: " + number);
            //Debug.Log(TestManager._manager);
            return GlobalManager.MANAGER._players[number];
        }

        public static GameObject GetStatusById(uint id)
        {
            return GlobalManager.MANAGER._statusDatabase[id];
        }

        public static GameObject GetObjectById(uint id)
        {
            return GlobalManager.MANAGER._objectDatabase[id];
            /*
            if(type == Enums.Objects.Type.PROJECTILE)
            {
                return GlobalManager.MANAGER._projectileMasterList[id];
            }
            else if(type == Enums.Objects.Type.STATIONARY)
            {
                return GlobalManager.MANAGER._stationaryMasterList[id];
            }
            else
            {
                return null;
            }
            */
        }

        public static GameObject GetCardById(uint id)
        {
            return GlobalManager.MANAGER._cardDatabase[id];
        }
    }

    public static class Misc
    {
        public static bool IsTimerDone(float timer, float duration)
        {
            return timer >= duration;
        }


        public static GameObject GetTarget(int number, Enums.Cards.Target type, int caster)
        {
            //Debug.Log(number + ", " + caster + ", " + type);
            GameObject target;
            if (type == Enums.Cards.Target.SELF && false)
            {
                target = Utilities.ManagerAccess.GetPlayerByNumber(caster);
            }
            else
            {
                target = Utilities.ManagerAccess.GetPlayerByNumber(number);
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
        public static List<GameObject> GetAllOfTypeInCast(Enums.Cards.Cast cast, Vector3 castPoint, float castSize, float secondValue, string tag)
        {
            switch (cast)
            {
                case Enums.Cards.Cast.CIRCLE: return GetAllOfTypeInCircle(castPoint, castSize, tag);
                case Enums.Cards.Cast.NOVA: return GetAllOfTypeInCircle(castPoint, castSize, tag);
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
