using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI enemyLeftText;
    public float currentTime;
    public bool countDown;


    public GameObject player;
    public GameObject[] enemySpawnPoints;
    public GameObject smallLv1, middleLv1, largeLv1, tankLv1, speedLv1;
    public GameObject smallLv2, middleLv2, largeLv2, tankLv2, speedLv2;
    public GameObject smallLv3, middleLv3, largeLv3, tankLv3, speedLv3;
    public GameObject smallLv4, middleLv4, largeLv4, tankLv4, speedLv4;
    public GameObject smallLv5, middleLv5, largeLv5, tankLv5, speedLv5;
    private int stage;
    private bool isSafe;
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 10;
        stage = 1;
        countDown = true;
        isSafe = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountEnemy();
        GameTimer();
        DisplayTime(currentTime);
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay<0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void GameTimer()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        if (currentTime <= 0)
        {
            StageClear();
        }
    }
    void CountEnemy()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyLeftText.text = (enemyCount + " LEFT");
    }
    void StageClear()
    {
        StopAllCoroutines();
        if (!isSafe && enemyCount <= 0)
        {
            isSafe = true;
            //傳送到安全區
            player.transform.position = new Vector2(43, -21.5f);
            currentTime = 99999; //安全區持續秒數
            timerText.enabled = false;
            //離開安全區
            stage++;
        }
        else if (isSafe)
        {
            timerText.color = Color.red;
            player.transform.position = new Vector2(-18, -0.3f);
            if (stage == 1)
            {
                currentTime = 60;
                stageText.text = ("Stage " + stage);
                Stage_1();
                isSafe = false;
            }
            if (stage == 2)
            {
                currentTime = 30;
                stageText.text = ("Stage " + stage);
                Stage_2();
                isSafe = false;
            }
            if (stage == 3)
            {
                currentTime = 30;
                stageText.text = ("Stage " + stage);
                Stage_3();
                isSafe = false;
            }
        }
    }
    void Stage_1()
    {
        StartCoroutine(spawnEnemy(1, smallLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(4, middleLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(30, tankLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(8, speedLv1, enemySpawnPoints[0]));
    }
    void Stage_2()
    {
        
    }
    void Stage_3()
    {
        
    }
    IEnumerator spawnEnemy(float interval,GameObject enemy,GameObject spawnPoint)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy, spawnPoint));
    }
}
