using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ManagerGUI : MonoBehaviour/*Singleton<ManagerGUI>*/
{
    [SerializeField]
    private GameObject BeginGUI, InGamgeGUI, EndGUI, MenuGUI;
    [SerializeField]
    private TextMeshProUGUI txtPoint, txtScore, txtBest;
    [SerializeField]
    private Button btnPause, btnOK, btnShare, btnIntrucction;

    private bool isBeginGUI,isInGameGUI, isMenuGUI, isEndGUI;
    private void Awake()
    {
        /*MakeSingleton(false);*/
    }
    private void Start()
    {
        isBeginGUI = true;
        BeginGUI.SetActive(isBeginGUI);
        isInGameGUI = false;
        isMenuGUI = false;
        isEndGUI = false;
    }

    private void Update()
    {
        _Solve();
    }

    public void _Solve()
    {
        txtPoint.SetText(Bird_Controller._Instance.point + "");
        if (Bird_Controller._Instance.flag == 1)
        {
            isEndGUI = true;
            isInGameGUI = false;
            _Summary();
            _IsShow();
            Bird_Controller._Instance.flag = 0;
        }
    }
    public void _ResetBird()
    {
        Bird_Controller._Instance.transform.position = Vector3.zero;
        Bird_Controller._Instance.point = 0;
    }
    public void _PlayGame()
    {
        isBeginGUI = false;
        isInGameGUI = true;
        _IsShow();
    }
    public void _Pause()
    {
        isInGameGUI = false;
        isMenuGUI = true;
        _IsShow();
        Time.timeScale = 0;
    }
    public void _Continue()
    {
        isMenuGUI = false;
        isInGameGUI = true;
        _IsShow();
        Time.timeScale = 1;
    }
    public void _PlayAgain()
    {
        isEndGUI = false;
        isBeginGUI = true;
        _IsShow();
    }
    public void _Summary()
    {
        txtScore.text = txtPoint.text;
        int point = Int32.Parse(txtPoint.text);
        int score = Int32.Parse(txtScore.text);
        int best = Int32.Parse(txtBest.text);
        if (best < score) best = score;
        txtBest.SetText(best + "");
    }
    public void _IsShow()
    {
        BeginGUI.SetActive(isBeginGUI);
        InGamgeGUI.SetActive(isInGameGUI);
        MenuGUI.SetActive(isMenuGUI);
        EndGUI.SetActive(isEndGUI);
    }
}
