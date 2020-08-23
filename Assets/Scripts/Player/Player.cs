using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;

    BallMotor _ballMotor;

    [SerializeField] float _treasureScore = 0;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
    }

    private void Start()
    {
        _ballMotor = GetComponent<BallMotor>();
        _currentHealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's Health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void IncreaseTreasure(int amount)
    {
        _treasureScore += amount;
        //do stuff with UI
        Debug.Log("Score: " + _treasureScore);
    }
    public void Kill()
    {
        gameObject.SetActive(false);
        //do stuff
    }
}
