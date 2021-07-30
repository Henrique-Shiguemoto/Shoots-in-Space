using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 cameraPosition;
    private float cameraSpeed;
    private float enemySpeed;

    //Value in (0f, 1f)
    public float enemySpeedDownScale;
    void Start()
    {
        cameraPosition = Camera.main.transform.position;
        cameraSpeed = Camera.main.GetComponent<CameraMovement>().cameraSpeed;
        enemySpeed = cameraSpeed * enemySpeedDownScale;
    }

    void Update()
    {
        transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * enemySpeed;
    }
}
