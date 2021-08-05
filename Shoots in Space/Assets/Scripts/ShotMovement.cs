using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    [SerializeField] private float shotSpeedY;
    private Vector3 cameraPosition;

    void Start()
    {
        cameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        cameraPosition = Camera.main.transform.position;

        transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * shotSpeedY;

        if(transform.position.y > cameraPosition.y + 7f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy")){
            //Destroy shot if it hits an enemy
            Destroy(gameObject);
        }
    }
}
