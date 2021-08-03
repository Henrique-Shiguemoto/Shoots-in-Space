using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    //Private variables
    private Vector3 cameraPosition;
    private float cameraSpeed;
    private float enemySpeed;
    private Enemy1Spawner enemy1Spawner;

    //Public variables
    public float enemySpeedDownScale; //Will reduce enemy speed in relation to the camera
    void Start()
    {
        enemy1Spawner = GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>();
        cameraPosition = Camera.main.transform.position;
        cameraSpeed = Camera.main.GetComponent<CameraMovement>().cameraSpeed;
        enemySpeedDownScale = Mathf.Clamp(enemySpeedDownScale, 0f, 1f); // Making sure it's in [0f, 1f]
        enemySpeed = cameraSpeed * enemySpeedDownScale; //Setting enemy speed
    }

    void Update()
    {
        cameraPosition = Camera.main.transform.position;
        if(transform.position.y < cameraPosition.y - 7f){
            Destroy(gameObject);
            enemy1Spawner.waveEnemyCount--;
        }

        // can probably change how it goes down, maybe some randomization or wobbly movement
        transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * enemySpeed;
    }
}
