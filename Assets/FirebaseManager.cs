using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Extensions;
using Google;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    public string GoogleWebClientId = "675259856823-1nug59irmnuvr97gomau3oj5ttcgresl.apps.googleusercontent.com";

    private GoogleSignInConfiguration configuration;

    public Paramettre paramettre;

    public UtilisateurService utilisateurService;
    
    private FirebaseAuth auth;
    private FirebaseUser user;

    void Awake()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = GoogleWebClientId,
            RequestIdToken = true,
            RequestEmail = true,
        };

        auth = FirebaseAuth.DefaultInstance;
    }

    public void Login()
    {
       
        if (paramettre.environnement == Environnement.LOCAL)
        {
            UtilisateurApi u = new UtilisateurApi();
            u.email = "email@text.com";
            u.id = "11111";
            u.nom = "Niwa";
            u.prenom = "Momo";
            utilisateurService.Connexion(u);
        }
        else
        {
             GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        GoogleSignIn.Configuration.RequestEmail = true;

            GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnGoogleSignInFinished);
        }

    }




    private void OnGoogleSignInFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            Debug.LogError("Google sign-in failed: " + task.Exception);
            return;
        }

        if (task.IsCanceled)
        {
            Debug.LogWarning("Google sign-in was canceled.");
            return;
        }

        // Authentification Firebase avec les identifiants Google
        Credential credential = GoogleAuthProvider.GetCredential(task.Result.IdToken, null);

        auth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(authTask =>
        {
            if (authTask.IsCanceled || authTask.IsFaulted)
            {
                Debug.LogError("Firebase auth failed: " + authTask.Exception);
                return;
            }

            user = auth.CurrentUser;

            Debug.Log("Connexion réussie !");
            Debug.Log("Nom : " + user.DisplayName);
            Debug.Log("Email : " + user.Email);
            Debug.Log("Photo : " + user.PhotoUrl);

            UtilisateurApi u = new UtilisateurApi();
            u.email = user.Email;
            u.id = user.UserId;
            u.nom =  user.DisplayName;
            utilisateurService.Connexion(u);
        });
    }
}
