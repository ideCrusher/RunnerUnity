using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAndSet : MonoBehaviour
{
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
                PlayerPrefs.SetInt($"ToHave_{Name}",1);
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
            Text Name = transform.Find("Name").GetComponent<Text>();
            PlayerPrefs.SetString("Skin",$"{Name.text}");   
        }
        
    }

    
}
