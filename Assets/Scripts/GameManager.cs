using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public Image profileImage;

    public TextMeshProUGUI nameFacebook;

    public List<Question> questions;

    public List<TypeFakeData> listFakes;

    public List<Question> choisies;

    public UIManager uIManager;

    public int count;

    public string url_fb = "https://www.facebook.com/profile.php?id=61557458860340";
    public string url_insta = "https://www.instagram.com/asso.metablue?igsh=MTNnOGU2MTdwMjdzMw==";

    public string url_mastodon = "https://ludosphere.fr/@Metablue";


    public int point;
    public int pointMax;
    public int countNbAffile;
    public int maxNbAffile;
    public TypeFake reponseCurrent;
    public GameObject tuto;

    public GameObject fbBtn;
    public bool choixFake = false;

    public void jouer()
    {
        vraimentJouer(null);
        ShowTuto();
        if (gameData.showTuto)
        {
            gameData.showTuto = false;
        }
    }

    public void jouerCategorie(string categorie)
    {
        vraimentJouer(categorie);
    }

    void Start()
    {

        initQuestionChoisie(null);

    }

    public void ShowTuto()
    {
        tuto.SetActive(true);
    }

    public void vraimentJouer(string cat)
    {
        count = 0;
        point = 0;
        pointMax = 0;
        maxNbAffile = 0;
        countNbAffile = 0;
        initQuestionChoisie(cat);
        Debug.Log(choisies.Count);
        uIManager.afficheQuestion(choisies[count]);
    }

    public void ReponseFake()
    {
        uIManager.afficheTypeFake();
    }

    public void GoReponse(TypeFake typeFake)
    {
        choisies[count].active = true;
        Debug.Log(typeFake);
        int cp = 0;
        int cpm = 0;
        if (choisies[count].typeFake == typeFake)
        {
            if (TypeFake.FACT == typeFake)
            {
                cp = 1;
                cpm = 1;

            }
            else
            {
                cp = 2;
                cpm = 2;
            }
        }
        else
        {
            if (TypeFake.FACT != typeFake)
            {
                cpm = 2;
                if (choixFake && choisies[count].typeFake != TypeFake.FACT)
                {
                    cp = 1;
                }
            }
            else
            {
                cpm = 1;
            }
        }
        point += cp;
        pointMax += cpm;
        Debug.Log("Tu as gagné " + cp + " sur les " + cpm + " possible");
        uIManager.afficheReponse(choisies[count], typeFake, getFakeData(choisies[count].typeFake));
    }

    public void GoReponseFake(TypeFake typeFake)
    {
        choixFake = true;
        uIManager.afficheTypeFakeValidation(getFakeData(typeFake));
    }


    public void ReponseFact()
    {
        GoReponse(TypeFake.FACT);
    }
    public void ValiderFake()
    {
        GoReponse(reponseCurrent);
    }
    public void rLienCausalDouteux()
    {
        reponseCurrent = TypeFake.LIEN_CAUSAL;
        GoReponseFake(TypeFake.LIEN_CAUSAL);
    }
    public void rPenteGlissante()
    {
        reponseCurrent = TypeFake.PENTE_GLISSANTE;
        GoReponseFake(TypeFake.PENTE_GLISSANTE);
    }
    public void rGeneralisationHative()
    {
        reponseCurrent = TypeFake.GENERALISATION;
        GoReponseFake(TypeFake.GENERALISATION);
    }

    public void rArgumentAutorite()
    {
        reponseCurrent = TypeFake.ARGUMENT_AUTORITER;
        GoReponseFake(TypeFake.ARGUMENT_AUTORITER);
    }

    public void rFauxDilemme()
    {
        reponseCurrent = TypeFake.FAUX_DILEMME;
        GoReponseFake(TypeFake.FAUX_DILEMME);
    }

    public void rFausseAnalogie()
    {
        reponseCurrent = TypeFake.FAUSSE_ANALOGIE;
        GoReponseFake(TypeFake.FAUSSE_ANALOGIE);
    }

    public void nextQuestion()
    {
        choixFake = false;
        count++;
        Debug.Log(count + " sus " + gameData.nbQuestion);
        if (count < choisies.Count)
            uIManager.afficheQuestion(choisies[count]);
        else
            afficheScore();

        Debug.Log(point + "/" + pointMax);
    }


    public void initQuestionChoisie(string cat)
    {
        Debug.Log(gameData.questions.Count + " dans game data");
        if (cat == null)
        {
            questions = gameData.questions
         .Where(q => q.active)
         .ToList();
        }
        else
        {
             questions = gameData.questions
         .Where(q => q.active)
         .ToList();
        }
     

        Debug.Log("questions " + questions.Count);

        choisies.Clear();

        // Vérifier que le nombre de questions demandées ne dépasse pas le nombre de questions disponibles
        int nombreQuestionsAAjouter = Mathf.Min(gameData.nbQuestion, questions.Count);

        // Créer un HashSet pour suivre les questions déjà ajoutées
        HashSet<Question> questionsAjoutees = new HashSet<Question>();

        // Initialiser un générateur de nombres aléatoires
        System.Random rand = new System.Random();

        while (questionsAjoutees.Count < nombreQuestionsAAjouter)
        {
            // Sélectionner une question aléatoire
            int index = rand.Next(questions.Count);
            Question questionChoisie = questions[index];

            // Vérifier si la question a déjà été ajoutée
            if (!questionsAjoutees.Contains(questionChoisie))
            {
                // Ajouter la question choisie à la liste choisies et au HashSet
                choisies.Add(questionChoisie);
                questionsAjoutees.Add(questionChoisie);
            }
        }
    }

    public void openFb()
    {
        Application.OpenURL(url_fb);
    }

    public void openInsta()
    {
        Application.OpenURL(url_insta);
    }

    public void openMetablue()
    {
        Application.OpenURL(url_mastodon);
    }

    public void changeNbQuestion(int nb)
    {
        this.gameData.nbQuestion = nb;
    }

    public void afficheScore()
    {
        uIManager.afficheScore(point, pointMax);
        foreach (var item in questions)
        {
            //item.active = false;
        }
    }

    public TypeFakeData getFakeData(TypeFake f)
    {
        foreach (var item in listFakes)
        {
            if (f == item.typeFake)
            {
                return item;
            }
        }

        return null;
    }



    public void partagerScore()
    {
        //Partage(10,20);
    }

    /*
    public void Partage(int point, int pointMax){
        FB.FeedShare(
            link: new System.Uri("https://metablue.blog/"),
            linkName: "J'ai terminé le jeu FakeBuster avec un score de "+point+"/"+pointMax+"!",
            linkCaption: "Tu peux y jouer aussi !",
            linkDescription: "Déjoue les fake news dans un quiz intelligent et fun.",
            picture: new System.Uri("https://metablue.blog/wp-content/uploads/2024/04/metablue_illustration-1.png"),
            callback: OnShareCallback
        );

    }
    private void OnShareCallback(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Partage annulé ou erreur : " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log("Partage réussi, ID : " + result.PostId);
        }
        else
        {
            Debug.Log("Partage terminé !");
        }
    }
*/




    IEnumerator CaptureAndSharaaae()
    {
        yield return new WaitForEndOfFrame();

        // Capture
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenTexture.Apply();

        // Sauvegarder l'image
        string filePath = Path.Combine(Application.temporaryCachePath, "screenshot.png");
        File.WriteAllBytes(filePath, screenTexture.EncodeToPNG());

        Destroy(screenTexture);

        // Appeler le partage natif Android
#if UNITY_ANDROID
    AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
    AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
    intentObject.Call<AndroidJavaObject>("setAction", "android.intent.action.SEND");
    intentObject.Call<AndroidJavaObject>("setType", "image/png");

    Debug.Log("File path: " + filePath);
    Debug.Log("File exists: " + File.Exists(filePath));

    AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
    AndroidJavaObject fileObject = new AndroidJavaObject("java.io.File", filePath);
    AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("fromFile", fileObject);

    intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

    AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
    currentActivity.Call("startActivity", intentObject);
#endif
    }


    public void ShareScreenshot()
    {
        StartCoroutine(CaptureAndShare());
    }




    private IEnumerator CaptureAndShare()
    {
        yield return new WaitForEndOfFrame();

        // Capture de l'écran
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenTexture.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "screenshot.png");
        File.WriteAllBytes(filePath, screenTexture.EncodeToPNG());

        Destroy(screenTexture);

        // Partage avec NativeShare
        new NativeShare()
            .AddFile(filePath)
            .SetSubject("Regarde mon score !")
            .SetText("Merci d'avoir participé à notre démo ! Si vous voulez nous soutenir retrouvez nous sur ulule")
            .SetTitle("Partager avec…")
            .Share();
    }



}
