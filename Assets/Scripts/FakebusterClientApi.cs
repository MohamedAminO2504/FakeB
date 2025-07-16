using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class FakebusterClientApi : MonoBehaviour
{
    private const string baseUrl2 = "https://fakebusterback.ew.r.appspot.com";
    private const string apiUrl = "http://localhost:8080";

    public GameData data;
    public AdminTools adminTools;
     public void EnvoyerQuestion()
    {
        foreach (var item in data.questions)
        {
            StartCoroutine(PostQuestionCoroutine(item));
        }
    }

    public void RecupererQuestion()
    {
                    StartCoroutine(GetQuestionsCoroutine());

    }


    private IEnumerator GetQuestionsCoroutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl+"/questions");
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (!request.isNetworkError && !request.isHttpError)
        {
            string json = request.downloadHandler.text;
            Debug.Log("Réponse brute : " + json);

            // Désérialisation possible uniquement si backend renvoie { "questions": [...] }
            QuestionList wrapper = JsonUtility.FromJson<QuestionList>(json);
            if (wrapper != null && wrapper.questions != null)
            {
                foreach (var q in wrapper.questions)
                {
                    Debug.Log("Question : " + q.libelle);
                }
            }
        }
        else
        {
            Debug.LogError("Erreur GET : " + request.error);
        }
    }

    private IEnumerator PostQuestionCoroutine(Question q)
    {
        QuestionApi question = q.toQuestionApi();
        string jsonData = JsonUtility.ToJson(question);

        UnityWebRequest request = new UnityWebRequest(apiUrl + "/question", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (!request.isNetworkError && !request.isHttpError)
        {
            Debug.Log("Question envoyée avec succès : " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Erreur lors de l’envoi : " + request.error);
        }
    }

}
