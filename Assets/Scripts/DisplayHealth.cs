using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    private Text text;
    [SerializeField]
    GameObject HealthDisplay;
    [SerializeField]
    GameObject TimerDisplay;
    private Player player;
    private int health;



    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (HealthDisplay)
        {
            HealthDisplay.SetActive(true);
        }

        GameObject aPlayer = GameObject.FindWithTag("Player");
        if (aPlayer != null )
        {
            player = aPlayer.GetComponent<Player>();
        }

    }

    // Update is called once per frame
    void Update() {
        health = Mathf.RoundToInt(player.getHealth());

        if (health > 0)
        {
            if (text)
            {
                text.text = "" + health.ToString("F");
            }
        }
        else
        {

            if (TimerDisplay) {
                TimerDisplay.GetComponent<Countdown>().endGame();
            }
            
        }
    }
}
