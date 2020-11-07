using System.Collections;
using System.Collections.Generic;
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

    private readonly string postRegistrationURL = "https://wonders-auth.herokuapp.com/registration";
    private readonly string postAuthURL = "https://wonders-auth.herokuapp.com/auth";
    private const string CONTENT_TYPE = "application/json";

    private const string successResult =
        "{\"status\":\"SUCCESS\",\"results\":[],\"module\":\"Authorization\",\"type\":\"register\"}";
    
    
    void Start()
    {
        var result = AuthJsonReceiver.Instance.Deserialize(successResult);
        //AuthPost("test2", "test2");
    }

    public void RegisterPost(string username, string password)
    {
        StartCoroutine(PostRequest(postRegistrationURL, JsonCreator.CreateAuthJson(AuthType.register,username, password)));
    }
    
    public void AuthPost(string username, string password)
    {
        StartCoroutine(PostRequest(postAuthURL, JsonCreator.CreateAuthJson(AuthType.auth,username, password)));
    }
    
    IEnumerator PostRequest(string URL, string data)
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
            Debug.Log("OK");
            Debug.Log("Status Code: " + request.responseCode);
            Debug.Log(request.downloadHandler.text);
            //var result = AuthJsonReceiver.Instance.Deserialize(request.downloadHandler.text);
            // Debug.Log("status: " + result.status);
            // Debug.Log("module: " + result.module);
            // Debug.Log("type: " + result.type);
            // Debug.Log("results: " + result.results);
            
            
        }
    }

    public class ActionsEvents
    {
        public EventHolderBase OnSuccessfulRegister { get; private set; } = new EventHolderBase();
        public EventHolderBase OnSuccessfulLogin { get; private set; } = new EventHolderBase();
        public EventHolderBase OnError { get; private set; } = new EventHolderBase();
    }
    
}