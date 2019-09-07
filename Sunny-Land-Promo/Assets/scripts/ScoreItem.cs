using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField]
    private Text _cherryText;
    [SerializeField]
    private Text _gemText;
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.tag == "Gem")
            {
                _gemText.text = ": 1/1";
                _animator.SetTrigger("_pickedUp");
                Invoke("Hide", 0.3f);
            }
            if (this.gameObject.tag == "Cherry")
            {
                _cherryText.text = ": 1/1";
                _animator.SetTrigger("_pickedUp");
                Invoke("Hide", 0.3f);
            }
        }
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
