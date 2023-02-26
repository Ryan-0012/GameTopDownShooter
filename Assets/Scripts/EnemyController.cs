using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private bool isDead = false;
    

    public HealthBar healthBar;
    public DeleteShootFabs deleteShootFabs;



    public int maxHealth = 5;
    public int currentHealth;



    public Sprite[] deteriorationSprites;
    public int maxHits = 4;
    private int currentHits = 0;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject explosionShip;

    
    Transform player;
    public NavMeshAgent enemy;
    private Rigidbody2D rb;

    private float currentSpeed = 0;
    [SerializeField] private float valueDrag = 1;
    [SerializeField] [Range(0, 1)] private float maxDrift = 0.7f;
    [SerializeField] private float maxSpeed = 7; 
    [SerializeField] private float acceleration = 3;
    [SerializeField] private float moveSpeed;

     
 
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemy.updateRotation = false;
        enemy.updateUpAxis = false;

        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


        Quaternion currentRotation = transform.rotation;

        // Criar uma nova rotação que mantenha o valor atual do eixo Z e defina os valores dos eixos X e Y como zero
        Quaternion newRotation = Quaternion.Euler(0f, 0f, currentRotation.eulerAngles.z);

        // Definir a nova rotação para o objeto
        transform.rotation = newRotation;

        if(healthBar == null){
            Destroy(gameObject);
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deteriorationSprites[0];

    }

    void FixedUpdate() {
        Speed();
        Rotation();
        Drift();
    }

    void Speed () {
        
        if (Vector3.Distance(transform.position, player.position) < 8f) {
        enemy.speed = 0f;
        } else {
            enemy.SetDestination(player.position);
            enemy.speed = 5.0f;
        }
    }

    void Rotation() {
        var direction = (player.position - transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);
    } 

    void Drift() {
        Vector2 speedUp = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 speedRight = transform.right * Vector2.Dot(rb.velocity, transform.right);
        rb.velocity = speedUp + speedRight * maxDrift;
    }

    
    public void TakeDamage()
    {
        if(enemy != null){
            if(currentHealth <= 0){
                Die();
            }

            currentHealth -= 1;
            

                if(gameObject != null){
                        healthBar.SetHealth(currentHealth);
                    }
            }
    }

    
    

    public void Die()
    {
        if (!isDead)
        {
            CountDown.StoragePoints();
            Instantiate(explosionShip, transform.position, transform.rotation);
            deleteShootFabs.DeleteShooter();
            isDead = true;
        }
    }

     void UpdateDeterioration()
    {
        if (currentHits >= 4)
        {
            spriteRenderer.sprite = deteriorationSprites[2]; // Define a imagem mais deteriorada
        }
        else if (currentHits == 2 || currentHits == 3)
        {
            spriteRenderer.sprite = deteriorationSprites[1]; // Define a imagem de deterioração média
        }
        else
        {
            spriteRenderer.sprite = deteriorationSprites[0]; // Define a imagem inicial do barco
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!isDead)
            {
                if (collision.gameObject.tag == "BulletPlayer")
                {
                    
                    currentHits++; // Aumenta o contador de tiros recebidos
                    UpdateDeterioration();
                }
            }
        
        
    }

    
}
