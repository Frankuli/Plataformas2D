using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public Text scoreText;
    public float scoreValue;

    public Text maxScoreText;
    public float maxScoreValue;

    private void Start()
    {
        maxScoreValue = PlayerPrefs.GetFloat("Max");
        maxScoreText.text = maxScoreValue.ToString("0.00");
    }


    void Update()
    {
        scoreValue += Time.deltaTime;

        scoreText.text = scoreValue.ToString("0.00");

        if (maxScoreValue < scoreValue)
        {
            PlayerPrefs.SetFloat("Max", scoreValue );
            maxScoreText.text = scoreValue.ToString("0.00");
        }

    }

    public void AddPuntuation(float puntuatioObjectValue)
    {
        scoreValue += puntuatioObjectValue;

    }
}
