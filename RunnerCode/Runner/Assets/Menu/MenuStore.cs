using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class MenuStore : MonoBehaviour
{ 
    public List<SKINS> SkinLists = new List<SKINS>();   
    public Image Prefab;
    private Image _FirstSlotPrefab;
    private List<Image> _ListSlotsPrefab = new List<Image>();
    private const float _posX = -150.0f,_posY = 43.0f;
    private Vector3 _PosTabs = new Vector3(-150.0f,43.0f,0);
    private int _Active;
    Vector3 SlotPos;
    Image SlotImage;             
    Text SlotPrice;
    Text Slotname;
    Button Butt;
    Text SlotButtonText;
    Image ButtImage;
    void Start()
    {   
        MainVoid();
    }
     public void BuyOrSetSkin()
    {
        Text text = transform.Find("Set").transform.Find("Text").GetComponent<Text>();
        if( text.text == "Buy")
        {
            int Money = PlayerPrefs.GetInt("CoinsScore");
            int Price = Convert.ToInt32(transform.Find("Price").GetComponent<Text>().text);
            Text Name = transform.Find("Name").GetComponent<Text>();
            if(Money >= Price)
            {
                Money = Money - Price;
                PlayerPrefs.SetInt($"ToHave_{Name.text}",1);
                PlayerPrefs.SetInt("CoinsScore",Money);
                Button Butt = transform.Find("Set").GetComponent<Button>();
                Text SlotButtonText = transform.Find("Set").transform.Find("Text").GetComponent<Text>();
                Image ButtImage = transform.Find("Set").GetComponent<Image>();
                SlotButtonText.text = "Set";
                ButtImage.color = Color.gray;
            }
        }
        if(text.text == "Set")
        {
            Text SlotButtonTextAll = transform.Find("Set").transform.Find("Text").GetComponent<Text>();
            Text Name = transform.Find("Name").GetComponent<Text>();
            PlayerPrefs.SetString("Skin",$"{Name.text}");   
            Debug.Log(GameObject.Find("CharacterStore").transform.GetChild(1).name);
            for(int i = 1; i<transform.childCount; i++)
            {
                Text SlotButtonTextAlla = GameObject.Find("CharacterStore").transform.GetChild(i).gameObject.transform.Find("Set").transform.Find("Text").GetComponent<Text>(); 
                if(SlotButtonTextAlla.text == "Active")
                {
                    SlotButtonTextAlla.text = "Set";  
                }
            }   
            SlotButtonTextAll.text = "Active"; 
        }
    } 
    void Setting(Image Slot)
    {
        SlotPos = Slot.transform.localPosition;
        SlotImage = Slot.transform.Find("Image").GetComponent<Image>();              
        SlotPrice = Slot.transform.Find("Price").GetComponent<Text>();
        Slotname = Slot.transform.Find("Name").GetComponent<Text>();
        Butt = Slot.transform.Find("Set").GetComponent<Button>();
        SlotButtonText = Slot.transform.Find("Set").transform.Find("Text").GetComponent<Text>();
        ButtImage = Slot.transform.Find("Set").GetComponent<Image>();
    }
    void MainVoid()
    {
        foreach(SKINS Skin in SkinLists)
        {
            Image Slot = Instantiate(Prefab, _PosTabs, Quaternion.identity);
            Slot.transform.SetParent(GameObject.Find("CharacterStore").transform, false);    
            Setting(Slot);
            if(_ListSlotsPrefab.Count > 0)
            {
                SlotPos.x = _ListSlotsPrefab[_ListSlotsPrefab.Count-1].transform.localPosition.x + 100.0f;
                if(_ListSlotsPrefab.Count%4 == 0 )
                {
                    SlotPos = SlotPos - new Vector3(400.0f,83.0f,0);
                    _PosTabs = SlotPos;
                    _Active = _ListSlotsPrefab.Count;
                }
            }
            Slotname.text = Skin.name;
            SlotImage.sprite = Skin.png;      
            SlotPrice.text = Skin.price.ToString();       
            Slot.transform.localPosition = SlotPos;
            Loader();
            _ListSlotsPrefab.Add(Slot);
        }
    }

    void Loader()
    {
        int ToHave = PlayerPrefs.GetInt($"ToHave_{Slotname.text}");
        if(ToHave == 1)
        {
            SlotButtonText.text = "Set";
            ButtImage.color = Color.gray;
            if(PlayerPrefs.GetString("Skin") == Slotname.text)
            {
                SlotButtonText.text = "Active";
            }
        }
    }
}
