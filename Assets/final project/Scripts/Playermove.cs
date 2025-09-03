using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer _spriteRenderer;

    public int speed = 9;

    [Header("Dash Settings")]
    public float dashForce = 50f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 15f;
    private float currentDashTime = 0f;
    private float currentCooldown = 0f;
    private bool canDash = true;
    private bool isDashing = false;

    [Header("Slide Settings")]
    public float slideSpeed = 10f;
    public float slideDuration = 0.3f;
    private bool isSliding = false;
    private float slideTimer = 0f;

    private PlayerUIController uiController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        uiController = GetComponent<PlayerUIController>();
        uiController.StartUI();
        uiController.UpdateDashCooldown(0); // show ready
    }

    void Update()
    {
        HandleDashCooldown();
        HandleInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.X) && canDash && !isSliding)
        {
            StartDash();
        }

        if (Input.GetKey(KeyCode.S) && !isSliding && !isDashing)
        {
            StartSlide();
        }

        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0)
            {
                EndSlide();
            }
        }

        if (isDashing)
        {
            currentDashTime -= Time.deltaTime;
            if (currentDashTime <= 0)
            {
                EndDash();
            }
        }
    }

    void HandleMovement()
    {
        if (isSliding || isDashing) return;

        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (xInput < 0)
            _spriteRenderer.flipX = true;
        else if (xInput > 0)
            _spriteRenderer.flipX = false;
    }

    void StartDash()
    {
        isDashing = true;
        canDash = false;
        currentDashTime = dashDuration;
        currentCooldown = dashCooldown;

        float direction = _spriteRenderer.flipX ? -1f : 1f;
        rb.velocity = new Vector2(direction * dashForce, 0);
    }

    void EndDash()
    {
        isDashing = false;
    }

    void HandleDashCooldown()
    {
        if (!canDash)
        {
            currentCooldown -= Time.deltaTime;
            uiController.UpdateDashCooldown(currentCooldown);

            if (currentCooldown <= 0)
            {
                canDash = true;
                currentCooldown = 0;
                uiController.UpdateDashCooldown(0);
            }
        }
    }

    void StartSlide()
    {
        isSliding = true;
        slideTimer = slideDuration;

        float direction = _spriteRenderer.flipX ? -1f : 1f;
        rb.velocity = new Vector2(direction * slideSpeed, rb.velocity.y);
    }

    void EndSlide()
    {
        isSliding = false;
    }
}
