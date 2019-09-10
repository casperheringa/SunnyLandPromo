using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //de score tellers
    [SerializeField]
    public float CherryScore = 0;
    [SerializeField]
    public float GemScore = 0;

    //de in game score text
    [SerializeField]
    private Text _gemTextInGame, _gemTextEndScreen;
    //de score text op het end scherm
    [SerializeField]
    private Text _cherryTextInGame, _cherryTextEndScreen;

    //het updaten van de in game score text
    public void ChangeTextInGame()
    {
        _gemTextInGame.text = ": " + GemScore;
        _cherryTextInGame.text = ": " + CherryScore;
    }
    //het updaten van de score text op het end scherm
    public void ChangeTextEndScore()
    {
        _gemTextEndScreen.text = ": " + GemScore;
        _cherryTextEndScreen.text = ": " + CherryScore;
    }
}
