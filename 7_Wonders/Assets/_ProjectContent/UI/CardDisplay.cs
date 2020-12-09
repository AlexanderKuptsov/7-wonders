using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;



public class CardDisplay : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    //Si nous sommes au cours du premier age alors on choisi
    public CardData card;

    //On parcourt tous les types de cartes

   // public List<CardData> cardRaw;


    

    public TextMeshProUGUI nameText;
    public Image effect;

    public Image costeffect;
    //public GameObject originalcard;
    //Start is called before the first frame update
    void Start()
    {
       // GameObject cardClone = Instantiate(originalcard,new Vector3(125,0,0),Quaternion.identity);
      
    // CreateCards(7);
    //nameText = GetComponent<TextMeshPro>();
    nameText.text = card.cardname;
    effect.sprite = card.effect;
    costeffect.sprite = card.costeffect;
  
    this.GetComponent<Image>().color = card.change_color();
    }
    
    void Update()
    {
         transform.Rotate(new Vector3(0f, 100f,0f)*Time.deltaTime);  
    }
    
    void CreateCards(int number)
    {
      for (int i = 0; i < number; i++)
       {
//Instantiate(originalcard,new Vector3(i,originalcard.transform.position.y,i),originalcard.transform.rotation);
       }
    }
    

   public void OnBeginDrag(PointerEventData eventData)
   {

   }
    public void OnDrag(PointerEventData eventData)
   {
       this.transform.position = eventData.position;
   }
    public void OnEndDrag(PointerEventData eventData)
   {

   }
}
