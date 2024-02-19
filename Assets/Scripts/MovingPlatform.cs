using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform target1, target2;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private bool shouldMove = true;

    private Transform currentTarget;


    void Start()
    {
        currentTarget = target1;
    }
    private void FixedUpdate()
    {
       if (shouldMove)
        {
            MoveTowardsTarget();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.position.y > transform.position.y && IsPlayerOrMob(other))
        {
            other.transform.SetParent(transform);
        }
       
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (IsPlayerOrMob(other))
        {
            try
            {
                other.transform.SetParent(null);
            }
            catch (Exception) {
            };
        }
    }

    private void MoveTowardsTarget()
    {

        if (transform.position == target1.position)
        {

            currentTarget = target2;
        }

        if (transform.position == target2.position)
        {

            currentTarget = target1;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
    }

    public void ShouldMove(bool move)
    {
        shouldMove = move;

    }

    private bool IsPlayerOrMob(Collision2D other)
    {
        return other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Mob");
    }
    

}
