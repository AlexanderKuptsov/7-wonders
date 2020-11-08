using System.Collections;
using System.Text;
using Network.Json;
using SK_Engine;
using UnityEngine;
using UnityEngine.Networking;

public class ServerModuleHandlerHTTP : Singleton<ServerModuleHandlerHTTP>
{
    [SerializeField] private string postURL;
    [SerializeField] private string getURL;
    public readonly ActionsEvents Events = new ActionsEvents();

    private const string POST_REGISTRATION_URL = "https://wonders-auth.herokuapp.com/registration";
    private const string POST_AUTH_URL = "https://wonders-auth.herokuapp.com/auth";
    private const string CONTENT_TYPE = "application/json";

    private const string SUCCESS_RESULT =
        "{\"status\":\"SUCCESS\",\"results\":[],\"module\":\"Authorization\",\"type\":\"register\"}";


    private void Start()
    {
        //AuthPost("test2", "test2");
    }

    public void RegisterPost(string username, string password)
    {
        StartCoroutine(PostRequest(POST_REGISTRATION_URL, JsonCreator.CreateAuthJson(AuthType.register,username, password)));
    }
    
    public void AuthPost(string username, string password)
    {
        StartCoroutine(PostRequest(POST_AUTH_URL, JsonCreator.CreateAuthJson(AuthType.auth,username, password)));
    }

    private IEnumerator PostRequest(string URL, string data)
    {
        var request = new UnityWebRequest(URL, "POST");
        var bytes = Encoding.UTF8.GetBytes(data);
        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            Events.OnError.TriggerEvents();
        }
        else
        {
            Debug.Log("Status Code: " + request.responseCode);
            Debug.Log($"Whole response : {request.downloadHandler.text}");
            var result = ResultJsonReceiver.Instance.Deserialize(SUCCESS_RESULT);
            Debug.Log($"Response status: \"{result.status}\" module: \"{result.module}\" type: \"{result.type}\"");
            if (result.IsCorrect)
            {
                if (result.type == "register")
                {
                    //register was ok
                    Events.OnSuccessfulRegister.TriggerEvents();
                }

                if (result.type == "auth")
                {
                    //login was ok & need to take token
                    var authResult = AuthJsonReceiver.Instance.Deserialize(SUCCESS_RESULT);
                    var token = authResult.results.accessToken;
                    Debug.Log($"Received token \"{token}\"");
                    Events.OnSuccessfulLogin.TriggerEvents(token);
                }
            }
        }
    }

    public class ActionsEvents
    {
        public EventHolderBase OnSuccessfulRegister { get; } = new EventHolderBase();
        public EventHolder<string> OnSuccessfulLogin { get; } = new EventHolder<string>();
        public EventHolderBase OnError { get; } = new EventHolderBase();
    }
    
}