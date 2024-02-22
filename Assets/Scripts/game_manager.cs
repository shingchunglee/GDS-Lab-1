using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int soldiers_picked_up = 0;
    public int soldiers_saved = 0;

    [SerializeField]
    private Text rescued_text;

    [SerializeField]
    private Text soldiers_in_helicopter_text;

    [SerializeField]
    private Canvas game_over_canvas;

    private void Start()
    {
        UpdateRescuedText();
        UpdateSoldiersInHelicopterText();
    }

    public void GameOver()
    {
        game_over_canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public bool IncrementSoldiersPickedUp()
    {
        if (soldiers_picked_up >= 3)
        {
            return false;
        }
        soldiers_picked_up++;
        UpdateSoldiersInHelicopterText();
        return true;
    }

    public bool EmptyHelicopter()
    {
        soldiers_saved += soldiers_picked_up;
        soldiers_picked_up = 0;
        UpdateRescuedText();
        UpdateSoldiersInHelicopterText();
        return true;
    }

    private void UpdateRescuedText()
    {
        rescued_text.text = "Soldiers Rescued: " + soldiers_saved;
    }

    private void UpdateSoldiersInHelicopterText()
    {
        soldiers_in_helicopter_text.text = "Soldiers in Helicopter: " + soldiers_picked_up;
    }
}
