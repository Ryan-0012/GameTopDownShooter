using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class CannonEnemy : MonoBehaviour
{
    public GameObject bullet;

    Transform player;
    public float shootDistance = 15.0f;
    public Transform spawnBullet;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if(timer > 1 && Vector2.Distance(transform.position, player.position) <= shootDistance)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
            Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
    }
}
