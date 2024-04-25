
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;

        [Range(0f, 1f)]
        public float spawnChance;
    }
    
    public SpawnableObject[] obstacles;

    public float minSpawnRate = 0f;
    public float maxSpawnRate = 1f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    void Spawn()
    {
        float spawnChane = Random.value;

        foreach(var obstacle in obstacles)
        {
            if(spawnChane < obstacle.spawnChance)
            {
                GameObject obj = Instantiate(obstacle.prefab);
                obj.transform.position += transform.position;
                break;
            }
            spawnChane -= obstacle.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
