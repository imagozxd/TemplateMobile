using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoresPanel : MonoBehaviour
{
    public TMP_Text[] scoreTexts;

    private void Start()
    {
        StartCoroutine(DatabaseHandler.Instance.GetTopScores(UpdateScoreTexts));
    }

    private void UpdateScoreTexts(List<UserPlayer> topScores)
    {
        // limpia los textos
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = ""; 
        }

        // actualiza txts
        for (int i = 0; i < topScores.Count && i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = $"{topScores[i].namePlayer}: {topScores[i].scorePlayer}";
        }
    }

    public void RegresarBtn()
    {

        GlobalSceneManager globalSceneManager = FindObjectOfType<GlobalSceneManager>();
        if (globalSceneManager != null)
        {
            //globalSceneManager.LoadGameScene();
            globalSceneManager.UnloadPuntajes();



        }
    }
}
