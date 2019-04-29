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
    private bool running;

    public float getTime() { return time; }
    public void endGame() {
        time = 0;
    }

    public void Stop () {
        
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

        running = true;

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
            Stop();
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
