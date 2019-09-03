using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRunning : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _spiteRenderer;
    [SerializeField]
    private float _movementSpeed = 6;

    private bool _isRunning = false;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        // _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _spiteRenderer.flipX = true;
            _rigidbody.velocity = new Vector2(-_movementSpeed, _rigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //als player op de gond staat 
            //als isrunning true is
            // _animator.GetBool("isRunning", true);
            _spiteRenderer.flipX = false;
            _rigidbody.velocity = new Vector2(_movementSpeed, _rigidbody.velocity.y);
        }

    }

}
