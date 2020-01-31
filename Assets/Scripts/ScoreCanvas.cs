using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCanvas : MonoBehaviour
{
    public Text ScoreText;
    private int score;
    private void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();
        Cell.MaxLevelRes += Cell_MaxLevelRes;
    }

    private void Cell_MaxLevelRes(object sender, System.EventArgs e)
    {
        score += 100;
        ScoreText.text = score.ToString();
    }
}
