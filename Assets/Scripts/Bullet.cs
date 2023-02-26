using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Cannon cannon;
    
    [SerializeField] float speed;
     
    [SerializeField] float desaceleracion;
    public int points = 0;
    
    void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.right * speed, ForceMode2D.Impulse);   
    }
    void Update() {
        
    }
    
    void FixedUpdate()
    {
        // Aplica uma força contrária a direção atual para desacelerar o tiro com o tempo
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(-rigidBody.velocity.normalized * desaceleracion, ForceMode2D.Force);
        if (rigidBody.velocity.magnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("EnemyChaser"))
        {
            
            collision.gameObject.GetComponent<EnemyChaserController>().TakeDamage();
            
        }
        if(collision.gameObject.CompareTag("EnemyShooter"))
        {
            
            collision.gameObject.GetComponent<EnemyController>().TakeDamage();
        }
        Destroy(gameObject);
    }
}
