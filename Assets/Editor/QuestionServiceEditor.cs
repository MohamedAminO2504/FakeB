using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestionService))]
public class QuestionServiceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Dessiner l'inspecteur par défaut
        DrawDefaultInspector();

        // Cibler l'objet
        QuestionService service = (QuestionService) target;

        // Bouton "Init"
        if (GUILayout.Button("Init"))
        {
            service.GetQuestionsList(null);
        }
         if (GUILayout.Button("Delete All Question Assets"))
        {
           // service.DeleteAllQuestionAssets();
        }
    }
}
