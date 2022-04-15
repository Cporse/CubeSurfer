using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BCanvasController : MonoBehaviour
{
    public static BCanvasController Instance;

    [SerializeField] private Button nextLevel;
    [SerializeField] private Text textDiamond;
    [SerializeField] private Text textScore;
    [SerializeField] private TextMeshProUGUI textTapToPlay;

    private int diamond = 0;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void DiamondCounter()
    {
        textDiamond.text = AConsts.DIAMOND_BOARD + ++diamond;
    }
    public void ScoreCounter()
    {
        textScore.text = AConsts.SCORE_BOARD + ++score;
    }
    public void TapToPlay()
    {
        CPlayerController.Instance.StartMovement();
        textTapToPlay.gameObject.SetActive(false);
    }
    public void NextLevel()
    {
        nextLevel.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void ActiviteNextButton()
    {
        nextLevel.gameObject.SetActive(true);
    }

    //END LINE.
}