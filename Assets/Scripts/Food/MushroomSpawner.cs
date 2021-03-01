using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MushroomSpawner : MonoBehaviour
{
    public float minRespawnTime;
    public float maxRespawnTime;
    public float minMushroomSize;
    public float maxMushroomSize;
    private float _respawnTime;
    private Vector3 _respawnSize;
    private List<Transform> _spawnPoints;
    private Mushroom _mushroomPrefab;

    [Inject] private void Construct(List<Transform> spawnPoints, Mushroom mushroomPrefab)
    {
        _spawnPoints = spawnPoints;
        _mushroomPrefab = mushroomPrefab;

        for(int i = 0; i < _spawnPoints.Count; i++)
        {
            SpawnMashroom(_spawnPoints[i].position, Random.Range(minMushroomSize, maxMushroomSize));   
        }
    }
    private void OnInteraction(Mushroom mushroom)
    {
        _respawnTime = Time.time + Random.Range(minRespawnTime, maxRespawnTime);

        StartCoroutine(Respawn(mushroom.transform.position, Random.Range(minMushroomSize, maxMushroomSize)));
        
        mushroom.OnInteruct -= OnInteraction;
        Destroy(mushroom.gameObject);
    }
    private IEnumerator Respawn(Vector3 position, float size)
    {
        while(_respawnTime > Time.time)
            yield return null;
        
        SpawnMashroom(position, size);
    }
    private void SpawnMashroom(Vector3 position, float size)
    {
        _respawnSize.Set(size, size, size);

        Mushroom mushroom = Instantiate(_mushroomPrefab, position, Quaternion.identity, transform);
        mushroom.transform.localScale = _respawnSize;

        mushroom.OnInteruct += OnInteraction;
    }
}
