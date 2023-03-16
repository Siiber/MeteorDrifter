using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public static int hiScore;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI hiScoreText;
    public GameObject[] asteroidFields;
    public GameObject player;
    public Animator fadeScreen;

    private void Start()
    {
        hiScore = PlayerPrefs.GetInt("HiScore");
        hiScoreText.text = "Hi Score: " + hiScore.ToString();
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel(1));
    }

    public void Retry()
    {
        //SceneManager.LoadScene(1);
    
        StartCoroutine(LoadLevel(1));
    }

    public void Quit()
    {
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel(0));
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();

        if (score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = "Hi Score: " + hiScore.ToString();
            PlayerPrefs.SetInt("HiScore",hiScore);
            PlayerPrefs.Save();
        }
    }

    public void SpawnAsteroidField()
    {
        int rnd = Random.Range(0, 3);
        Instantiate(asteroidFields[rnd],new Vector3(
            player.transform.position.x, 
            player.transform.position.y+12, 
            player.transform.position.z), 
            player.transform.rotation);
    }

    public IEnumerator LoadLevel(int levelToLoad)
    {
        fadeScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(levelToLoad);
    }
}
