using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {
    public float spawnDelayMin = 0.3f, spawnDelayMax = 2f;
    public GameObject[] zombiePrefabs;
    private float nextSpawnTime = 0f;
    private float spawnTimer = 0f;
	//--------------------
	void Start () {
	
	}
	void Update () {
        if (spawnTimer >= nextSpawnTime) {
            Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Length)], GameController.GetRandomSpawnPoint(), Quaternion.identity);
            nextSpawnTime = spawnTimer + Random.Range(spawnDelayMin, spawnDelayMax);
        }
        spawnTimer += Time.deltaTime;
    }
}
