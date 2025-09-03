using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");

        _rigidbody2D.velocity = new Vector2(xMovement * speed, _rigidbody2D.velocity.y);

       
    }

    public void UpgradeTrain(int additionalSpeed, Sprite sprite)
    {
        speed += additionalSpeed;
        _spriteRenderer.sprite = sprite;
        Debug.Log("UpgradeTrain: Setting sprite to " + sprite?.name);
    }

    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }
}
