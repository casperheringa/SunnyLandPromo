using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    //Dit is de kracht waarmee de speler springt
    [SerializeField]
    private float _jumpVelocity = 20f;
    //dit is een object voot het einde van de linecast
    [SerializeField]
    private Transform _endLineCast;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    //in de start() wordt ervoor gezorgd dat je met deze var bij public vars en functies kan uit _playerDeath
    private PlayerDeath _playerDeath;

    //leeft de speler
    private bool _playerAlive;
    //kan de speler springen?
    private bool _canJump = false;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
        _playerDeath = GetComponent<PlayerDeath>();

    }

    private void Update()
    {
        //referentie naar _playerDeath om door te geven of de speler leeft of niet
        _playerAlive = _playerDeath._isPlayerAlive;

        //voert functie uit
        LineCasting();

        //dit wordt uigevoert als de speler leeft
        if (_playerAlive)
        {
            //als de speler kan springen en spatie wordt ingedrukt dan wordt de y velocity van de rigid body aangepast zodat de speler springt
            if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity);
                //sart animatie
                _animator.SetTrigger("isJumping");
            }
        }
        //met dit kan je in je scene view zien hoe de linecast loopt
        Debug.DrawLine(this.transform.position, _endLineCast.transform.position, Color.red);
    }

    //of de speler kan springen hangt af van of de linecast de layer "Ground" ziet, zo ja dan wordt hij op true gezet
    private void LineCasting()
    {
        _canJump = Physics2D.Linecast(this.transform.position, _endLineCast.transform.position, 1 << LayerMask.NameToLayer("Ground"));
    }
}
