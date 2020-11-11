using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Network.Json
{
    public abstract class JsonReceiverBase<T, U> : Singleton<U>
        where T : Result
        where U : MonoBehaviour
    {
        public T Deserialize(string msg)
        {
            var receiveMsg = JsonConvert.DeserializeObject<Result>(msg);
            return receiveMsg.IsCorrect ? OnSuccessMsg(msg) : OnErrorMsg(msg);
        }

        protected virtual T OnErrorMsg(string msg)
        {
            var error = JsonConvert.DeserializeObject<T>(msg);
            return error;
        }

        protected virtual T OnSuccessMsg(string msg)
        {
            var success = JsonConvert.DeserializeObject<T>(msg);
            return success;
        }
    }
}