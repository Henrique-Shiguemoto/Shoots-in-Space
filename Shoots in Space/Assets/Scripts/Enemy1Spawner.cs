using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    private Vector3 cameraPosition;
    private Vector2 screenBoundariesInWorldSpace;

    //Random offset position in relation to the camera
    private Vector3 offsetSpawnPosition;
    void Start()
    {
        //We need the screen boundaries in world space so we can limit the X spawn position of the enemy
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
                                                                                  Camera.main.transform.position.z));
        cameraPosition = Camera.main.transform.position;

        //The spawn position will be 9 units up in relation to the camera and 
        //in a random X position within the screen width boundaries
        offsetSpawnPosition = new Vector3(Random.Range(-screenBoundariesInWorldSpace.x, 
                                                        screenBoundariesInWorldSpace.x), 9f, 0f);
        transform.position = cameraPosition + offsetSpawnPosition; //Setting the enemy's position
    }
}
