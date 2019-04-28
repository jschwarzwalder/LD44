using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private int Level;

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void NextScene()
    {
        int level = Level + 1;
        SceneManager.LoadScene(level);
    }
    public void Start()
    {
        Level = SceneManager.GetActiveScene().buildIndex;
    }

}
