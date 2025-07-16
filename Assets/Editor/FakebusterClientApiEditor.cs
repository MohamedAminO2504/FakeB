using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FakebusterClientApi))]
public class FakebusterClientApiEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Dessiner l'inspecteur par défaut
        DrawDefaultInspector();

        // Cibler l'objet
        FakebusterClientApi t = (FakebusterClientApi)target;

        // Bouton "Init"
        if (GUILayout.Button("send"))
        {
            t.EnvoyerQuestion();
        }
        
 if (GUILayout.Button("RecupererQuestion"))
        {
            t.RecupererQuestion();
        }
        
    }
}