using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    //Het script die de score bijhoud
    [SerializeField]
    private ScoreKeeper _scoreKeeper;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //als de speler collide met mij dan check ik of ik een Gem ben of een Cherry
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.tag == "Gem")
            {
                //voeg 1 score toe aan de GemScore var uit ScoreKeeper.cs
                _scoreKeeper.GemScore += 1;
                //animatie trigger
                _animator.SetTrigger("_pickedUp");
                //na 0.3 seconden wordt Hide() uitgevoert
                Invoke("Hide", 0.3f);
                //dit verandert de text van de in game score via de ScoreKeeper
                _scoreKeeper.ChangeTextInGame();
            }
            if (this.gameObject.tag == "Cherry")
            {
                _scoreKeeper.CherryScore += 1;
                _animator.SetTrigger("_pickedUp");
                Invoke("Hide", 0.3f);
                _scoreKeeper.ChangeTextInGame();
            }
        }
    }

    private void Hide()
    {
        //dit zet het object waar het op zit op inactief
        this.gameObject.SetActive(false);
    }
}
