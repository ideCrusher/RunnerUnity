using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinMenu : MonoBehaviour
{
    public List<SKINS> SkinList = new List<SKINS>();
    private Button[] _ButtonInSkin;  
    [SerializeField] private Button buttonPrefs;

    void Start()
    {
        Button newButton = Instantiate(buttonPrefs);
        
    }
}
[System.Serializable]
public class SKINS
{
    public int id;
    public string name;
    public int price;
    public Sprite png;
}
