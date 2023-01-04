using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    [SerializeField]VideoPlayer ending, moon;
    void Start()
    {
        moon.Pause();
        Invoke("PlayVideo", 5f);
    }
    void PlayVideo()
    {
        moon.Play();
        Destroy(ending.gameObject);
        StartCoroutine(EndVideo());
    }
    IEnumerator EndVideo()
    {
        yield return new WaitForSeconds(5.5f);
        moon.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Menu");
    }
}
