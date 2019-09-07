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
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetBool("isCrouching", true);
        }
        else
        {
            _animator.SetBool("isCrouching", false);
        }
    }
}
