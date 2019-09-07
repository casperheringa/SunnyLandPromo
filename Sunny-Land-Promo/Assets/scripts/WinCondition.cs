using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private EnergySwitch _energySwitch;
    public bool _isWinning;

    void Start()
    {
        _energySwitch = GetComponent<EnergySwitch>();
    }

    void Update()
    {
        _isWinning = _energySwitch._isSwitchOn;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(_isWinning);
            if (_isWinning)
            {
                Debug.Log("Won!");
                other.gameObject.SetActive(false);
            }
        }
    }
}
