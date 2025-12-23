using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject slashObject;
    public float attackDuration = 0.15f;

    private Vector2 lastDirection = Vector2.down;

    void Update()
    {
        UpdateDirection();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void UpdateDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
            lastDirection = new Vector2(x, y);
    }

    void Attack()
    {
        slashObject.SetActive(true);

        Animator slashAnimator = slashObject.GetComponent<Animator>();

        if (lastDirection.y > 0)
            slashAnimator.Play("Slash_Up");
        else if (lastDirection.y < 0)
            slashAnimator.Play("Slash_Down");
        else if (lastDirection.x < 0)
            slashAnimator.Play("Slash_Left");
        else if (lastDirection.x > 0)
            slashAnimator.Play("Slash_Right");

        Invoke(nameof(EndAttack), attackDuration);
    }

    void EndAttack()
    {
        slashObject.SetActive(false);
    }
}

