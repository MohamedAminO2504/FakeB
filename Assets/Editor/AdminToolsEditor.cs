using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AdminTools))]
public class AdminToolsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Dessiner l'inspecteur par défaut
        DrawDefaultInspector();

        // Cibler l'objet
        AdminTools adminTools = (AdminTools)target;

      
    }
}
