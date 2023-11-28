using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControls : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask wall;
   // public Collider triggerCollider;
    private Rigidbody rb;
    private bool isGrounded = false;
    private bool isFacingFowards = true;
    private float FlipCooldown = 0;
    private bool HasFliped;
    public int EnemyHealth;
    private Slider EnemyHealthBar;
    public GameObject HealingOrb;
    private Transform WhereDied;
    public float Distance;
    public float KnockBackDistance;
    public int EnemyDamage;
    private Person2 PlayerScript;
    // private Vector3 MoveDirection;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerScript = GameObject.FindWithTag("Player").GetComponent<Person2>();
       // EnemyHealthBar = gameObject.GetComponentInChildren<Slider>();
       // EnemyHealthBar.maxValue = EnemyHealth;
       // EnemyHealthBar.value = EnemyHealth;
    }
    private void FixedUpdate()
    {
    }
    private void Update()
    {
        // Check if the enemy is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, Distance, groundLayer);
        // Move the enemy horizontally
        Move();

        // Check if the enemy should jump
        if (isGrounded)
        {
            Jump();
        }
        if (EnemyHealth <= 0) 
        {
            EnemyDeath();
        }
    }
    public void DamageEnemy(int DamageAmount)
    {
        EnemyHealth = EnemyHealth - DamageAmount;
        EnemyHealthBar.value = EnemyHealth;
    }
    private void Move()
    {
        float horizontalInput = isFacingFowards ? 1f : -1f;
        Vector3 movement = new Vector3(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
        Debug.Log("EnemyShouldBeMoving");
        // Flip the enemy sprite based on direction
        if ((horizontalInput > 0 && !isFacingFowards) || (horizontalInput < 0 && isFacingFowards))
        {
            Flip();
        }
    }
    private void Jump()
    {
        // Add vertical force to make the enemy jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Flip()
    {
        // Flip the enemy's facing direction
        if (FlipCooldown == 0 )
        {
            isFacingFowards = !isFacingFowards;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            FlipCooldown = 1;
            Invoke("ResetFlip", 0.3f);
        }
    }
    private void ResetFlip()
    {
        FlipCooldown = 0;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Weapon"))
        {
            DamageEnemy(PlayerScript.SwordDamage);
            Debug.Log("EnemyHasTakenDamage");
        }
    }
    public void EnemyDeath()
    {
        WhereDied = gameObject.transform;
        Instantiate(HealingOrb, WhereDied.position, Quaternion.identity);
        GameObject.Destroy(gameObject);
        Debug.Log("HasDroppedOrb");
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Handle collision with the player or other objects
        if (collision.gameObject.CompareTag("Player"))
        {
            // Implement your combat logic here (e.g., reducing player's health)
            // You may want to use events or other mechanisms to communicate with the player script.
        }
        if (collision.gameObject.tag == ("Wall"))
        {
            Flip();
        }
    }
}