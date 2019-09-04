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
        // moet nog een check omheen om te checken of de speler wel leeft anders kan je niet lopen
        // _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _spiteRenderer.flipX = true;
            _rigidbody.velocity = new Vector2(-_movementSpeed, _rigidbody.velocity.y);
            _animator.SetBool("isRunning", true);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            //als player op de gond staat 
            //als isrunning true is
            // _animator.GetBool("isRunning", true);
            _spiteRenderer.flipX = false;
            _rigidbody.velocity = new Vector2(_movementSpeed, _rigidbody.velocity.y);
            _animator.SetBool("isRunning", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animator.SetBool("isRunning", false);
        }

    }

}
