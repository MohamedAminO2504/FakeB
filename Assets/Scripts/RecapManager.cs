using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecapManager : MonoBehaviour
{
    public GameManager gameManager;

    public int page;

    public ItemRecapUI recapUI_1;
    public ItemRecapUI recapUI_2;

    public GameObject btnSuivant;
    public GameObject btnPrecedent;

    public Button button1;
    public Button button2;

    public RecapDetailUI recapDetailUi;

    public List<Question> questionVu;

    public void Init(){
        page = 0;
        questionVu = new List<Question>();  

        foreach (var item in  gameManager.questions)
        {
            if(item.active){
                questionVu.Add(item);
            }
        }

        
        int nbDeQuestion = questionVu.Count;
        int nbDeQuestionPasse = page*2;
        int nbDeQuestionRestante = nbDeQuestion - nbDeQuestionPasse;
        Debug.Log("restante " + nbDeQuestionRestante);
        if(nbDeQuestionRestante > 2 ){
            initItem(recapUI_1,button1, page);
            initItem(recapUI_2,button2, page+1);
        }else if(nbDeQuestionRestante == 1)
        {
            HideItems();
            initItem(recapUI_1,button1, 0);
            recapUI_2.gameObject.SetActive(false);
        }else{
            HideItems();
        }
        
        btnPrecedent.SetActive(true);
        btnSuivant.SetActive(true);


        if(questionVu.Count < 2){
            btnSuivant.SetActive(false);
            btnPrecedent.SetActive(false);
        }else{
            btnSuivant.SetActive(true);
            btnPrecedent.SetActive(false);
   
        }
       
    }

    public void HideItems(){
        recapUI_1.gameObject.SetActive(false);
        recapUI_2.gameObject.SetActive(false);
                btnPrecedent.SetActive(false); 
                btnSuivant.SetActive(false);
    }

    public void InitItems(){
int nbDeQuestion = questionVu.Count;
        int nbDeQuestionPasse = page*2;
        int nbDeQuestionRestante = nbDeQuestion - nbDeQuestionPasse;
        if(nbDeQuestionRestante > 2 ){
            initItem(recapUI_1,button1, page*2);
            initItem(recapUI_2,button2, page*2+1);
        }else if(nbDeQuestionRestante == 1)
        {
            HideItems();
            initItem(recapUI_1,button1, page*2);
            recapUI_2.gameObject.SetActive(false);
        }else{
            HideItems();
        }


    }

    public void initBtn(Button b1, Question q1){
        b1.onClick.RemoveAllListeners();
        b1.onClick.AddListener(()=>ShowRecap(q1));
    }

    public void ShowRecap(Question q1){
        recapDetailUi.gameObject.SetActive(true);
        recapDetailUi.init(q1);
    }

    public void initItem(ItemRecapUI recapUI, Button button, int index){
        Debug.Log("Affichage de l'index  "+index);
        recapUI.gameObject.SetActive(true);

        Question q = questionVu[index];
                        Debug.Log("question traiter "+index+" "+q.name);

        recapUI.libelle.text = q.libelle;
        initBtn(button,q);
    }

    public void changePageSuivante(){
        page++;
        InitItems();
         if((page + 1) >= (questionVu.Count/2)   ){
                btnSuivant.SetActive(false);
        }  
        btnPrecedent.SetActive(true);

    }
    public void changePagePrecedente(){
        page--;
        InitItems();
        if(page == 0 ){
            btnPrecedent.SetActive(false);
        }
                                btnSuivant.SetActive(true);

    }
    
}
