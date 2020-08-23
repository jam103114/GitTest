using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    Collider _playerCollider;
    Renderer _color;
    protected override void PowerUp(Player player)
    {
        base.PowerUp(player);
        _playerCollider = player.gameObject.GetComponent<Collider>();
        _playerCollider.isTrigger = true;
        _color = player.gameObject.GetComponent<Renderer>();
        _color.material.SetColor("_Color", Color.green);
    
    }

    protected override void PowerDown(Player player)
    {
        _playerCollider.isTrigger = false;
        _color.material.SetColor("_Color", Color.blue);
        base.PowerDown(player);
    }

}
