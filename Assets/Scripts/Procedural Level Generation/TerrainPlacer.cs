using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TerrainPlacer : MonoBehaviour
{
    [SerializeField] private Transform _hero;
    [SerializeField] private Terrain[] _terrainPrefabs;
    [SerializeField] private Terrain _firstTerrain;
    private List<Terrain> _spawnedTerrain = new List<Terrain>();


    void Start()
    {
        _spawnedTerrain.Add(_firstTerrain);
    }

    void Update()
    {
        if (_hero.position.x > _spawnedTerrain[_spawnedTerrain.Count - 1]._finish.position.x - 13)
            SpawnTerrain();

        if (_hero.position.y <= -30)
            Respawn();
    }

    private void SpawnTerrain()
    {
        Terrain newTerrain = Instantiate(_terrainPrefabs[UnityEngine.Random.Range(0, _terrainPrefabs.Length)]);
        newTerrain.transform.position = _spawnedTerrain[_spawnedTerrain.Count - 1]._finish.position - newTerrain._begin.localPosition;
        _spawnedTerrain.Add(newTerrain);
        DestroyTerrain();
    }

    private void DestroyTerrain()
    {
        if (_spawnedTerrain.Count == 3)
        {
            Destroy(_spawnedTerrain[0].gameObject);
            _spawnedTerrain.RemoveAt(0);
        }
    }
   
    public static Action respawned;

    public void Respawn()
    {
        _hero.position = _spawnedTerrain[_spawnedTerrain.Count - 1]._spawnPoint.position;
        respawned?.Invoke();
}
}
