using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerDiedText;
    private Animator _animator;

    private bool _isPlayerAlive = true;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();
        _playerDiedText.SetActive(false);
        _isPlayerAlive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerDies();
        }
    }

    private void PlayerDies()
    {
        Debug.Log("Killed by enemy");
        _playerDiedText.SetActive(true);

        _animator.SetTrigger("isHurt");
        _isPlayerAlive = false;

    }

}
