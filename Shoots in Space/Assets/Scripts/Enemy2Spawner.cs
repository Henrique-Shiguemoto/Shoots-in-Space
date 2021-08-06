using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    private Vector3 cameraPosition;
    private Vector2 screenBoundariesInWorldSpace;
    [SerializeField] private GameObject enemy2GameObject;

    public int initialWaveEnemyCount;
    [HideInInspector] public int waveEnemyCount;

    void Start()
    {
        cameraPosition = Camera.main.transform.position;
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraPosition.z));
        waveEnemyCount = initialWaveEnemyCount;

        SpawnEnemies(waveEnemyCount, transform.position.y + 10f, transform.position.y + 17f);
    }

    void Update()
    {
        if(waveEnemyCount <= 0){
            SpawnEnemies(initialWaveEnemyCount, transform.position.y + 10f, transform.position.y + 17f);
            waveEnemyCount = initialWaveEnemyCount;
        }
    }

    void SpawnEnemies(int waveEnemyCount, float yOffset1, float yOffset2)
    {
        float xOffset;
        float yOffset;
        Vector3 offsetSpawnPosition;
        for(int i = 0; i < waveEnemyCount; i++){
            xOffset = Random.Range(-screenBoundariesInWorldSpace.x + 1.5f, screenBoundariesInWorldSpace.x - 1.5f);
            yOffset = Random.Range(yOffset1, yOffset2);

            offsetSpawnPosition = new Vector3(xOffset, yOffset, 10f);

            enemy2GameObject.transform.position = cameraPosition + offsetSpawnPosition;
            Instantiate(enemy2GameObject, enemy2GameObject.transform.position, Quaternion.identity);
        }
    }
}
