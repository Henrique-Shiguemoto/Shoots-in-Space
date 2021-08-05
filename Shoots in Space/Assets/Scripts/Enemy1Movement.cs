using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    //Private variables
    private Vector3 cameraPosition;
    private float cameraSpeed;
    private float enemySpeed;
    private Enemy1Spawner enemy1Spawner;
    private float xPosition;
    private float a; //Don't know how to call the variable

    //Public variables
    public float enemySpeedDownScale; //Will reduce enemy speed in relation to the camera
    void Start()
    {
        a = Random.Range(-1f, 1f);
        enemy1Spawner = GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>();
        cameraPosition = Camera.main.transform.position;
        cameraSpeed = Camera.main.GetComponent<CameraMovement>().cameraSpeed;
        enemySpeedDownScale = Mathf.Clamp(enemySpeedDownScale, 0f, 1f); // Making sure it's in [0f, 1f]
        enemySpeed = cameraSpeed * enemySpeedDownScale; //Setting enemy speed
    }

    void Update()
    {
        xPosition = Mathf.Sin(a);
        transform.position += new Vector3(xPosition, 1f, 0f) * Time.deltaTime * enemySpeed;
        a += 0.04f;

        cameraPosition = Camera.main.transform.position;
        if(transform.position.y < cameraPosition.y - 7f){
            Destroy(gameObject);
            enemy1Spawner.waveEnemyCount--;
        }
    }
}
