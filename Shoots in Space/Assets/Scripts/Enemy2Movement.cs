using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    [SerializeField] private float ySpeedMultiplier;
    private Vector3 cameraPosition;
    private float ySpeed;
    private Enemy2Spawner enemy2Spawner;

    void Start()
    {
        enemy2Spawner = GameObject.Find("EnemySpawner").GetComponent<Enemy2Spawner>();
        ySpeedMultiplier = Mathf.Clamp(ySpeedMultiplier, 0f, 1f);
        ySpeed = Camera.main.GetComponent<CameraMovement>().cameraSpeed * ySpeedMultiplier;
    }

    void Update()
    {
        transform.position -= Vector3.down * Time.deltaTime * ySpeed;
        
        cameraPosition = Camera.main.transform.position;
        if(transform.position.y < cameraPosition.y - 7f){
            Destroy(gameObject);
            enemy2Spawner.waveEnemyCount--;
        }   
    }
}
