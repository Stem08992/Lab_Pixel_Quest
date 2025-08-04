using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHQPlayerPickup : MonoBehaviour
{
    public float pickupRange = 3f;
    public Transform holdPoint;
    public KeyCode pickupKey = KeyCode.E;

    private GameObject heldObject;
    private Rigidbody heldRB;
    public bool facingLeft;
    private float facingMultiplier;

    void Update()
    {
        if (facingLeft)
        {
            facingMultiplier = -1f;
        }
        else { facingMultiplier = 1f; }
        if (Input.GetKeyDown(pickupKey))
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            MoveObject();
        }
    }

    void TryPickupObject()
    {
        RaycastHit2D hit;
        if (Physics2D.Raycast(transform.position,(Vector2) transform.position + (Vector2.right * facingMultiplier), out hit, pickupRange,))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldRB = heldObject.GetComponent<Rigidbody>();

                if (heldRB != null)
                {
                    heldRB.useGravity = false;
                    heldRB.freezeRotation = true;
                    heldRB.velocity = Vector3.zero;
                    heldRB.angularVelocity = Vector3.zero;
                }
            }
        }
    }

    void MoveObject()
    {
        Vector3 directionToPoint = holdPoint.position - heldObject.transform.position;
        float moveSpeed = 10f;

        if (heldRB != null)
        {
            heldRB.velocity = directionToPoint * moveSpeed;
        }
    }

    void DropObject()
    {
        if (heldRB != null)
        {
            heldRB.useGravity = true;
            heldRB.freezeRotation = false;
        }

        heldObject = null;
        heldRB = null;
    }
}