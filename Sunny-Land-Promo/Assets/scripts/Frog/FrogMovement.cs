using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    //Deze var wordt later gebruikt om de Rigidbody2d in te doen
    private Rigidbody2D _rigidbody;
    //Deze var wordt later gebruikt om de Animator in te doen
    private Animator _animator;
    //Deze var wordt later gebruikt om de SpriteRederer in te doen
    private SpriteRenderer _spriteRenderer;

    //Dit houdt bij of de kikker naar rechts gaat of niet
    private bool _goingRight = true;

    //Deze 3 variablelen zijn om de baan aan te geven voor waar de kikker moet bewegen
    [SerializeField]
    private GameObject _begin;
    [SerializeField]
    private GameObject _middle;
    [SerializeField]
    private GameObject _end;
    //Dit is een waarde die aangeeft hoever de kikker is in zijn beweeg procces. 0.5 == 50% van het procces en 1 == 100% ect.
    [SerializeField]
    private float _time;

    //Dit is voor hoelang de kikker op de grond moet staat tussen sprongen in.
    [SerializeField]
    private float _stayOnGround = 2f;

    //the counter value
    [SerializeField]
    private float _myCounter;
    //dit is een boolean die kijkt of de counter op of af moet tellen
    private bool _countDown;

    //dit is de 2de timer voor de vertraging tussen sprongen in.
    [SerializeField]
    private float _readyToMoveTime;

    //Hier worden die die vars gevult met een Rigidbody2D, Animator, SpriteRenderer
    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        //dit is voor de spring counter
        if (_readyToMoveTime < Time.time)
        {
            _myCounter += _countDown ? -Time.deltaTime : Time.deltaTime;
            //dit is voor de goeie animaties aan te zetten
            _animator.SetTrigger("jump");
            _animator.SetBool("didJump", true);
        }

        //dit is de counter voor de vertraging tussen de sprongen in
        if (_myCounter > 1f)
        {
            _readyToMoveTime = Time.time + _stayOnGround;
            _countDown = true;
            //dit is voor de goeie animaties uit te zetten
            _animator.SetBool("didJump", false);
            _spriteRenderer.flipX = false;

        }
        else if (_myCounter < 0f)
        {
            _readyToMoveTime = Time.time + _stayOnGround;
            //dit is voor de goeie animaties uit te zetten
            _animator.SetBool("didJump", false);
            _countDown = false;
            _spriteRenderer.flipX = true;

        }
        //dit zorgt ervoor dat de var _myCounter niet onder de 0 kan komen en ook niet boven de 1.
        _myCounter = Mathf.Clamp(_myCounter, 0f, 1f);
        //hier maak je de waarden van hoever het springen in het procces is naar de waarden van de timer.
        _time = _myCounter;

        //dit is wat er voor zorgd dat de kikker tussen de begin, middel en eind positie beweegd.
        transform.position = Vector2.Lerp(Vector2.Lerp(_begin.transform.position, _middle.transform.position, _time), Vector2.Lerp(_middle.transform.position, _end.transform.position, _time), _time);
    }

}
