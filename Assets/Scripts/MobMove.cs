using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMove : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float bounciness = 100f;
    [SerializeField] private float knockbackForce = 400f;
    [SerializeField] private float upwardForce = 100f;
    [SerializeField] private int damageGiven = 1;

    private SpriteRenderer rend;
    private Animator anim;
<<<<<<< Updated upstream
   // private bool isGrounded = true;

=======
    private AudioSource mobAudio;
>>>>>>> Stashed changes


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckSpriteDirection();

        anim.SetFloat("MovementSpeed", Mathf.Abs(movementSpeed));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MobBlock") || other.gameObject.CompareTag("Mob"))
        {
            movementSpeed = -movementSpeed;
        }
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerMove>().TakeDamage(damageGiven);

            if (other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<PlayerMove>().TakeKnockback(knockbackForce, upwardForce);

            }
            else
            {
                other.gameObject.GetComponent<PlayerMove>().TakeKnockback(-knockbackForce, upwardForce);
            }



        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(movementSpeed, 0) * Time.deltaTime);
    }

    private void CheckSpriteDirection()
    {
        if (movementSpeed < 0)
        {
            FlipSprite(true);
        }
        if (movementSpeed > 0)
        {
            FlipSprite(false);
        }

    }

    private void FlipSprite(bool direction)
    {
        rend.flipX = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerBody = other.GetComponent<Rigidbody2D>();
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
<<<<<<< Updated upstream
            playerBody.AddForce(new Vector2(0, bounciness));
=======
            playerBody.AddForce(new Vector2(0, bounciness*4));

            mobAudio.PlayOneShot(mobKillSound, 0.2f);
            Destroy(GetComponent<CapsuleCollider2D>());

            movementSpeed = 0;
            rend.flipY = true;

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness*2));
            Instantiate(mobKillParticle, transform.position, Quaternion.identity);
            Instantiate(mobDrop, transform.position, Quaternion.identity);
           
            Destroy(gameObject, 0.25f);
>>>>>>> Stashed changes

            Destroy(gameObject);
        }
    }
}
