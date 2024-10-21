using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] int Width;
    [SerializeField] int Lenght;
    [SerializeField] GameObject[] Level1Prefabs;
    [SerializeField] GameObject[] Level2Prefabs;
    [SerializeField] GameObject[] Level3Prefabs;
    [SerializeField] GameObject TilesBuiltGrp;
    [SerializeField] float TilesSizeX;
    [SerializeField] float TilesSizeZ;
    [SerializeField] Vector3 spawnPos;

    // Start is called before the first frame update

    void Start()
    {
        SpawnLevel1();
        SpawnLevel2();
        SpawnLevel3();
    }

    void SpawnLevel1()
    {

        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Lenght; z++)
            {
                int randomTile = UnityEngine.Random.Range(0, Level1Prefabs.Length); //Pick random number from the array

                Vector3 tilePosition = new Vector3(spawnPos.x + x * TilesSizeX, spawnPos.z + z * TilesSizeZ, spawnPos.y);
                GameObject tileInstance = Instantiate(Level1Prefabs[randomTile], tilePosition, Quaternion.Euler(0, 0, 0)); //Instanciate the index picked

                tileInstance.transform.SetParent(TilesBuiltGrp.transform); //Assign each tile as child from spawner
            }
        }
    }

    void SpawnLevel2()
    {

        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Lenght; z++)
            {
                int randomTile = UnityEngine.Random.Range(0, Level2Prefabs.Length); //Pick random number from the array

                Vector3 tilePosition = new Vector3(spawnPos.x + x * TilesSizeX, spawnPos.z + (z * TilesSizeZ) - (Lenght * TilesSizeZ), spawnPos.y);
                GameObject tileInstance = Instantiate(Level2Prefabs[randomTile], tilePosition, Quaternion.Euler(0, 0, 0)); //Instanciate the index picked

                tileInstance.transform.SetParent(TilesBuiltGrp.transform); //Assign each tile as child from spawner
            }
        }
    }

    void SpawnLevel3()
    {

        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Lenght; z++)
            {
                int randomTile = UnityEngine.Random.Range(0, Level3Prefabs.Length); //Pick random number from the array

                Vector3 tilePosition = new Vector3(spawnPos.x + x * TilesSizeX, spawnPos.z + (z * TilesSizeZ) - (Lenght * TilesSizeZ * 2), spawnPos.y);
                GameObject tileInstance = Instantiate(Level3Prefabs[randomTile], tilePosition, Quaternion.Euler(0, 0, 0)); //Instanciate the index picked

                tileInstance.transform.SetParent(TilesBuiltGrp.transform); //Assign each tile as child from spawner
            }
        }
    }

    /*

    [SerializeField] BuildDungeon buildDungeon;
    [SerializeField] GameObject DungeonTilesBuilt;

    [SerializeField] GameObject EnemiesCreated;

    [SerializeField] internal int EnemiesNeeded;
    [SerializeField] float SpawnDelay;

    [System.Serializable]
    class EnemiesAvailable
    {
        [SerializeField] internal GameObject EnemyPrefab;
        [Range(0, 1)]
        [SerializeField] internal float WeightPerc;
    }

    [SerializeField] List<EnemiesAvailable> Enemies;

    List<GameObject> EnemiesSpawning = new List<GameObject>();

    float totalWeight;

    private void Awake()
    {
        foreach (EnemiesAvailable enemiesAvailable in Enemies)
        {
            totalWeight += enemiesAvailable.WeightPerc;
        }
    }

    private void Start()
    {
        ListEnemiesToSpawn();
    }

    internal void StartSpawnCoroutine()
    {
        StartCoroutine(SpawnEnemiesList());
    }

    IEnumerator SpawnEnemiesList()
    {
        int tilesAvailable = DungeonTilesBuilt.transform.childCount;

        foreach (GameObject enemy in EnemiesSpawning)
        {
            int randomPos = UnityEngine.Random.Range(0, tilesAvailable);
            Transform child = DungeonTilesBuilt.transform.GetChild(randomPos);
            enemy.transform.position = child.transform.position;
            enemy.SetActive(true);

            yield return new WaitForSeconds(SpawnDelay);
        }
        Debug.Log("FinishedCoroutine");
    }

    public void ListEnemiesToSpawn()
    {
        for (int i = 0; i < EnemiesNeeded; i++)
        {
            float randomNumber = Random.Range(0, totalWeight);

            GameObject RandomEnemy = FindRandomEnemyWeighted(randomNumber);
            if (RandomEnemy != null)
            {
                GameObject Instance = Instantiate(RandomEnemy);
                Instance.transform.SetParent(EnemiesCreated.transform);
                Instance.SetActive(false);
                EnemiesSpawning.Add(Instance);
            }
        }
    }

    private GameObject FindRandomEnemyWeighted(float randomNumber)
    {
        // Loop through the pool and check which object can be called with randomNumber
        foreach (EnemiesAvailable picked in Enemies)
        {
            if (randomNumber < picked.WeightPerc)
            {
                return picked.EnemyPrefab;
            }
            randomNumber -= picked.WeightPerc;
        }
        float newRandomNumber = Random.Range(0, totalWeight);
        return FindRandomEnemyWeighted(newRandomNumber);
    }

    */
}


