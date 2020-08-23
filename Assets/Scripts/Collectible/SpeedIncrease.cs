﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = 5;

    protected override void Collect(Player player)
    {
        //throw new System.NotImplementedException();
        BallMotor _motor = player.GetComponent<BallMotor>();
        if (_motor != null)
        {
            _motor.MaxSpeed += _speedAmount;
        }    
    }

    protected override void Movement(Rigidbody rb)
    {
        //base.Movement(rb);
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
