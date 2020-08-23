using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    protected override void Collect(Player player)
    {
        //throw new System.NotImplementedException();
        player.IncreaseTreasure(1);
    }

    protected override void Movement(Rigidbody rb)
    {
        //base.Movement(rb);
        Quaternion turnOffset = Quaternion.Euler(0, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
