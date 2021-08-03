using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    //private variables
    private Vector3 cameraInitialPosition;
    private Vector2 screenBoundariesInWorldSpace;
    private Vector3 offsetSpawnPosition; //Random offset position in relation to the camera
    private float xOffset;
    private float yOffset;
    //private float waitTimerForNextWave = 4f; //Wait time for the next wave
    [SerializeField] private GameObject enemy1GameObject;

    //Public variables
    public int initialWaveEnemyCount;
    public int waveEnemyCount;

    void Start()
    {
        waveEnemyCount = initialWaveEnemyCount;

        //We need the screen boundaries in world space so we can limit the X spawn position of the enemy
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
                                                                                  Camera.main.transform.position.z));
        cameraInitialPosition = Camera.main.transform.position;

        SpawnEnemies(initialWaveEnemyCount, 9f, 16f);
    }

    void Update()
    {
        if(waveEnemyCount <= 0){
            //Respawning enemies
            SpawnEnemies(initialWaveEnemyCount, Camera.main.transform.position.y + 10f, Camera.main.transform.position.y + 17f);
            waveEnemyCount = initialWaveEnemyCount;
        }
    }

    void SpawnEnemies(int initialWaveEnemyCount, float yOffset1, float yOffset2)
    {
        //Spawning initialWaveEnemyCount enemies in a random position outside the camera view
        for(int i = 0; i < initialWaveEnemyCount; i++){
            //Calculating random position offset values
            xOffset = Random.Range(-screenBoundariesInWorldSpace.x, screenBoundariesInWorldSpace.x);
            yOffset = Random.Range(yOffset1, yOffset2);

            //Setting the offset position
            offsetSpawnPosition = new Vector3(xOffset, yOffset, 10f);
            enemy1GameObject.transform.position = cameraInitialPosition + offsetSpawnPosition; //Setting the enemy's position

            //Instantiating in the set position with no rotation
            Instantiate(enemy1GameObject, enemy1GameObject.transform.position, Quaternion.identity);
        }
    }
}