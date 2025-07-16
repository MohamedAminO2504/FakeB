using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TypeFakeService))]
public class TypeFakeServiceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Dessiner l'inspecteur par défaut
        DrawDefaultInspector();

        // Cibler l'objet
        TypeFakeService service = (TypeFakeService) target;

        // Bouton "Init"
        if (GUILayout.Button("Init"))
        {
            service.GetList(null);
        }
         if (GUILayout.Button("Post All Assets"))
        {
        }
    }
}
