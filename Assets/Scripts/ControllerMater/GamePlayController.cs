using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void _InstructionBtn()
    {
        Time.timeScale = 1;
    }
}
