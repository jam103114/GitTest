using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : CollectibleBase
{
    [SerializeField] int _healthAdded = 1;

    protected override void Collect(Player player)
    {
        //throw new System.NotImplementedException();
        player.IncreaseHealth(_healthAdded);
    }
}
