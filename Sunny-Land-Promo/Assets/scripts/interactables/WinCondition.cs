using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    //het EnergySwitch script
    private EnergySwitch _energySwitch;
    //het UI script
    [SerializeField]
    private UI _uI;
    //het ScoreKeeper script
    [SerializeField]
    private ScoreKeeper _scoreKeeper;

    //deze houd bij of de speler kan winnen
    public bool IsWinning;

    void Start()
    {
        _energySwitch = GetComponent<EnergySwitch>();
    }

    //Als de speler collide met het de deur van het huisje (waar dit script op zit)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //en de speler is aan het winnen
            if (IsWinning)
            {
                //gaat het end scherm aan via het UI script
                _uI.EndScreen();
                //zegt dat de score in het eind scherm moet worden geupdate
                _scoreKeeper.ChangeTextEndScore();
                //en zet de speler op inactief
                other.gameObject.SetActive(false);
            }
        }
    }
}
