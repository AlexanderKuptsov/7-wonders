using UnityEngine;

namespace _ProjectContent.Scripts.GameLogic
{
    public class GlobalInitializer : Singleton<GlobalInitializer>
    {
        public override void Awake()
        {
            base.Awake();
#if UNITY_EDITOR
            Debug.unityLogger.logEnabled = true;
#else
            Debug.unityLogger.logEnabled = false;
#endif
        }
    }
}