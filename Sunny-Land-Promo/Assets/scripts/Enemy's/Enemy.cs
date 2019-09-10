using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    //een var met de speler
    [SerializeField]
    private GameObject _player;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    //als de speler de collider van de speler aanraakt en de speler zijn velocity op de y as minder is dan -0.001 dan gaat de dit object(de enemy) dood en voert hij een death animatie uit
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_player.GetComponent<Rigidbody2D>().velocity.y < -0.001f && other.gameObject.CompareTag("Player"))
        {
            // this.gameObject.SetActive(false);
            _animator.SetTrigger("dies");
            //na 0.5 sec wordt de funtie KillEnemy() uitgevoert 
            Invoke("KillEnemy", 0.5f);
        }
    }


    private void KillEnemy()
    {
        //dit zet de enemy op inactief
        this.gameObject.SetActive(false);
    }
}
