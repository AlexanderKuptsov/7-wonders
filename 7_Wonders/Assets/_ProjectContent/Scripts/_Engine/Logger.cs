using System;
using UnityEngine;

namespace SK_Engine
{
    [Serializable]
    public class Logger
    {
        public LogLevel Level = LogLevel.DEBUG;
        public string Name;

        public void Log(string msg, LogLevel level = LogLevel.DEBUG)
        {
            if ((int) level >= (int) Level)
            {
                Debug.Log($"[{Name}] {msg}");
            }
        }

        public enum LogLevel
        {
            TRACE,
            DEBUG,
            INFO,
            WARNING,
            ERROR,
            FATAL
        }
    }
}