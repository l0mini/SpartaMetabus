using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    GameManagerinFlappy gameManagerinFlappy = null;

    public float jumpForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isJump = false;

    public bool godMode = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody2D>();
        gameManagerinFlappy = GameManagerinFlappy.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if(deathCooldown <= 0f)
            { 
                GameManagerinFlappy.Instance.GameOver();
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if(isDead)
            return;

        Vector3 velocity = rb.velocity;
        velocity.x = forwardSpeed;
        
        if(isJump)
        {
            velocity.y += jumpForce;
            isJump = false;
        }

        rb.velocity = velocity;

        float angle = Mathf.Clamp((rb.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        gameManagerinFlappy.GameOver();
    }
}
