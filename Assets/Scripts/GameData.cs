using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Question", menuName = "Quiz/Data", order = 2)]
public class GameData : ScriptableObject
{
   public int nbQuestion;
   public UserData user;
   public bool showTuto;

   public List<TypeFakeData> typesFake;

   public List<Question> questions;

   public List<CategorieData> categories;

   public Paramettre paramettre;

   public TypeFake getTypeFakeByLibelle(string libelle)
   {
      Debug.Log(libelle);
      foreach (var item in typesFake)
      {
         if (item.typeFake + "" == libelle)
         {
            return item.typeFake;
         }
      }
      return TypeFake.FACT;
   }

   public Question getFakeById(int id)
   {
      foreach (var item in questions)
      {
         if (item.id == id)
         {
            return item;
         }
      }
      foreach (var item in questions)
      {
         if (item.id == 0)
         {
            return item;
         }
      }
      return null;
   }

   public CategorieData GetCategorieLibre()
   {
      foreach (var item in categories)
      {
         if (item.name == "")
         {
            return item;
         }
      }
      return null;
   }
}
