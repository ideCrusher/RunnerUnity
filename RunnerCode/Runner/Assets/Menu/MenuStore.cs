using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuStore : MonoBehaviour
{ 
    public List<SKINS> SkinLists = new List<SKINS>();   
    public Image Prefab;
    private Image _FirstSlotPrefab;
    private List<Image> _ListSlotsPrefab = new List<Image>();
    private const float _posX = -150.0f,_posY = 43.0f;
    private Vector3 _PosTabs = new Vector3(-150.0f,43.0f,0);
    void Start()
    {
        PlayerPrefs.SetInt("ToHave_Witch", 1);
        
        foreach(SKINS Skin in SkinLists)
        {
            
            Image Slot = Instantiate(Prefab, _PosTabs, Quaternion.identity);
            Slot.transform.SetParent(GameObject.Find("CharacterStore").transform, false);    
            Vector3 SlotPos = Slot.transform.localPosition;
            Image SlotImage = Slot.transform.Find("Image").GetComponent<Image>();              
            Text SlotPrice = Slot.transform.Find("Price").GetComponent<Text>();
            Text Slotname = Slot.transform.Find("Name").GetComponent<Text>();
            

            if(_ListSlotsPrefab.Count > 0)
            {
                SlotPos.x = _ListSlotsPrefab[_ListSlotsPrefab.Count-1].transform.localPosition.x + 100.0f;
                if(_ListSlotsPrefab.Count%4 == 0 )
                {
                    SlotPos = SlotPos - new Vector3(400.0f,83.0f,0);
                    _PosTabs = SlotPos;
                }
            }
            Slotname.text = Skin.name;
            SlotImage.sprite = Skin.png;      
            SlotPrice.text = Skin.price.ToString();       
            Slot.transform.localPosition = SlotPos;

            int ToHave = PlayerPrefs.GetInt($"ToHave_{Slotname.text}");
            Button Butt = Slot.transform.Find("Set").GetComponent<Button>();
            Text SlotButtonText = Slot.transform.Find("Set").transform.Find("Text").GetComponent<Text>();
            Image ButtImage = Slot.transform.Find("Set").GetComponent<Image>();
            if(ToHave == 1)
            {
                SlotButtonText.text = "Set";
                ButtImage.color = Color.gray;
               //Slot.transform.Find("Price").GetComponent<Renderer>().enabled = false;
            }

            
            _ListSlotsPrefab.Add(Slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
