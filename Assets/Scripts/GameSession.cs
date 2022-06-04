using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    [Range(0.1f,10.0f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioSource gameaudiosource;
    //state variables
    private int currentScore = 0;
    [SerializeField] bool isAutoPlayEnabled;

    //singleton pattern
    private void Awake()
    {

        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }        
    ///////////////////////
    private void Start()
    {
        gameaudiosource.pitch = 1f;
        scoreText.text = currentScore.ToString(); 
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        if (currentScore <= 400)
        {
            gameaudiosource.pitch = 1f;
        }
        if (currentScore > 400 && currentScore <= 800)
        {
            gameaudiosource.pitch = 2f;
        }
        if (currentScore > 800)
        {
            gameaudiosource.pitch = 3f;
        }
        scoreText.text = currentScore.ToString(); 
        currentScore += pointsPerBlockDestroyed;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
