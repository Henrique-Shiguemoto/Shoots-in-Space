using UnityEngine;

public class MainPlayerShoot : MonoBehaviour
{
    public GameObject spaceShipShot;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Instantiate(spaceShipShot, transform.position, Quaternion.identity);
        }
    }
}
