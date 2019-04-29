using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float time;
    private Text text;
    [SerializeField] GameObject retryLevelButton;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject TimerDisplay;
    [SerializeField] bool successTimer;
    private float musicVolume;
    private bool running;
    private AudioSource timeUpSound;
    private AudioSource musicSource;
    private bool success;

    public float getTime() { return time; }
    public void endGame(bool success) {
        running = false;
        this.success = success;

    }


    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        if (TimerDisplay)
        {
            TimerDisplay.SetActive(true);
        }
        if (nextLevelButton)
        {
            nextLevelButton.SetActive(false);
        }
        if (retryLevelButton)
        {
            retryLevelButton.SetActive(false);
        }
        if (Music.Instance)
        {
            musicSource = Music.Instance.GetComponent<AudioSource>();
            musicVolume = musicSource.volume;

        }

        running = true;
        timeUpSound = GetComponent<AudioSource>();
        success = successTimer;

    }

    // Update is called once per frame
    void Update()
    {

        if (running && time > 0.0000f)
        {
            time -= Time.deltaTime;
            if (text)
            {
                text.text = "" + time.ToString("F");
            }
        }
        else
        {
            if (success) {
                nextLevelButton.SetActive(true);
            }
            else {
                retryLevelButton.SetActive(true);
            }
            musicSource.volume = musicVolume / 4;
            enabled = false;
            if (success == successTimer) {
                timeUpSound.Play();
            }
            //Debug.Log(Music.volume);
        }
    }

    private void OnDestroy () {
        musicSource.volume = musicVolume;
    }
}
