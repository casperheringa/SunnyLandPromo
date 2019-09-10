using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        //als je op linker shift drukt wodr de animatie uitgeoerd en als je hem los laat stopt hij
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("isCrouching", true);
        }
        else
        {
            _animator.SetBool("isCrouching", false);
        }
    }
}
