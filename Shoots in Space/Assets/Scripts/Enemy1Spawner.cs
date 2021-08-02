using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    //private variables
    private Vector3 cameraPosition;
    private Vector2 screenBoundariesInWorldSpace;
    private Vector3 offsetSpawnPosition; //Random offset position in relation to the camera
    private float xOffset;
    private float yOffset;

    //public variables
    public int waveEnemyCount;    
    public GameObject enemy1GameObject;
    void Start()
    {
        //We need the screen boundaries in world space so we can limit the X spawn position of the enemy
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
                                                                                  Camera.main.transform.position.z));
        cameraPosition = Camera.main.transform.position;

        //Spawning waveEnemyCount enemies in a random position outside the camera view
        for(int i = 0; i < waveEnemyCount; i++){
            //Calculating random position offset values
            xOffset = Random.Range(-screenBoundariesInWorldSpace.x, screenBoundariesInWorldSpace.x);
            yOffset = Random.Range(9, 15);

            //Setting the offset position
            offsetSpawnPosition = new Vector3(xOffset, yOffset, 10f);
            enemy1GameObject.transform.position = cameraPosition + offsetSpawnPosition; //Setting the enemy's position

            //Instantiating in the set position with no rotation
            Instantiate(enemy1GameObject, enemy1GameObject.transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        //needs timer
    }
}
