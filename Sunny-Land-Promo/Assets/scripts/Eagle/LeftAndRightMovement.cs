using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRightMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.6f;
    [SerializeField]
    private float _distance = 5f;
    private bool _goingRight = true;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateSprite();

        if (_goingRight)
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * _speed * Time.deltaTime);

        if (transform.position.x >= _distance)
        {
            _goingRight = false;
        }

        if (transform.position.x <= -_distance)
        {
            _goingRight = true;
        }
    }

    private void UpdateSprite()
    {
        if (_goingRight)
        {
            _spriteRenderer.flipX = true;
        }
        else if (!_goingRight)
        {
            _spriteRenderer.flipX = false;
        }
    }

}
