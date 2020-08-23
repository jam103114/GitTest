using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerUpBase : MonoBehaviour
{
    [SerializeField] float _powerUpDuration = 5f;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;
    [SerializeField] float _timer = 10f;
    [SerializeField] bool _startTimer = false;

    private Collider _collider;
    private Renderer _material;

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        _material = gameObject.GetComponent<Renderer>();

    }

    private void Update()
    {
        Timer(_startTimer);
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            FeedBack();
        }
    }
    protected virtual void PowerUp(Player player)
    {
        _startTimer = true;
        FeedBack();
        _collider.enabled = false;
        _material.enabled = false;
        Debug.Log("Hit, Start");
    }

    private void FeedBack()
    {
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
            Destroy(_impactParticles, 1f);
        }

        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }

    protected virtual void PowerDown(Player player)
    {
        _startTimer = false;
        _timer = 4f;
        gameObject.SetActive(false);
        Debug.Log("Stoped");
    }

    void Timer(bool _start)
    {
        if (_start == true)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0)
        {
            _start = false;
            Player player = gameObject.GetComponent<Player>();
            PowerDown(player);
        }
    }
}
