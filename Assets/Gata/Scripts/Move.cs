using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{

    // world va;ies
    private Camera _camera;    //Camera Game Object 
    private Vector3 _mousePos; //Current Mouse Position  
    //move specifics
    private Rigidbody2D _rigidbody2D;
    //private
    private GameObject _hitbox; //interaction implemented in charachter class
    private GameObject _sprite; // visual
    public float _cooldown;
    public float _moveSpeed;
    public float bulletLife;
    public int damage;
    public KeyCode _key;
    // determines if move can hit(if its owned by entity)
    // canshoot
    private Vector3 target;
    private bool canShoot = true;
    private float _currentTime;
    public bool player;

    public void setCooldown(float cooldown)
    {
        this._cooldown = cooldown;
    }
   
    public void setTarget(Vector3 target)
    {
        print(target + "target input");
        this.target = target;
    }

    public Vector3 getTarget()
    {
        return target;
    }

    public bool getShoot()
    {
        return canShoot;
    }
    public float getTime()
    {
        return _currentTime;
    }
    public void setShoot( bool b)
    {
        canShoot = b;
    }

    public void setTime(bool a)
    {
        if (a)
        {
            _currentTime -= Time.deltaTime;
        } else
        {
            _currentTime = _cooldown;
        }
    }


    public Move(GameObject move, float cooldown, float manaCost, float moveSpeed, float bulletLife, Boolean owned) {
        this._hitbox =  move.transform.GetChild(0).gameObject;
        this._sprite = move.transform.GetChild(1).gameObject;
        this._cooldown = cooldown;
        this._moveSpeed = moveSpeed;
        this.bulletLife = bulletLife;
    }


    // Start is called before the first frame update
    void Start()
    {
        _currentTime = _cooldown;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        PlayerBullet();
        StartCoroutine(Death());

    }


    // Update is called once per frame
    void Update()
    {

    }

    private void PlayerBullet()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (player)
        {
            RotationUpdate(_mousePos);
        } else
        {
            print(getTarget() + "this target");
            BossRotation(this.target);
        }
    }

    private void RotationUpdate(Vector3 pos1)
    {
        var pos2 = transform.position;
        var dir = pos1 - pos2;
        var rotation = pos2 - pos1;
        _rigidbody2D.velocity = new Vector2(dir.x, dir.y).normalized * _moveSpeed;
        var rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void BossRotation(Vector3 pos1)
    {
        var pos2 = transform.position;
        var dir = pos1 - pos2;
        //print(dir);
        var rotation = pos2 - pos1;
        _rigidbody2D.velocity = new Vector2(dir.x, dir.y).normalized * _moveSpeed;
        var rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot+90);
    }



    private IEnumerator Death()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }

}
