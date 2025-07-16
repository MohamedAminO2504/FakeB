using Firebase;
using Firebase.Auth;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    public static FirebaseAuth auth;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                Debug.Log("Firebase Ready");
            }
            else
            {
                Debug.LogError("Could not resolve Firebase dependencies: " + task.Result);
            }
        });
    }
}
