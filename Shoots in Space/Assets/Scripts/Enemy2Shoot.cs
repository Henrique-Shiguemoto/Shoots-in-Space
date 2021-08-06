using UnityEngine;

public class Enemy2Shoot : MonoBehaviour
{
    [SerializeField] private GameObject enemy2Shot;
    private const float TIME_BETWEEN_SHOTS = 1.75f;
    private Vector2 screenBoundariesInWorldSpace;
    private float nextTimeToShoot = 0f;

    void Update()
    {
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if(transform.position.y <= screenBoundariesInWorldSpace.y &&
           transform.position.y >= -screenBoundariesInWorldSpace.y){
               if(Time.time >= nextTimeToShoot){
                   FindObjectOfType<AudioManager>().PlaySound("EnemyShot");
                   Vector3 shotPosition = transform.position + new Vector3(0f, -0.1f, 0f);
                   Instantiate(enemy2Shot, shotPosition, Quaternion.identity);
                   nextTimeToShoot = Time.time + TIME_BETWEEN_SHOTS;
               }
        }
    }
}
