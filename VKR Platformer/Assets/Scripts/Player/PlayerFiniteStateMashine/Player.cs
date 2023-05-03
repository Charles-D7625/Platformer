using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Player : MonoBehaviour
{
    public Core Core { get; private set; }
    public PlayerStateMashine StateMashine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set;}
    public PlayerWallJumpState WallJumpState { get; protected set;}
    public PlayerAttackState PrimatyAttackState { get; protected set; }
    public PlayerAttackState SecondaryAttackState { get; protected set; }

    [SerializeField]
    private PlayerData playerData;

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public PlayerInventory Inventory { get; private set; }

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;

    public Vector2 CurrentVelocity { get; private set; }

    public int FacingDirection { get; private set; }
    
    private Vector2 workSpace;

    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMashine = new PlayerStateMashine();

        IdleState = new PlayerIdleState(this, StateMashine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMashine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMashine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMashine, playerData, "inAir");
        WallSlideState = new PlayerWallSlideState(this, StateMashine, playerData, "wallSlide");
        WallJumpState = new PlayerWallJumpState(this, StateMashine, playerData, "inAir");
        PrimatyAttackState = new PlayerAttackState(this, StateMashine, playerData, "attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMashine, playerData, "attack");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        Inventory = GetComponent<PlayerInventory>();

        FacingDirection = 1;

        PrimatyAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);

        StateMashine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMashine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMashine.CurrentState.PhysicsUpdate();
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }

    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection) 
        {
            Flip();
        }
    }

    private void AnimationTrigger() => StateMashine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMashine.CurrentState.AnimationFinishTrigger();

    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + playerData.wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }*/
}
