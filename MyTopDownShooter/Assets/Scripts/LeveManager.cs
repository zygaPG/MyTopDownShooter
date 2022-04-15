using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeveManager : MonoBehaviour
{
    [SerializeField]
    GameObject losePanel;

    public void PlayerDead()
    {
        losePanel.SetActive(true);
    }


    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
