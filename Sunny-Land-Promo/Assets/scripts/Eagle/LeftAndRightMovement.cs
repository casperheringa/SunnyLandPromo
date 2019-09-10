using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRightMovement : MonoBehaviour
{
    //dit is de snelheid waarmee dit object beweegd
    [SerializeField]
    private float _speed = 1.6f;
    //deze houd bij of je naar rechts of niet beweegd
    private bool _goingRight = true;


    //Dit zijn de posities waar dit object tussen beweegd
    [SerializeField]
    private Vector2 _pos1;
    [SerializeField]
    private Vector2 _pos2;

    //in deze var wordt in de start de goede SpriteRederer er in gedaan
    private SpriteRenderer _spriteRenderer;

    //hier in wordt de SpriteRederer opgehaald op het moment dat het spel start
    private void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //dit roept de funtie UpdateSprite() aan
        UpdateSprite();

        //dit stukje code zorgd er voor dat het object ook echt beweegd tussen pos1 en pos2
        if (_goingRight)
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * _speed * Time.deltaTime);

        if (transform.position.x >= _pos1.x)
        {
            _goingRight = false;
        }

        if (transform.position.x <= _pos2.x)
        {
            _goingRight = true;
        }
    }

    //Deze functie zorgt er voor dat de sprite van dit object altijd de goede kant op kijkt.
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
