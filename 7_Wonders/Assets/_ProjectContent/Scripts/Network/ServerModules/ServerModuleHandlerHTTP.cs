using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerModuleHandlerHTTP : MonoBehaviour
{
    [SerializeField] private string postURL;

    [SerializeField] private string getURL;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void OnActionRequest()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        var result = ""; // or byte[]
        UnityWebRequest request = UnityWebRequest.Get(getURL);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            result = request.downloadHandler.text; // we can use .data to get byte[]
        }
    }

    IEnumerator PostRequest(string data)
    {
        var result = ""; // or byte[]
        List<IMultipartFormSection> postRequest = new List<IMultipartFormSection>();
        postRequest.Add(new MultipartFormDataSection("KEY", data));

        UnityWebRequest request = UnityWebRequest.Get(postURL);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            result = request.downloadHandler.text; // we can use .data to get byte[]
        }
    }

    IEnumerator SendLoginRequest(string username, string password)
    {
        UnityWebRequest req = createLoginRequest(getURL, username, password);

        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.LogError(req.error);
        }
    }

    private UnityWebRequest createLoginRequest(string url, string username, string password)
    {
        UnityWebRequest req = UnityWebRequest.Get(url);

        // could also use "US-ASCII" or "ISO-8859-1" encoding
        string encoding = "UTF-8";
        string base64 = System.Convert.ToBase64String(
            System.Text.Encoding.GetEncoding(encoding)
                .GetBytes(username + ":" + password)
        );

        req.SetRequestHeader("Authorization", "Basic " + base64);

        return req;
    }
}