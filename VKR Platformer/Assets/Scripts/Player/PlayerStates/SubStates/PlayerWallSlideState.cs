using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMashine playerStateMashine, PlayerData playerData, string animBoolName) : base(player, playerStateMashine, playerData, animBoolName)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isExitingState)
        {
            Movement?.SetVelocityY(-playerData.wallSlideVelocity);
        }
    }
}
