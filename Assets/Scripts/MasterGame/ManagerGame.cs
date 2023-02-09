using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame _Instance;
    //-------score---------
    private int point = 0, best =0;
    [SerializeField]
    private TextMeshProUGUI txtPoint, txtScore, txtBest;
    private bool flagDeath;

    //----------Bird-------------
    //[SerializeField]
    //private GameObject bird;
    //----------Pipe-------------
    [SerializeField]
    private GameObject spwanPipe;

    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
    }
    private void Start()
    {
        flagDeath = !Bird_Controller._Instance.isAlive;
    }
    private void Update()
    {
        point = Bird_Controller._Instance.point;
        txtPoint.SetText(point + "");
        if(flagDeath)
        {
            txtScore.text = txtPoint.text;
            if (best < point) best = point;
            txtBest.SetText(best + "");
        }
    }

    //----------Bird-------------
    public void _ResetBird()
    {
        Bird_Controller._Instance.transform.position = Vector3.zero;
        Bird_Controller._Instance.isAlive = true;
        Bird_Controller._Instance.point = 0;
    }
    //----------Pipr------------
    public void _ResetPipe()
    {

    }
}
