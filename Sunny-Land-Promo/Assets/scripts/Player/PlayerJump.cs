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
    private bool _canJump = false;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        LineCasting();
        if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity);
            _animator.SetBool("isJumping", true);
        }
        else if (!_canJump)
        {
            _animator.SetBool("isJumping", false);
        }
        Debug.Log("player can jump " + _canJump);
        Debug.DrawLine(this.transform.position, _endLineCast.transform.position, Color.red);
    }

    private void LineCasting()
    {
        _canJump = Physics2D.Linecast(this.transform.position, _endLineCast.transform.position, 1 << LayerMask.NameToLayer("Ground"));
    }
}
