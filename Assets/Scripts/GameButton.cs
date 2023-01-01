using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameButton : MonoBehaviour
{
    private GameObject player;
    public TextMeshProUGUI timerText;
    public Timer timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void QuitSafeZone()
    {
        timerText.enabled = true;
        timer.currentTime = 0;
    }
}
