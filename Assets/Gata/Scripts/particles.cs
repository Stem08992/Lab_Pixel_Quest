using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    [SerializeField] ParticleSystem movementparticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;
            
    [SerializeField] Rigidbody2D rb;

    float dustTimer;

    // Update is called once per frame
    void Update()
    {
        dustTimer += Time.deltaTime;
        
        if (rb.velocity.magnitude > occurAfterVelocity && dustTimer >= dustFormationPeriod)
        {
            movementparticle.Play();
            dustTimer = 0;
        }
    }
}
