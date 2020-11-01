using System;
using MyBox;
using SK_Engine;
using UnityEngine;
using Logger = SK_Engine.Logger;

namespace WhiteTeam.Network.ServerModules
{
    public abstract class ServerModuleHandler<T> : Singleton<T>
        where T : MonoBehaviour
    {
        [SerializeField] private bool connectOnEvent;

        [SerializeField] [ConditionalField(nameof(connectOnEvent))]
        private BoolTriggerEvent connectEvent;

        [SerializeField] private Logger logger;

        public ServerModuleState ConnectionState { get; protected set; } = ServerModuleState.DISCONNECTED;

        #region UNITY EVENTS

        public override void Awake()
        {
            base.Awake();
            if (connectOnEvent)
            {
                connectEvent.SubscribeToTrueValueSet(Connect);
            }
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        #endregion

        #region API

        public void Connect()
        {
            if (ConnectionState == ServerModuleState.CONNECTED)
            {
                logger.Log("Websocket has been already connected!", Logger.LogLevel.INFO);
                return;
            }

            // TODO -- connecting

            logger.Log("Connected", Logger.LogLevel.INFO);
        }

        public void Disconnect()
        {
            if (ConnectionState == ServerModuleState.DISCONNECTED)
            {
                logger.Log("Websocket has been already disconnected!", Logger.LogLevel.INFO);
                return;
            }

            // TODO -- disconnecting

            logger.Log("Disconnected", Logger.LogLevel.INFO);
        }

        public void Send(string text)
        {
            // TODO -- send text
        }

        #endregion
    }
}