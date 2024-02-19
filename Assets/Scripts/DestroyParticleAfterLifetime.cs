using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleAfterLifetime : MonoBehaviour
{
    [SerializeField] private float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
