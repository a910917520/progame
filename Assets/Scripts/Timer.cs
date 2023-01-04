using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI enemyLeftText;
    public float currentTime;
    public bool countDown;
    public GameObject cam1;
    public GameObject cam2;


    public GameObject player;
    public GameObject[] enemySpawnPoints;
    public GameObject smallLv1, middleLv1, largeLv1, tankLv1, speedLv1;
    public GameObject smallLv2, middleLv2, largeLv2, tankLv2, speedLv2;
    public GameObject smallLv3, middleLv3, largeLv3, tankLv3, speedLv3;
    public GameObject smallLv4, middleLv4, largeLv4, tankLv4, speedLv4;
    public GameObject smallLv5, middleLv5, largeLv5, tankLv5, speedLv5;
    public int stage;
    private bool isSafe;
    private int enemyCount;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        currentTime = 99999;
        timerText.enabled = (false);
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
        GameOver();
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        enemyLeftText.text = (enemyCount + " LEFT");
        if (currentTime <= 0)
        {
            foreach(GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
    void StageClear()
    {
        StopAllCoroutines();
        if (!isSafe && enemyCount <= 0)
        {
            isSafe = true;
            cam1.SetActive(false);
            player.transform.position = new Vector2(43, -21.5f);
            cam2.SetActive(true);
            currentTime = 99999; //安全區持續秒數
            player.GetComponent<Stats>().Heal();
            timerText.enabled = false;
            stage++;
        }
        else if (isSafe)
        {
            timerText.color = Color.red;
            cam2.SetActive(false);
            player.transform.position = new Vector2(-18, -0.3f);
            cam1.SetActive(true);
            player.GetComponent<Stats>().Heal();
            if (stage == 1)
            {
                currentTime = 60;
                stageText.text = ("Stage " + stage);
                Stage_1();
                isSafe = false;
            }
            if (stage == 2)
            {
                currentTime = 120;
                stageText.text = ("Stage " + stage);
                Stage_2();
                isSafe = false;
            }
            if (stage == 3)
            {
                currentTime = 120;
                stageText.text = ("Stage " + stage);
                Stage_3();
                isSafe = false;
            }
            if (stage == 4)
            {
                currentTime = 120;
                stageText.text = ("Stage " + stage);
                Stage_4();
                isSafe = false;
            }
            if (stage == 5)
            {
                currentTime = 180;
                stageText.text = ("Stage " + stage);
                Stage_5();
                isSafe = false;
            }
            if (stage == 6)
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }
    void Stage_1()
    {
        //spawnpoint_1
        StartCoroutine(spawnEnemy(0, 60, 1, smallLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 60, 4, middleLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 60, 30, tankLv1, enemySpawnPoints[0]));
        //spawnpoint_2
        StartCoroutine(spawnEnemy(0, 60, 2, smallLv1, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 60, 8, middleLv1, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(0, 60, 2, smallLv1, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 60, 8, middleLv1, enemySpawnPoints[2]));

        //Wait 30 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(30, 30, 8, speedLv1, enemySpawnPoints[0]));
        //spawnpoint_2
        StartCoroutine(spawnEnemy(30, 30, 20, speedLv1, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(30, 30, 20, speedLv1, enemySpawnPoints[2]));
    }
    void Stage_2()
    {
        //spawnpoint_1
        StartCoroutine(spawnEnemy(0,120, 2, smallLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0,120, 3, smallLv2, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0,90, 6, middleLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0,90, 10, largeLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0,90, 30, tankLv1, enemySpawnPoints[0]));
        //spawnpoint_2
        StartCoroutine(spawnEnemy(0, 120, 2, smallLv1, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 120, 6, smallLv2, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 120, 10, middleLv1, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 120, 30, middleLv2, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(0, 120, 2, smallLv1, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 120, 6, smallLv2, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 120, 10, middleLv1, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 120, 30, middleLv2, enemySpawnPoints[1]));

        //Wait 30 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(30, 90, 8, speedLv2, enemySpawnPoints[0]));

        //Wait 60 Seconds

        //spawnpoint_2
        StartCoroutine(spawnEnemy(60, 60, 10, speedLv1, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(60, 1, 1, tankLv1, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(60, 60, 10, speedLv1, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(60, 1, 1, tankLv1, enemySpawnPoints[2]));

        //Wait 90 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(90, 30, 3, middleLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(90, 30, 6, largeLv1, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(90, 30, 10, tankLv1, enemySpawnPoints[0]));

    }
    void Stage_3()
    {
        //spawnpoint_1
        StartCoroutine(spawnEnemy(0, 60, 3, smallLv3, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 120, 5, middleLv3, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 60, 10, largeLv2, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 120, 10, speedLv2, enemySpawnPoints[0]));
        //spawnpoint_2
        StartCoroutine(spawnEnemy(0, 120, 3, smallLv2, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 120, 8, middleLv2, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 120, 10, speedLv2, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(0, 120, 3, smallLv2, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 120, 8, middleLv2, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 120, 10, speedLv2, enemySpawnPoints[2]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(0, 120, 1, smallLv2, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 60, 6, middleLv3, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 60, 10, largeLv2, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 120, 15, speedLv3, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(0, 120, 1, smallLv2, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(0, 60, 6, middleLv3, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(0, 60, 10, largeLv2, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(0, 120, 15, speedLv3, enemySpawnPoints[4]));

        //Wait 60 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(60, 60, 1, smallLv3, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(60, 60, 5, largeLv3, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(60, 60, 15, tankLv3, enemySpawnPoints[0]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(60, 60, 4, middleLv3, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(60, 60, 7, largeLv2, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(60, 60, 4, middleLv3, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(60, 60, 7, largeLv2, enemySpawnPoints[4]));
    }
    void Stage_4()
    {
        //spawnpoint_1
        StartCoroutine(spawnEnemy(0, 120, 1, smallLv2, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 90, 3, smallLv4, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 120, 4, middleLv3, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 60, 6, largeLv3, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 90, 10, speedLv4, enemySpawnPoints[0]));
        //spawnpoint_2
        StartCoroutine(spawnEnemy(0, 120, 3, smallLv3, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 90, 8, middleLv4, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 90, 5, speedLv4, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(0, 120, 3, smallLv3, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 90, 8, middleLv4, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 90, 5, speedLv4, enemySpawnPoints[2]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(0, 120, 2, smallLv4, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 90, 6, middleLv3, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 90, 10, largeLv3, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(0, 120, 2, smallLv4, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 90, 6, middleLv3, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 90, 10, largeLv3, enemySpawnPoints[3]));

        //Wait 60 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(60, 60, 3, largeLv3, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(60, 0.5f, 0.1f, largeLv4, enemySpawnPoints[0]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(60, 30, 20, tankLv4, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(60, 1, 1, tankLv4, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(60, 30, 20, tankLv4, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(60, 1, 1, tankLv4, enemySpawnPoints[4]));

        //Wait 90 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(90, 30, 1, smallLv4, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(90, 30, 5, speedLv4, enemySpawnPoints[0]));
        //spawnpoint_2
        StartCoroutine(spawnEnemy(90, 30, 4, middleLv4, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(90, 30, 2, speedLv4, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(90, 30, 4, middleLv4, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(90, 30, 2, speedLv4, enemySpawnPoints[2]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(90, 30, 3, middleLv3, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(90, 30, 5, largeLv2, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(90, 30, 5, tankLv4, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(90, 30, 3, middleLv3, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(90, 30, 5, largeLv2, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(90, 30, 5, tankLv4, enemySpawnPoints[4]));
    }
    void Stage_5()
    {
        //spawnpoint_1
        StartCoroutine(spawnEnemy(0, 180, 1, smallLv4, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 120, 2, middleLv5, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 120, 5, largeLv4, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(0, 120, 10, tankLv4, enemySpawnPoints[0]));
        //spawnpoint_2
        StartCoroutine(spawnEnemy(0, 150, 3, middleLv4, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 150, 5, largeLv5, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(0, 90, 8, speedLv5, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(0, 150, 3, middleLv4, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 150, 5, largeLv5, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(0, 90, 8, speedLv5, enemySpawnPoints[2]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(0, 120, 2, smallLv5, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 120, 2, middleLv4, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 60, 10, largeLv4, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(0, 180, 8, speedLv5, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(0, 120, 2, smallLv5, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(0, 120, 2, middleLv4, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(0, 60, 10, largeLv4, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(0, 180, 8, speedLv5, enemySpawnPoints[4]));

        //Wait 60 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(60, 120, 1, smallLv5, enemySpawnPoints[0]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(60, 120, 5, largeLv4, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(60, 120, 5, largeLv4, enemySpawnPoints[4]));

        //Wait 90 Seconds

        //spawnpoint_2
        StartCoroutine(spawnEnemy(90, 90, 3, speedLv5, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(90, 90, 3, speedLv5, enemySpawnPoints[2]));

        //Wait 120 Seconds

        //spawnpoint_1
        StartCoroutine(spawnEnemy(120, 60, 1, middleLv5, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(120, 60, 3, largeLv4, enemySpawnPoints[0]));
        StartCoroutine(spawnEnemy(120, 60, 5, tankLv4, enemySpawnPoints[0]));
        //spawnpoint_4
        StartCoroutine(spawnEnemy(120, 60, 1, smallLv5, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(120, 60, 1, middleLv4, enemySpawnPoints[3]));
        StartCoroutine(spawnEnemy(120, 60, 5, largeLv5, enemySpawnPoints[3]));
        //spawnpoint_5
        StartCoroutine(spawnEnemy(120, 60, 1, smallLv5, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(120, 60, 1, middleLv4, enemySpawnPoints[4]));
        StartCoroutine(spawnEnemy(120, 60, 5, largeLv5, enemySpawnPoints[4]));

        //Wait 150 Seconds

        //spawnpoint_2
        StartCoroutine(spawnEnemy(150, 30, 1, middleLv4, enemySpawnPoints[1]));
        StartCoroutine(spawnEnemy(150, 30, 2, largeLv5, enemySpawnPoints[1]));
        //spawnpoint_3
        StartCoroutine(spawnEnemy(150, 30, 1, middleLv4, enemySpawnPoints[2]));
        StartCoroutine(spawnEnemy(150, 30, 2, largeLv5, enemySpawnPoints[2]));

        //中央區域
        //spawnpoint_mid
        StartCoroutine(spawnEnemy(0, 1, 1, tankLv5, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(20, 1f, 0.1f, middleLv4, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(40, 1f, 0.1f, speedLv4, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(60, 1, 1, tankLv5, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(60, 0.4f, 0.1f, smallLv5, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(80, 0.5f, 0.1f, largeLv5, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(100, 2f, 0.1f, middleLv5, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(120, 1, 1, tankLv5, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(120, 1f, 0.1f, smallLv5, enemySpawnPoints[5]));
        StartCoroutine(spawnEnemy(120, 0.4f, 0.1f, largeLv5, enemySpawnPoints[5]));

    }
    IEnumerator spawnEnemy(float delay, float time, float interval, GameObject enemy, GameObject spawnPoint)
    {

        while (delay>0)
        {
            delay--;
            yield return new WaitForSeconds(1f);
        }
        while (time>0)
        {
            yield return new WaitForSeconds(interval);
            time -= interval;
            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        }
    }
    void GameOver()
    {
        if (!isGameOver)
        {
            float score = player.GetComponent<Stats>().GetScore();
            if (score < 1000 && GameObject.Find("Player") == null)
            {
                Debug.Log("GameOver");
                isGameOver = true;
                //GameOver
            }
            if (GameObject.Find("Altar") == null)
            {
                Debug.Log("GameOver");
                isGameOver = true;
                //GameOver
            }
        }
    }
}
