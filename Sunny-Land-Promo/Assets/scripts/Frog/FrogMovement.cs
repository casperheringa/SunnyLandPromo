using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private bool _goingRight = true;

    [SerializeField]
    private GameObject _begin;
    [SerializeField]
    private GameObject _middle;
    [SerializeField]
    private GameObject _end;
    [SerializeField]
    private float _time;
    [SerializeField]
    private float _stayOnGround = 2f;

    [SerializeField]
    private float _myCounter;
    private bool _countDown;

    [SerializeField]
    private float _readyToMoveTime;


    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (_readyToMoveTime < Time.time)
        {
            _myCounter += _countDown ? -Time.deltaTime : Time.deltaTime;
            _animator.SetTrigger("jump");
            _animator.SetBool("didJump", true);
        }

        if (_myCounter > 1f)
        {
            _readyToMoveTime = Time.time + _stayOnGround;
            _countDown = true;
            _animator.SetBool("didJump", false);
            _spriteRenderer.flipX = false;

        }
        else if (_myCounter < 0f)
        {
            _readyToMoveTime = Time.time + _stayOnGround;
            _animator.SetBool("didJump", false);
            _countDown = false;
            _spriteRenderer.flipX = true;

        }

        _myCounter = Mathf.Clamp(_myCounter, 0f, 1f);
        _time = _myCounter;

        transform.position = Vector2.Lerp(Vector2.Lerp(_begin.transform.position, _middle.transform.position, _time), Vector2.Lerp(_middle.transform.position, _end.transform.position, _time), _time);
    }

}
