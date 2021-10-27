using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnSections : MonoBehaviour
{
    public Transform Player;
    public Section[] SectioPref;
    public Section FirstSection;
    private List<Section> _spawnSectors = new List<Section>();
    void Start()
    {
        Section FirstSectionDouble = FirstSection;
        _spawnSectors.Add(FirstSectionDouble);
    }

    void Update()
    {
        if (Player.position.x > _spawnSectors[_spawnSectors.Count - 1].End.position.x - 15)
        {
            SpawnSection();
        }
    }


    void SpawnSection()
    {
        
        Section newChunk = Instantiate(SectioPref[Random.Range(0, SectioPref.Length)]);
        newChunk.transform.position = _spawnSectors[_spawnSectors.Count - 1].End.position - newChunk.Begin.localPosition;
        _spawnSectors.Add(newChunk);

        if (_spawnSectors.Count > 3)
        {
            Destroy(_spawnSectors[0].gameObject);
            _spawnSectors.RemoveAt(0);
        }
    
    }
}
