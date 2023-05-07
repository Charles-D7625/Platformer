using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionsSences CollisionsSences { get => collisionsSences ??= core.GetCoreComponent<CollisionsSences>(); }
    private CollisionsSences collisionsSences;

    private int xInput;

    private bool isGrounded;
    private bool jumpInputStop;
    private bool coyoteTime;
    private bool wallJumpCoyoteTime;
    private bool jumpInput;
    private bool isJumping;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private bool oldIsTouchingWall;
    private bool oldIsTouchingWallBack;

    private float StartWallJumpCoyoteTime;

    public PlayerInAirState(Player player, PlayerStateMashine playerStateMashine, PlayerData playerData, string animBoolName) : base(player, playerStateMashine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();

        oldIsTouchingWall = isTouchingWall;
        oldIsTouchingWallBack = isTouchingWallBack;

        if (CollisionsSences)
        {
            isGrounded = CollisionsSences.Ground;
            isTouchingWall = CollisionsSences.WallFront;
            isTouchingWallBack = CollisionsSences.WallBack;
        }

        if (!wallJumpCoyoteTime && !isTouchingWall && !isTouchingWallBack && (oldIsTouchingWall || oldIsTouchingWallBack))
        {
            StartWallJumpCayoteTime();
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        oldIsTouchingWall = false;
        oldIsTouchingWallBack = false;
        isTouchingWall = false;
        isTouchingWallBack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();
        CheckWallJumpCoyoteTime();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;

        CheckJumpMultiplier();

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            playerStateMashine.ChangeState(player.PrimatyAttackState);
        }
        else if (isGrounded && Movement?.CurrentVelocity.y < 0.01f)
        {
            playerStateMashine.ChangeState(player.IdleState);
        }
        else if(jumpInput && (isTouchingWall || isTouchingWallBack || wallJumpCoyoteTime))
        {
            StoptWallJumpCayoteTime();
            isTouchingWall = CollisionsSences.WallFront;
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            playerStateMashine.ChangeState(player.WallJumpState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            playerStateMashine.ChangeState(player.JumpState);
        }
        else if (isTouchingWall && xInput == Movement?.FacingDirection && Movement?.CurrentVelocity.y <= 0f)
        {
            playerStateMashine.ChangeState(player.WallSlideState);
        }
        else
        {
            Movement?.CheckIfShouldFlip(xInput);
            Movement?.SetVelocityX(playerData.movementVelocity * xInput);

            player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
        }
    }

    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (Movement.CurrentVelocity.y <= 0.0f)
            {
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if(coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }
    private void CheckWallJumpCoyoteTime()
    {
        if (wallJumpCoyoteTime && Time.time > StartWallJumpCoyoteTime + playerData.coyoteTime)
        {
            wallJumpCoyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartCoyoteTime() => coyoteTime = true;
    public void StartWallJumpCayoteTime() 
    {
        wallJumpCoyoteTime = true;
        StartWallJumpCoyoteTime = Time.time;
    } 
    public void StoptWallJumpCayoteTime() => wallJumpCoyoteTime = false;

    public void SetIsJumping() => isJumping = true;
}
