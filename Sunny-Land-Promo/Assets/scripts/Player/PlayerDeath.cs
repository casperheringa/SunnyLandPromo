using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerDiedText;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    //Aantal levens van de speler
    [SerializeField]
    private int _playerLives = 2;
    //de text in het UI voor de levens
    [SerializeField]
    private Text _playerLivesText;

    //of de speler nog in leven is
    public bool _isPlayerAlive = true;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody = this.GetComponent<Rigidbody2D>();

        //speler dood bericht gaat op inactief
        _playerDiedText.SetActive(false);
        //de speler leeft
        _isPlayerAlive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Als de speler een enemy en de speler beweegd niet naar beneden (dus springt niet bovenop de enemy) dan wordt die functie aangeroepen
        if (other.gameObject.CompareTag("Enemy"))
        {

            if (GetComponent<Rigidbody2D>().velocity.y > -0.001f)
            {
                PlayerDies();
            }
        }
        // als de speler kill barier of Spikes aanraakt dan gaat hij bij de barier in 1 keer dood en bij de spikes niet en wordt die functie weer aangeroepen.
        if (other.gameObject.CompareTag("Kill Barier"))
        {
            _playerLives = 0;
            PlayerDies();
        }
        if (other.gameObject.CompareTag("Spikes"))
        {
            PlayerDies();
        }
    }

    private void PlayerDies()
    {
        //start animatie
        _animator.SetTrigger("isHurt");
        //hier verliest de speler zijn levens als hij geraakt wordt
        _playerLives -= 1;
        //dit verandert de _playerLivesText in game naar het aantal levens
        _playerLivesText.text = "" + _playerLives;
        //als de speler geen levens meer heeft
        if (_playerLives <= 0)
        {
            //dit zorgt ervoor dat de levens van de speler niet verder onder 0 gaan
            _playerLives = 0;
            //Dood text gaat aan
            _playerDiedText.SetActive(true);
            //speler is dood
            _isPlayerAlive = false;
            //speler wordt inactief gezet
            this.gameObject.SetActive(false);
        }
    }

}
