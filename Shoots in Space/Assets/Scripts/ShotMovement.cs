using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public float shotSpeedY;
    private Vector2 screenBoundariesInWorldSpace;
    void Start()
    {
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * shotSpeedY;

        if(transform.position.y > screenBoundariesInWorldSpace.y){
            Destroy(gameObject);
        }
    }
}
