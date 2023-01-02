using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private Slider slider;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;
    private float maxHp;
    private float currentHp;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stats.GetHealthGUI(out currentHp, out maxHp);
        stats.ScoreGUI(out score);
        slider.maxValue = maxHp;
        slider.value = currentHp;
        scoreText.text = (score + "$");
        healthText.text = (currentHp + "/" + maxHp);
    }
}
