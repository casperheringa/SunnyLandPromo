using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private GameObject _player;


    void Start()
    {
        _animator = this.GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_player.GetComponent<Rigidbody2D>().velocity.y < -0.001f)
        {
            // this.gameObject.SetActive(false);
            _animator.SetTrigger("dies");
            Invoke("KillEnemy", .5f);
        }
    }

    private void KillEnemy()
    {
        this.gameObject.SetActive(false);
    }
}
