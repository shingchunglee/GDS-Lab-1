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

    // Start is called before the first frame update
    private void Start()
    {
        update_rescued_text();
    }

    public bool IncrementSoldiersPickedUp()
    {
        if (soldiers_picked_up >= 3)
        {
            return false;
        }
        soldiers_picked_up++;
        return true;
    }

    public bool EmptyHelicopter()
    {
        soldiers_saved += soldiers_picked_up;
        soldiers_picked_up = 0;
        update_rescued_text();
        return true;
    }

    private void update_rescued_text()
    {
        rescued_text.text = "Soldiers Rescued: " + soldiers_saved;
    }
}
