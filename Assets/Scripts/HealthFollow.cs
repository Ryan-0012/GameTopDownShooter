using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Update() {

        if(target != null){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else{
            Destroy(gameObject);
        }
    }
}
