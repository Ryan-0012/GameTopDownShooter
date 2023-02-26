using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        Shoot();
        
    }

    void Shoot() {
        if (Input.GetButtonDown("Fire1")) 
        {
            Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);

        }
    }
}
