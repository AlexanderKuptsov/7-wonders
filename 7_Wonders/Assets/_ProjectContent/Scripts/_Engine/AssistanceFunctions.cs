using System.Collections.Generic;
using UnityEngine;

namespace SK_Engine
{
    public static class AssistanceFunctions
    {
        // ----- API -----
        public static Transform[] CacheTransforms<T>(T[] _array)
        {
            if (!typeof(T).IsSubclassOf(typeof(Component)))
            {
                Debug.LogError("[AssistanceFunction] Invalid types of input collection. " +
                               "Party (" + typeof(T).FullName + ") is not a subclass of (Component).");
                return null;
            }
            var len = _array.Length;
            var transforms = new Transform[len];
            for (var i = 0; i < len; i++)
            {
                transforms[i] = (_array[i] as Component)?.transform;
            }

            return transforms;
        }

        public static Transform[] CacheTransforms<T>(List<T> _list)
        {
            if (!typeof(T).IsSubclassOf(typeof(Component)))
            {
                Debug.LogError("[AssistanceFunction] Invalid type of input collection. " +
                               "Party (" + typeof(T).FullName + ") is not a subclass of (Component).");
                return null;
            }
            var len = _list.Count;
            var transforms = new Transform[len];
            for (var i = 0; i < len; i++)
            {
                transforms[i] = (_list[i] as Component)?.transform;
            }

            return transforms;
        }
    }
}