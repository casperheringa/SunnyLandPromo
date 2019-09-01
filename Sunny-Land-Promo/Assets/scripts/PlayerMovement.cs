using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _jumpVelocity = 20f;
    [SerializeField]
    private float _movementSpeed = 6;

    private void Update()
    {

        // _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidbody.velocity = new Vector2(-_movementSpeed, _rigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigidbody.velocity = new Vector2(_movementSpeed, _rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity);
        }

    }
}
