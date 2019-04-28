using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float time;
    private Text text;
    [SerializeField] GameObject levelSelect;
    [SerializeField] GameObject TimerDisplay;
    [SerializeField] AudioSource Music;
    private float musicVolume;

    public float getTime() { return time; }
    public float endGame() {
        time = 0;
    }


    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        if (TimerDisplay)
        {
            TimerDisplay.SetActive(true);
        }
        if (levelSelect)
        {
            levelSelect.SetActive(false);
        }
        if (Music)
        {
            musicVolume = Music.volume;

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (time > 0.0000f)
        {
            time -= Time.deltaTime;
            if (text)
            {
                text.text = "" + time.ToString("F");
            }
        }
        else
        {
            if (TimerDisplay)
            {
                TimerDisplay.SetActive(false);
                levelSelect.SetActive(true);

            }
            Music.volume = musicVolume / 4;
            //Debug.Log(Music.volume);
        }
    }
}
