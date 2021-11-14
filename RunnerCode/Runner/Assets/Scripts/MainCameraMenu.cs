using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMenu : MonoBehaviour
{
    
    private Transform _PlayerPos;
    public CharacterMovment[] characterPrefab;
    private Vector3 _startPosition = new Vector3(-7.6f,0f,-10f);
    private string _Skin;

    void Start()
    {
        _Skin = PlayerPrefs.GetString("Skin");
        GameObject spawn = Instantiate(Resources.Load($"Prefab/{_Skin}")) as GameObject;
        
        spawn.transform.position = _startPosition;

        _PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }
    void Update()
    {
        
        Vector3 pos = transform.position;  
        Vector3 posZ = transform.position;
        pos.x = _PlayerPos.position.x + 6.6f;
        pos.z = posZ.z;  
        transform.position = pos;
    }
}
