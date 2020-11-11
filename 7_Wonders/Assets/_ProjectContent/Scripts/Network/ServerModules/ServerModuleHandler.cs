using System.Collections;
using MyBox;
using SK_Engine;
using UnityEngine;
using NativeWebSocket;
using Logger = SK_Engine.Logger;

namespace WhiteTeam.Network.ServerModules
{
    public abstract class ServerModuleHandler<T> : Singleton<T>
        where T : MonoBehaviour
    {
        [SerializeField] private string url;
        [SerializeField] private string port;

        [SerializeField] private bool connectOnEvent;

        [SerializeField] [ConditionalField(nameof(connectOnEvent))]
        private BoolTriggerEvent connectEvent;

        [SerializeField] private Logger logger;

        private WebSocket _webSocket;

        private const float NETWORK_ATTEMPT_DELAY = 0.4f;

        #region UNITY EVENTS

        public override void Awake()
        {
            base.Awake();
            if (connectOnEvent)
            {
                connectEvent.SubscribeToTrueValueSet(Connect);
            }
        }

        private void Update()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            _webSocket.DispatchMessageQueue();
#endif
        }

        private void OnApplicationQuit()
        {
            Disconnect();
        }

        #endregion

        #region API

        public void Connect()
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                logger.Log("Websocket has been already connected!", Logger.LogLevel.INFO);
                return;
            }

            SetupConnection();

            StartCoroutine(TryingToConnectLog());
        }

        public void Disconnect()
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Closed)
            {
                logger.Log("Websocket has been already disconnected!", Logger.LogLevel.INFO);
                return;
            }

            DestroyConnection();

            StartCoroutine(TryingToCloseLog());
        }


        public void Send(string text)
        {
            _webSocket.SendText(text);
        }

        #region NET EVENTS

        protected virtual void OnWebSocketOpen()
        {
            logger.Log("WebSocket Open!");
        }

        protected virtual void OnMessageReceived(byte[] bytes)
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            logger.Log($"Message received from server: {message}");
            OnTextMessageReceived(message);
        }

        protected virtual void OnTextMessageReceived(string text)
        {
            
        }

        protected virtual void OnWebSocketError(string error)
        {
            logger.Log("Error: " + error);
        }

        protected virtual void OnWebSocketClose(WebSocketCloseCode webSocketCloseCode)
        {
            logger.Log("WebSocket Closed!");
        }

        #endregion

        #endregion

        #region METHODS

        private async void SetupConnection()
        {
            _webSocket = new WebSocket($"ws://{url}:{port}");
            SubscribeEvents();
            await _webSocket.Connect();
        }

        private async void DestroyConnection()
        {
            UnSubscribeEvents();
            await _webSocket.Close();
        }

        private void SubscribeEvents()
        {
            _webSocket.OnOpen += OnWebSocketOpen;
            _webSocket.OnMessage += OnMessageReceived;
            _webSocket.OnError += OnWebSocketError;
            _webSocket.OnClose += OnWebSocketClose;
        }

        private void UnSubscribeEvents()
        {
            _webSocket.OnOpen -= OnWebSocketOpen;
            _webSocket.OnMessage -= OnMessageReceived;
            _webSocket.OnError -= OnWebSocketError;
            _webSocket.OnClose -= OnWebSocketClose;
        }

        private IEnumerator TryingToConnectLog()
        {
            yield return new WaitForSeconds(NETWORK_ATTEMPT_DELAY);
            while (_webSocket.State != WebSocketState.Open)
            {
                logger.Log("Trying to connect", Logger.LogLevel.DEBUG);
                yield return new WaitForSeconds(NETWORK_ATTEMPT_DELAY);
            }

            yield return null;
        }

        private IEnumerator TryingToCloseLog()
        {
            while (_webSocket.State != WebSocketState.Closed)
            {
                yield return new WaitForSeconds(NETWORK_ATTEMPT_DELAY);
                logger.Log("Trying to close", Logger.LogLevel.DEBUG);
            }

            yield return null;
        }

        #endregion
    }
}