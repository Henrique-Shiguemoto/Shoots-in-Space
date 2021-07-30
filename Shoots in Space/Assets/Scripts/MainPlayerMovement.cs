using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    public float spaceShipSpeedX;
    private float horizontalMove;
    private Vector2 screenBoundariesInWorldSpace;

    void Start()
    {
        //Getting the boundaries of the screen in world space
        screenBoundariesInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log(screenBoundariesInWorldSpace);
    }
    void Update()
    {
        //horizontalMove is equal to -1 we're going to the left, 0 if we're still and 
        //+1 if we're going to the right
        horizontalMove = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(horizontalMove, 0f, 0f) * Time.deltaTime * spaceShipSpeedX;

        //Clamping the space ship's x position to fit in the screen boundaries
        Vector3 clampedSpaceShipPosition = transform.position;
        clampedSpaceShipPosition.x = Mathf.Clamp(clampedSpaceShipPosition.x, 
                                                -screenBoundariesInWorldSpace.x + transform.localScale.x/2, 
                                                screenBoundariesInWorldSpace.x - transform.localScale.x/2); 
        transform.position = clampedSpaceShipPosition;
    }
}
