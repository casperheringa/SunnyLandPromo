using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerDiedText;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public bool _isPlayerAlive = true;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody = this.GetComponent<Rigidbody2D>();

        _playerDiedText.SetActive(false);
        _isPlayerAlive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<Rigidbody2D>().velocity.y > -0.001f)
            {
                PlayerDies();
            }
        }
        if (other.gameObject.CompareTag("Kill Barier"))
        {
            PlayerDies();
        }
    }

    private void PlayerDies()
    {
        _playerDiedText.SetActive(true);
        _animator.SetTrigger("isHurt");
        _isPlayerAlive = false;
    }

}
