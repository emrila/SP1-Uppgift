using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private Transform leftFoot, rightFoot;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private LayerMask whatIsGround;

<<<<<<< Updated upstream
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillColor;
    [SerializeField] private TMP_Text appleText;
=======
    [SerializeField] private GameObject cherryParticle, pineappeParticles, melonParticle, jumpParticles;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillColor;
    [SerializeField] private TMP_Text questText;
>>>>>>> Stashed changes

    [SerializeField] AudioClip jumpSound, cherrySound, melonSound, pineappleSound, badCherrySound;

    private float horizontalValue;
<<<<<<< Updated upstream
    private float rayDistance = 0.25f;
=======
    private float rayDistance;
    
>>>>>>> Stashed changes

    private Rigidbody2D playerBody;
    private SpriteRenderer rend;
    private Animator anim;
    private AudioSource playerSounds;

    private bool canMove;
<<<<<<< Updated upstream

    private int startingHealth = 5;
    private int currentHealth;
    public int appleCounter;
=======
    private bool hasPowerUp = false;

    private int startingHealth = 5;
    private int currentHealth;
    public int cherryCounter;
    private int powerUpCountdown = 500;
    private int powerUpTimeRemaining;

>>>>>>> Stashed changes

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerSounds = GetComponent<AudioSource>();

        canMove = true;
        currentHealth = startingHealth;
<<<<<<< Updated upstream
=======
        playerSounds.volume = 0.2f;
        rayDistance = 0.25f;

        currentHealth = PlayerDataContainer.GetPlayerHealth();
        UpdateHealthSlider();

        transform.position = spawnPoint.position;
       
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        playerBody.velocity = new Vector2(horizontalValue * movementSpeed, playerBody.velocity.y);

=======
        if (powerUpTimeRemaining > 0 && hasPowerUp)
        {
            powerUpTimeRemaining--;

        }
        if (powerUpTimeRemaining == 0 && hasPowerUp)
        {
            RemovePowerUp();
        }
>>>>>>> Stashed changes
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

        Invoke(nameof(CanMoveAgain), 0.25f);

    }
    private void CanMoveAgain()
    {
        canMove = true;
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    private void Respawn()
    {
        currentHealth = startingHealth;

        UpdateHealthSlider();
        RemovePowerUp();
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

<<<<<<< Updated upstream
=======
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 playerPosition = new(transform.position.x, transform.position.y, transform.position.z+1);

            Instantiate(jumpParticles, playerPosition, Quaternion.identity);

        }
    }

>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
<<<<<<< Updated upstream
            playerSounds.PlayOneShot(pickUpSound, 0.2f);
=======
            Instantiate(cherryParticle, other.transform.position, Quaternion.identity);
            playerSounds.PlayOneShot(cherrySound, 0.2f);
>>>>>>> Stashed changes

            cherryCounter++;
            questText.text = "" + cherryCounter;
        }

<<<<<<< Updated upstream
=======
        if (other.CompareTag("BadCherry"))
        {
            Destroy(other.gameObject);
            Instantiate(jumpParticles, other.transform.position, Quaternion.identity);
            TakeDamage(1);
            RemovePowerUp();
            
            playerSounds.PlayOneShot(badCherrySound, 0.2f);
        }

        if (other.CompareTag("Melon"))
        {

            Destroy(other.gameObject);
            Instantiate(melonParticle, other.transform.position, Quaternion.identity);
            GivePowerUp();

            playerSounds.PlayOneShot(melonSound, 0.2f);
           
        }

>>>>>>> Stashed changes
        if (other.CompareTag("Pineapple"))
        {

            if (currentHealth < startingHealth)
            {
<<<<<<< Updated upstream
                return;
            }

            Destroy(other.gameObject);
            playerSounds.PlayOneShot(pickUpSound, 0.2f);
            currentHealth++;
            UpdateHealthSlider();
        }
        
    }

=======
                Destroy(other.gameObject);
                Instantiate(pineappeParticles, other.transform.position, Quaternion.identity);

                currentHealth++;
                UpdateHealthSlider();

                playerSounds.PlayOneShot(pineappleSound, 0.2f);

            }


        }
        
    }
  
    private void GivePowerUp()
    {
        if(powerUpCountdown != 0) {

            RemovePowerUp();
        }
        powerUpTimeRemaining = powerUpCountdown;
        movementSpeed *= 2f;
        hasPowerUp = true;
    }

    private void RemovePowerUp()
    {
        if (hasPowerUp) {
            powerUpTimeRemaining = 0;
            movementSpeed *= 0.5f;
            hasPowerUp = false;
        }
        
    }

    public void UpdatePlayerStats()
    {
        PlayerDataContainer.SetPlayerHealth(currentHealth);
        PlayerDataContainer.SetPowerUp(hasPowerUp);
    }
>>>>>>> Stashed changes

}
