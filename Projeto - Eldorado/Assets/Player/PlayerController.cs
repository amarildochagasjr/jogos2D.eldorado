using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    Playerinputs inputActions;

    public float speed = 2.7f;
    public float jump = 5.0f;
    public GameObject shotPrefab;
    public float shotForce = 10.0f;

    bool canJump = true;
    bool canAttack = true;

    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D body;



    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new Playerinputs();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        var moveInputs = inputActions.Player_Map.Movement.ReadValue<Vector2>();

        transform.position += speed * Time.deltaTime * new Vector3(moveInputs.x, 0, 0);

        animator.SetBool("b_isWalking", moveInputs.x != 0);

        if (moveInputs.x != 0)
        {
            sprite.flipX = moveInputs.x < 0;
        }

        canJump = Math.Abs(body.velocity.y) <= 0.001f;

        HandlerJumpAction();

        HandlerAttackAction();
    }

    void HandlerJumpAction()
    {

        var jumpPressed = inputActions.Player_Map.Jump.IsPressed();

        if (canJump && jumpPressed)
        {
            body.AddForce(jump * Vector2.up, ForceMode2D.Impulse);
        }

    }

    void HandlerAttackAction()
    {
        var attackPressed = inputActions.Player_Map.Attack.IsPressed();

        if (canAttack && attackPressed)
        {
            canAttack = false;

            animator.SetTrigger("t_isAttacking");
 
        }
    }

    public void ShotNewEgg()
    {
        var newShot = GameObject.Instantiate(shotPrefab);
            newShot.transform.position = transform.position;

        var isLookRight = !sprite.flipX;
        Vector2 shotDirection = shotForce * new Vector2(isLookRight ? -1 : 1, 0);
        newShot.GetComponent<Rigidbody2D>().AddForce(shotDirection, ForceMode2D.Impulse);
        newShot.GetComponent<SpriteRenderer>().flipY = !isLookRight;

    }

    public void SetCanAttack()
    {
        canAttack = true;
    }
}
