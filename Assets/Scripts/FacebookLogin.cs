using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class FacebookLoginButton : MonoBehaviour
{
/*    public TextMeshProUGUI statusText;
    public GameManager gameManager;

    public void LoginWithFacebook()
    {
        var permissions = new[] { "public_profile", "email" };
        FB.LogInWithReadPermissions(permissions, AuthCallback);
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            var aToken = AccessToken.CurrentAccessToken;
            Debug.Log("Connecté avec Facebook ! UserID : " + aToken.UserId);

            if (statusText != null)
                statusText.text = "Connexion réussie ! Chargement du profil...";

            // Récupérer nom + photo
            FB.API("/me?fields=id,name,picture.width(200).height(200)", HttpMethod.GET, OnUserInfoCallback);
        }
        else
        {
            Debug.Log("Connexion Facebook annulée ou échouée.");
            if (statusText != null)
                statusText.text = "Connexion annulée.";
        }
    }

    private void OnUserInfoCallback(IGraphResult result)
    {
        if (result.Error == null)
        {   
            var data = result.ResultDictionary;
            foreach (var kvp in data)
            {
                Debug.Log($"[FacebookData] {kvp.Key} = {kvp.Value}");
            }
            string name = data["name"].ToString();
            var picData = (Dictionary<string, object>)(((Dictionary<string, object>)data["picture"])["data"]);
            string pictureUrl = picData["url"].ToString();

            if (statusText != null)
                statusText.text = "Bienvenue, " + name;

            Debug.Log("Nom : " + name);
            Debug.Log("Image de profil : " + pictureUrl);

            // Charger l'image de profil (async)
            UserData user = new UserData();
            user.name = data["name"].ToString();
            user.fb_id = data["id"].ToString();
            user.fb_image_url = pictureUrl;
            gameManager.UpdateUser(user);

        }
        else
        {
            Debug.Log("Erreur lors de la récupération du profil : " + result.Error);
            if (statusText != null)
                statusText.text = "Erreur de profil.";
        }
    }
   */

}