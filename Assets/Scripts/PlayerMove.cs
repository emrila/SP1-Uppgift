using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float jumpHeight = 300f;

    [SerializeField] private Transform leftFoot, rightFoot;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillColor;
    [SerializeField] private TMP_Text appleText;

    [SerializeField] AudioClip jumpSound, pickUpSound;

    private float horizontalValue;
    private float rayDistance = 0.25f;

    private Rigidbody2D playerBody;
    private SpriteRenderer rend;
    private Animator anim;
    private AudioSource playerSounds;

    private bool canMove;

    private int startingHealth = 5;
    private int currentHealth;
    public int appleCounter;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerSounds = GetComponent<AudioSource>();

        canMove = true;
        currentHealth = startingHealth;
    }

    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        CheckSpriteDirection();

        anim.SetFloat("PlayerSpeed", Mathf.Abs(playerBody.velocity.x));

        if (Input.GetButtonDown("Jump") && CheckIfGrounded())
        {
            Jump();
        }


    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }

        playerBody.velocity = new Vector2(horizontalValue * movementSpeed, playerBody.velocity.y);

    }

    private void CheckSpriteDirection()
    {
        if (horizontalValue < 0)
        {
            FlipSprite(true);
        }
        if (horizontalValue > 0)
        {
            FlipSprite(false);
        }

    }
    private void FlipSprite(bool direction)
    {
        rend.flipX = direction;
    }

    private void Jump()
    {
        playerBody.AddForce(new Vector2(0, jumpHeight));

        playerSounds.PlayOneShot(jumpSound, 0.2f);

    }
    private bool CheckIfGrounded()
    {
        RaycastHit2D leftHit = CreateRaycastHit(leftFoot);
        RaycastHit2D rightHit = CreateRaycastHit(rightFoot);

        if (IsFootOnGround(leftHit) || IsFootOnGround(rightHit))
        {
            return true; 
        }

        return false;
       
    }
    private bool IsFootOnGround(RaycastHit2D hit)
    {
        return hit.collider!= null && hit.collider.CompareTag("Ground");

    }
    private RaycastHit2D CreateRaycastHit(Transform foot)
    {
        return Physics2D.Raycast(foot.position, Vector2.down, rayDistance, whatIsGround);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthSlider();
        if (currentHealth <= 0)
        {
            Respawn();
        }

    }
    public void TakeKnockback(float knockbackForce, float upwards)
    {
        canMove = false;

        playerBody.AddForce(new Vector2(knockbackForce, upwards));

        Invoke("CanMoveAgain", 0.25f);

    }
    private void CanMoveAgain()
    {
        canMove = true;
    }
    private void Respawn()
    {
        currentHealth = startingHealth;

        UpdateHealthSlider();

        transform.position = spawnPoint.position;
        playerBody.velocity = Vector2.zero;
    }
    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
        if (currentHealth >= 4)
        {
            fillColor.color = Color.green;
        }
        else if (currentHealth >= 2) {

            fillColor.color = Color.yellow;
        }
      
        else
        {
            fillColor.color = Color.red;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            playerSounds.PlayOneShot(pickUpSound, 0.2f);

            appleCounter++;
            appleText.text = "" + appleCounter;
        }

        if (other.CompareTag("Pineapple"))
        {

            if (currentHealth == startingHealth)
            {
                return;
            }

            Destroy(other.gameObject);
            playerSounds.PlayOneShot(pickUpSound, 0.2f);
            currentHealth++;
            UpdateHealthSlider();
        }
        
    }


}
