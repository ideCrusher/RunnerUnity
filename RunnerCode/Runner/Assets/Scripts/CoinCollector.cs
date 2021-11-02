using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public Transform Player;
    public CoinScript[] CoinPrefs;
    public CoinScript FirstCoin;
    private List<CoinScript> _CoinSpawn = new List<CoinScript>();
    void Start()
    {
        _CoinSpawn.Add(FirstCoin);
    }


    void Update()
    {
        if (Player.position.x > _CoinSpawn[_CoinSpawn.Count - 1].transform.position.x - 30f)
        {
            CoinSpawner();
            CoinDestroyer();
        }
    }

    void CoinSpawner()
    {
        for(int i = _CoinSpawn.Count - 1; i< 9; i++)
        {        
        CoinScript newCoin = Instantiate(CoinPrefs[Random.Range(0,CoinPrefs.Length)]);
        Vector3 trapPX = new Vector3();
        trapPX.x = _CoinSpawn[_CoinSpawn.Count - 1].transform.position.x + Random.Range(5, 30);
        trapPX.y = Random.Range(-1.3f, 1.3f);       
        newCoin.transform.position = trapPX;
        _CoinSpawn.Add(newCoin);
        } 
    }
    void CoinDestroyer()
    {
        for(int i = _CoinSpawn.Count - 1; i > 6; i--)
            {
                Destroy(_CoinSpawn[0].gameObject);
                _CoinSpawn.RemoveAt(0);
            } 
    }
    
}
