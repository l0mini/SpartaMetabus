using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : BaseController
{
   
    private Camera camera;
    

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    void OnMove(InputValue inputValue)
    {  
            moveDirection = inputValue.Get<Vector2>();
            moveDirection = moveDirection.normalized;
    }

    void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if(lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    void OnJump()
    {
            Jump();
    }
}
