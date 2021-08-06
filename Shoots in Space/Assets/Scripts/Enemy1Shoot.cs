using UnityEngine;

public class Enemy1Shoot : MonoBehaviour
{
    [SerializeField] private GameObject enemy1shot;
    private Vector2 screenBoundariesInWorldSpace;
    private const float TIME_BETWEEN_SHOTS = 2.75f;
    private float nextTimeToShoot = 0f;

    void Start()
    {
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
    }

    void Update()
    {
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
        
        if(transform.position.x <= screenBoundariesInWorldSpace.x &&
           transform.position.x >= -screenBoundariesInWorldSpace.x &&
           transform.position.y <= screenBoundariesInWorldSpace.y &&
           transform.position.y >= -screenBoundariesInWorldSpace.y){

            if(Time.time >= nextTimeToShoot){
                FindObjectOfType<AudioManager>().PlaySound("EnemyShot");
                Vector3 shotPosition = transform.position + new Vector3(0f, -0.35f, 0f);
                Instantiate(enemy1shot, shotPosition, Quaternion.identity);
                nextTimeToShoot = Time.time + TIME_BETWEEN_SHOTS;
            }
        }
    }
}
