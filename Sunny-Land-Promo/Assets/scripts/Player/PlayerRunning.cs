using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRunning : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _spiteRenderer;

    //de snelheid waarmee de kan rennen
    [SerializeField]
    private float _movementSpeed = 6;

    //of de speler aan het rennen is
    private bool _isRunning = false;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private PlayerDeath _playerDeath;

    //of de speler nog leeft of niet
    private bool _playerAlive;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
        _playerDeath = GetComponent<PlayerDeath>();

    }

    private void Update()
    {
        //hier krijg je van het PlayerDeath script binnen of de speler nog leeft
        _playerAlive = _playerDeath._isPlayerAlive;
        //als de speler nog leeft
        if (_playerAlive)
        {
            //als je pijltje naar links of naar rechts doet
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //welke kant de sprite op kijkt
                _spiteRenderer.flipX = true;
                //het naar links bewegen
                _rigidbody.velocity = new Vector2(-_movementSpeed, _rigidbody.velocity.y);
                //animatie starten
                _animator.SetBool("isRunning", true);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _spiteRenderer.flipX = false;
                //het naar rechts bewegen
                _rigidbody.velocity = new Vector2(_movementSpeed, _rigidbody.velocity.y);
                _animator.SetBool("isRunning", true);
            }

            //het stoppen van de animatie als de speler de pijltjes loslaat
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _animator.SetBool("isRunning", false);
            }
        }

    }

}
