using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySwitch : MonoBehaviour
{
    //de sprite waar de switch aan staat
    [SerializeField]
    private Sprite _switchOn;
    //de sprite waar de switch uit staat
    [SerializeField]
    private Sprite _switchOff;

    private SpriteRenderer _spriteRenderer;
    //het win conditie script
    private WinCondition _winCon;

    //het huisje als game object
    [SerializeField]
    private GameObject _finish;

    //of de power switch aan of uit is
    public bool IsSwitchOn = false;


    void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _winCon = _finish.GetComponent<WinCondition>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //als de speler collide met de switch
        if (other.gameObject.CompareTag("Player"))
        {
            //verander de IsSwitchOn boolean naar het tegenovergestelde
            IsSwitchOn = !IsSwitchOn;
            //geeft door aan de IsWinning var uit het WinCondition script of de speler de switch heeft omgezet of niet
            _winCon.IsWinning = IsSwitchOn;

            //het veranderen van de sprite naar de bijbehorende sprite
            if (IsSwitchOn)
            {
                _spriteRenderer.sprite = _switchOn;
            }
            else
            {
                _spriteRenderer.sprite = _switchOff;
            }
        }
    }
}
