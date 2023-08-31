using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    [SerializeField] private float moveSpeed =  5f;
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    private bool canMove;
    public bool CanMove {
        get { return canMove; }
        set { canMove = value; }
    }
    void Start()
    {
        canMove = true;
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        if (canMove == true) {
            rb.velocity = ctx.ReadValue<Vector2>() * moveSpeed;
        }
    }

    public void OnMelee(InputAction.CallbackContext ctx) {

    }

}
