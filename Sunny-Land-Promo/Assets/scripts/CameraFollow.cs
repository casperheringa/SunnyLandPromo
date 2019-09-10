using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    void Update()
    {
        //als er een speler is verander dan mijn positie naar die van de speler
        if (_player)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
        }

    }
}
