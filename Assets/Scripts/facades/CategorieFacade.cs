using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CategorieFacade : MonoBehaviour
{
    public Paramettre parametter;

    public IEnumerator Get(System.Action<List<CategorieApi>> onSuccess, System.Action<string> onError)
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"{parametter.GetUrl()}/categorie"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = "{\"categories\":" + request.downloadHandler.text + "}";
                Debug.Log(json);

                CategorieList l = JsonUtility.FromJson<CategorieList>(json);
                Debug.Log(l.categories);
                onSuccess?.Invoke(l.categories);
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }
    }

    public IEnumerator Post(QuestionList newQuestion, System.Action onSuccess, System.Action<string> onError)
    {
        string jsonData = JsonUtility.ToJson(newQuestion);
        byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest($"{parametter.GetUrl()}/questions", "POST"))
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
