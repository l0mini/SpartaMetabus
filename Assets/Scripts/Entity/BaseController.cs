using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseController : MonoBehaviour
{
   protected Rigidbody2D rb;

    protected Animation animation;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return moveDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected bool isJumping = false;
    protected float jumpPower = 15f;

    bool isJump = false;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animation>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Move(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        if (!isJump)
        {
            direction = direction * 5;
            rb.velocity = direction;
        }
        animation.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }

    protected void Jump()
    {
        if (isJump) return;
        animation.Jump();
        StartCoroutine(ResetJumpCooldown());
    }
    private IEnumerator ResetJumpCooldown()
    {
        rb.velocity += Vector2.up * jumpPower;
        isJump = true;
        yield return new WaitForSeconds(0.01f);
        rb.gravityScale = 10; 
        yield return new WaitForSeconds(0.3f);
        rb.gravityScale = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        isJump = false;
        animation.ExitJump();
    }
}