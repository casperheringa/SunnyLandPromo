using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    //dit is het scherm wat je krijgt voordat je begint
    [SerializeField]
    private GameObject _beginScreen;
    //dit is het scherm wat je krijgt als je hebt gewonnen
    [SerializeField]
    public GameObject _endScreen;

    //het script WinCondition
    [SerializeField]
    private WinCondition _winCondition;
    //of het begin scherm actief is
    private bool _isBeginScreenActive = true;

    private void Start()
    {
        //zet het begin scherm aan als het spel begint
        _beginScreen.gameObject.SetActive(true);
    }

    void Update()
    {
        //voer elke frame deze functie uit
        BeginScreen();
    }

    // deze functie kijk of de muis drukt en of het begin scherm actief is, zo ja dan wordt het scherm verborgen
    private void BeginScreen()
    {
        if (Input.GetMouseButtonDown(0) && _isBeginScreenActive)
        {
            _beginScreen.SetActive(false);
            _isBeginScreenActive = false;
        }
    }

    //deze functie kijkt of de speler gewonnen heeft via het WinCondition script en zet vervolgens het end scherm aan
    public void EndScreen()
    {
        if (_winCondition.IsWinning)
        {
            _endScreen.SetActive(true);
        }
    }
}
