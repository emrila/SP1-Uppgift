using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeGround : MonoBehaviour
{
    [SerializeField] GameObject targetGround;
    [SerializeField] GameObject targetPlatform
        ;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetGround.GetComponent<Animator>().SetBool("isVisible", false);
            Invoke(nameof(ActivatePlatform), 0.5f);
        }
    }


    private void ActivatePlatform()
    {
        targetPlatform.GetComponent<MovingPlatform>().ShouldMove(true);
    }

}
