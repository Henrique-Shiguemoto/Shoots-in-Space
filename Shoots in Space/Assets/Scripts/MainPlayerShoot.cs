using UnityEngine;

public class MainPlayerShoot : MonoBehaviour
{
    //Public variables
    public GameObject spaceShipShot;

    //Private variables
    private const float TIME_BETWEEN_SHOTS = 0.12f;
    private float nextShotTime = 0f;
    
    void Update()
    {
        //shots have cooldown, the player can only shoot if TIME_BETWEEN_SHOTS have passed after the last shot
        if(Time.time > nextShotTime){
            if(Input.GetButton("Fire1")){
                Instantiate(spaceShipShot, transform.position, Quaternion.identity);
                nextShotTime = Time.time + TIME_BETWEEN_SHOTS;
            }
        }
    }
}
