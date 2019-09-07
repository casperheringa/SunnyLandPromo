using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySwitch : MonoBehaviour
{
    [SerializeField]
    private Sprite _switchOn;
    [SerializeField]
    private Sprite _switchOff;
    private SpriteRenderer _spriteRenderer;

    public bool _isSwitchOn = false;


    void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isSwitchOn = !_isSwitchOn;
            if (!_isSwitchOn)
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
