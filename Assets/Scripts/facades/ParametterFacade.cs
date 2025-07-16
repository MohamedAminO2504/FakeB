using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ParametterFacade : MonoBehaviour
{
    public Paramettre parametter;

    public IEnumerator Get(System.Action<List<ParametterApi>> onSuccess, System.Action<string> onError)
    {
        Debug.Log("test");
        using (UnityWebRequest request = UnityWebRequest.Get($"{parametter.GetUrl()}/parametter"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = "{\"parametters\":" + request.downloadHandler.text + "}";
                ParametterList parametterList = JsonUtility.FromJson<ParametterList>(json);
                onSuccess?.Invoke(parametterList.parametters);
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }
    }

    public IEnumerator Post(ParametterList newParametter, System.Action onSuccess, System.Action<string> onError)
    {
        string jsonData = JsonUtility.ToJson(newParametter);
        Debug.Log(jsonData);
        byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest($"{parametter.GetUrl()}/parametter", "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success || request.responseCode == 201)
            {
                onSuccess?.Invoke();
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }
    }
}
