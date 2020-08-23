using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bouncer : Enemy
{
   
    protected override void PlayerImpact(Player player)
    {
        var magnitude = 2500;

        var force = player.transform.position - transform.position;

        force.Normalize();
        player.GetComponent<Rigidbody>().AddForce(-force * magnitude);
        player.DecreaseHealth(1);

    }
}
