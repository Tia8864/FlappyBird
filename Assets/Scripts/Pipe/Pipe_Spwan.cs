using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Spwan : MonoBehaviour
{
    public static Pipe_Spwan _Instance;

    [SerializeField]
    private GameObject pipeHolder;
    public float timeSpwan, speedPipe;
    //-1.3 == 3.3 
    [SerializeField]
    private float min, max;
    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Spwan());
    }

    //function spwan pipe
    IEnumerator _Spwan()
    {
        yield return new WaitForSeconds(timeSpwan);
        if(Bird_Controller._Instance.isAlive)
            Instantiate(pipeHolder, _RandomPosition(min, max), Quaternion.identity);
        StartCoroutine(_Spwan());
    }

    public Vector3 _RandomPosition(float min, float max)
    {
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(min, max);
        return temp;
    }
}
