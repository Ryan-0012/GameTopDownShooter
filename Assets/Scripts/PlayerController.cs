using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CountDown countDown;
    public int pointPlayer = 0;

    [SerializeField] private string menu;


    public HealthBar healthBar;
    public int maxHealth = 10;
    public int currentHealth;



    private Rigidbody2D rb;
    private Vector2 movement;

    private float rotation = 0;
    private float rotationSpeed = 2;


    public Sprite[] deteriorationSprites;
    public int maxHits = 4;
    private int currentHits = 0;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject explosionShip;



    [SerializeField] private float moveSpeed;
    [SerializeField] private float valueDrag = 1;
    [SerializeField] [Range(0, 1)] private float maxDrift = 0.7f;
    [SerializeField] private float maxSpeed = 7; 
    


    void Start () {
        rb = GetComponent<Rigidbody2D>();


        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        


        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deteriorationSprites[0];
    }

    void Update () {
        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() {
        Speed();
        Rotation();
        Drift();
    }

    void Speed () {
        if (Input.GetKey(KeyCode.W)){
            rb.drag = 0;
        }
        if (!Input.GetKey(KeyCode.W)){
            rb.drag = Mathf.Lerp(rb.drag, valueDrag, Time.fixedDeltaTime);
        }

        var speedUp = Vector2.Dot(transform.up, rb.velocity);

        if (speedUp > maxSpeed) return;
        if (speedUp < (-maxSpeed * 0.5)) return;

        rb.AddForce(transform.up * movement.y * moveSpeed, ForceMode2D.Force);
    }

    void Rotation() {
        rotation = rotation - (movement.x * rotationSpeed);
        rb.MoveRotation(rotation);
    } 

    void Drift() {
        Vector2 speedUp = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 speedRight = transform.right * Vector2.Dot(rb.velocity, transform.right);
        rb.velocity = speedUp + speedRight * maxDrift;
    }


    public void TakeDamage()
    {


       
        
            if(currentHealth <= 0){
                Die();
            }

            currentHealth -= 1;
            

                if(gameObject != null){
                        healthBar.SetHealth(currentHealth);
                }
            
    }
    public void TakeDamageChaser()
    {
        

        
        
            if(currentHealth <= 0){
                Die();
            }

            currentHealth -= 5;
            

                if(gameObject != null){
                        healthBar.SetHealth(currentHealth);
                }
            
    }

    public void Die(){
        
        Instantiate(explosionShip, transform.position, transform.rotation);
        pointPlayer = CountDown.points;
        PlayerPrefs.SetInt("PointsMenu", pointPlayer);
        SceneManager.LoadScene(menu);

    }

    void UpdateDeterioration()
    {
        if (currentHits >= 8)
        {
            spriteRenderer.sprite = deteriorationSprites[2]; // Define a imagem mais deteriorada
        }
        else if (currentHits >= 4 || currentHits <= 7)
        {
            spriteRenderer.sprite = deteriorationSprites[1]; // Define a imagem de deterioração média
        }
        else
        {
            spriteRenderer.sprite = deteriorationSprites[0]; // Define a imagem inicial do barco
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            
            currentHits++; // Aumenta o contador de tiros recebidos
            UpdateDeterioration();
        }
        if (collision.gameObject.tag == "Chaser")
        {
            
            currentHits = currentHealth+5;; // Aumenta o contador de tiros recebidos
            UpdateDeterioration();
        }
        
        
    }
}

