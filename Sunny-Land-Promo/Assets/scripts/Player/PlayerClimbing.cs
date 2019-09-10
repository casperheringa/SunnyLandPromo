using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    //dit houd bij of de speler aan het klimmen is
    private bool _isClimbing = false;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    //dit is de snelheid waarmee de speler klimt
    [SerializeField]
    private float _climbSpeed;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        //dit wordt uigevoerd waneer de speler aan het klimmen is
        if (_isClimbing)
        {
            //als je op pijltje omhoog drukt dan start je de goede animatie en gaat de speler omhoog
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //speler gaat omhoog met de snelheid van _climbSpeed
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _climbSpeed);
                //start animatie
                _animator.SetBool("isClimbing", true);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //speler gaat omlaag met de snelheid van _climbSpeed
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_climbSpeed);
                //start animatie
                _animator.SetBool("isClimbing", true);
            }
            else
            {
                //trigger animatie 
                _animator.SetTrigger("Climbing");
                //stop met bewegen van speler als de pijltjes los worden gelaten.
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            }
        }

    }

    //dit wordt uitgevoert op het moment dat de speler collider in een andere collider komt
    private void OnTriggerEnter2D(Collider2D other)
    {
        //kijkt naar de tag van het object waar hij in gaat "Ladder" is
        if (other.gameObject.CompareTag("Ladder"))
        {
            //dit verandert hoeveel zwaartenkracht er zich op de speler uitoefend.
            _rigidbody.gravityScale = 0;
            //speler is aan het klimmen
            _isClimbing = true;
        }
    }

    //Dit wordt uigevoerd op het moment dat de speler een collider verlaat
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            _rigidbody.gravityScale = 3;
            _animator.SetBool("isClimbing", false);
            _isClimbing = false;
        }
    }
}
