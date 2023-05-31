using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private float moveSpeed =  5f;
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        rb.velocity = ctx.ReadValue<Vector2>() * moveSpeed;
    }
}
