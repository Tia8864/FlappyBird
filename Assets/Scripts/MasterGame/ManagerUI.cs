using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI _Instance;
    /*[SerializeField]
    private Button btnPause, btnContinue, btnOK, btnShare, btnIntruction;*/
    [SerializeField]
    private GameObject beginUI, inGameUI, endUI, menuUI;
    private bool isBegin, isInGame, isEnd, isMenu;

    //-----------------------------------
    public bool flagReset = false;
    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
        Time.timeScale = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        isBegin = true;
        isInGame = false;
        isMenu = false;
        isEnd = false;
        _Show();
    }

    private void _Show()
    {
        beginUI.SetActive(isBegin);
        inGameUI.SetActive(isInGame);
        menuUI.SetActive(isMenu);
        endUI.SetActive(isEnd);
    }

    public void _BtnIntruction()
    {
        isBegin = false;
        isInGame = true;
        _Show();
        Time.timeScale = 1;
    }

    public void _BtnPause()
    {
        isInGame = false;
        isMenu = true;
        _Show();
        Time.timeScale = 0;
    }

    public void _BtnContinue()
    {
        isMenu = false;
        isInGame = true;
        _Show();
        Time.timeScale = 1;
    }

    public void _BtnOk()
    {
        isEnd = false;
        isBegin = true;
        flagReset = true;
        _Show();
        Time.timeScale = 0;
    }

    public void _BtnShare()
    {
        //nothing
    }
}
