using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnSections : MonoBehaviour
{
    public Transform Player;
    public Section[] SectioPref;
    public Section FirstSection;
    public Trap[] TrapPrefab; 
    public Trap FirstTrap;
    private List<Trap> _spawnTraps = new List<Trap>();
    private List<Section> _spawnSectors = new List<Section>();
    void Start()
    {
        
        _spawnSectors.Add(FirstSection);

        _spawnTraps.Add(FirstTrap);

        SpawnTraps();
    }

    void Update()
    {
        if (Player.position.x > _spawnSectors[_spawnSectors.Count - 1].End.position.x - 15f)
        { 
            SpawnSection(); 
            
        }        
        if(Player.position.x > _spawnTraps[4].transform.position.x)
        {
            SpawnTraps();
        }
        if(Player.position.x > _spawnTraps[6].transform.position.x)
        {      
            TrapDestroyr();
        }
    }
    void SpawnSection()
    {                        
        Section newChunk = Instantiate(SectioPref[Random.Range(0, SectioPref.Length)]);
        newChunk.transform.position = _spawnSectors[_spawnSectors.Count - 1].End.position - newChunk.Begin.localPosition;
        _spawnSectors.Add(newChunk);   
        if (_spawnSectors.Count >= 4)
        {
            Destroy(_spawnSectors[0].gameObject);
            _spawnSectors.RemoveAt(0);
        }
    }

    void SpawnTraps()
    {
        for(int i = _spawnTraps.Count - 1; i< 9; i++)
        {        
        Trap newTrap = Instantiate(TrapPrefab[Random.Range(0,TrapPrefab.Length)]);
        Vector3 trapPX = new Vector3();
        trapPX.x = _spawnTraps[_spawnTraps.Count - 1].transform.position.x + Random.Range(10, 20);
        trapPX.y = Random.Range(-1.35f, 1.35f);       
        newTrap.transform.position = trapPX;
        _spawnTraps.Add(newTrap);
        }     
    }
    void TrapDestroyr()
    {
            for(int i = _spawnTraps.Count - 1; i > 6; i--)
            {
            Destroy(_spawnTraps[0].gameObject);
            _spawnTraps.RemoveAt(0);
            } 
    }
}
