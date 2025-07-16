using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TypeFakeFacade : MonoBehaviour
{
    public Paramettre parametter;

    public IEnumerator Get(System.Action<List<TypeFakeApi>> onSuccess, System.Action<string> onError)
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"{parametter.GetUrl()}/typefake"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = "{\"typeFakes\":" + request.downloadHandler.text + "}";
                TypeFakeList list = JsonUtility.FromJson<TypeFakeList>(json);
                Debug.Log(list.typeFakes.Count + " type fake trouvé");

                onSuccess?.Invoke(list.typeFakes);
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }
    }

    public IEnumerator Post(TypeFakeList list, System.Action onSuccess, System.Action<string> onError)
    {
        string jsonData = JsonUtility.ToJson(list);
        Debug.Log(jsonData);
        byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest($"{parametter.GetUrl()}", "POST"))
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
