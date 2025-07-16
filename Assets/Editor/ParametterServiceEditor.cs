using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ParametterService))]
public class ParametterServiceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Dessiner l'inspecteur par défaut
        DrawDefaultInspector();

        // Cibler l'objet
        ParametterService service = (ParametterService) target;

        // Bouton "Init"
        if (GUILayout.Button("Init"))
        {
            service.GetList(null);
        }
       
    }
}
