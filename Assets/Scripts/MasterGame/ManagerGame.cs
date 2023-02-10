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

    [SerializeField]
    private GameObject spwamPipe;
    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
    }
    private void Start()
    {
        spwamPipe = GameObject.Find("SpwanPipe");
    }
    private void Update()
    {
        flagDeath = !Bird_Controller._Instance.isAlive;
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
        Bird_Controller._Instance.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    //----------Pipe-------------
    public void _ResetPipe()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("pipes");
        foreach (GameObject taget in pipes)
        {
            Destroy(taget);
        }
        spwamPipe.SetActive(true);
    }
}
