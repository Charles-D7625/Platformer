using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetecetedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDeteceted playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    public override void Start()
    {
        base.Start();


        moveState = new E1_MoveState(stateMashine, this, "move", moveStateData, this);
        idleState = new E1_IdleState(stateMashine, this, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetecetedState(stateMashine, this, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(stateMashine, this, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(stateMashine, this, "lookForPlayer", lookForPlayerStateData, this);

        stateMashine.Initialize(moveState);

    }
}
