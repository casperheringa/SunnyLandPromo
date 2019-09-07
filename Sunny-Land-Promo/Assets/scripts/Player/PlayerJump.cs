using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float _jumpVelocity = 20f;
    [SerializeField]
    private Transform _endLineCast;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerDeath _playerDeath;

    private bool _playerAlive;
    private bool _canJump = false;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
        _playerDeath = GetComponent<PlayerDeath>();

    }

    private void Update()
    {
        _playerAlive = _playerDeath._isPlayerAlive;

        LineCasting();
        if (_playerAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity);
                _animator.SetTrigger("isJumping");
            }
        }

        Debug.DrawLine(this.transform.position, _endLineCast.transform.position, Color.red);
    }

    private void LineCasting()
    {
        _canJump = Physics2D.Linecast(this.transform.position, _endLineCast.transform.position, 1 << LayerMask.NameToLayer("Ground"));
    }
}
