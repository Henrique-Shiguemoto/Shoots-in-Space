using UnityEngine;

public class EnemyShotMovement : MonoBehaviour
{
    [SerializeField] private float shotSpeedMultiplier;
    private Vector2 screenBoundariesInWorldSpace;
    private float shotSpeed;
    private Vector3 cameraPosition;

    void Start()
    {
        shotSpeedMultiplier = Mathf.Clamp(shotSpeedMultiplier, 0f, 1f);
        shotSpeed = Camera.main.GetComponent<CameraMovement>().cameraSpeed * shotSpeedMultiplier;
        cameraPosition = Camera.main.transform.position;
    }
    
    void Update()
    {
        cameraPosition = Camera.main.transform.position;
        
        transform.position -= new Vector3(0f, -1f, 0f) * Time.deltaTime * shotSpeed;

        //If the enemy shot gets out of the limits of the camera, it gets destroyed 
        if(transform.position.y < cameraPosition.y - 7f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //If the enemy shot hits the player, it gets destroyed
        if(collider.gameObject.CompareTag("MainPlayer")){
            Destroy(gameObject);
        }
    }
}
