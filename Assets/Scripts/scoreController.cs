using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    
    private TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();

        EventManager.instance.OnGetNumber += SetScore;
    }

    /*
     * set new score + bump text effect
     */
    private void SetScore(int nb)
    {
        if(nb == 6) {
            scoreText.text = (++score).ToString();
            transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), .1f);
            transform.DOScale(new Vector3(1f, 1f, 1f), 1.5f).SetEase(Ease.OutBack).SetDelay(.1f);
        }
    }

    private void OnDisable()
    {
        EventManager.instance.OnGetNumber -= SetScore;
    }



}
