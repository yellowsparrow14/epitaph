using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private List<GameObject> meleeHitboxes;
    private PlayerInput playerInput;
    private Camera mainCam;
    private Rigidbody2D rb;
    private bool canMove;
    private Vector2 movementInput;
    private int currentAttack;
    public bool CanMove {
        get { return canMove; }
        set { canMove = value; }
    }
    void Start()
    {
        canMove = true;
        playerInput = GetComponent<PlayerInput>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        movementInput = Vector2.zero;
        currentAttack = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove == true) {
            rb.velocity = movementInput * moveSpeed;
        } else {
            rb.velocity = Vector3.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        movementInput = ctx.ReadValue<Vector2>();
    }

    public void OnMelee(InputAction.CallbackContext ctx) {
        if (canMove == true) {
            canMove = false;
            StartCoroutine(AttackDelay());
        }
    }
    IEnumerator AttackDelay() {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        MeleeAttack meleeAttack = meleeHitboxes[currentAttack].GetComponent<MeleeAttack>();
        meleeAttack.SetActive();
        meleeAttack.Attack(mousePos);
        yield return new WaitForSeconds(0.3f);
        meleeAttack.SetInactive();
        canMove = true;
        if (currentAttack >= meleeHitboxes.Count - 1) {
            currentAttack = 0;
        } else {
            currentAttack++;
        }
    }
}