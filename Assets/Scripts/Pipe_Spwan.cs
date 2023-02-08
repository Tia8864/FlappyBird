using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Spwan : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;

    //-1.3 == 3.3 
    [SerializeField]
    private float min, max;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Spwan());
    }

    //function spwan pipe
    IEnumerator _Spwan()
    {
        yield return new WaitForSeconds(1);
        Instantiate(pipeHolder, _RandomPosition(min, max), Quaternion.identity);
        StartCoroutine(_Spwan());
    }

    public Vector3 _RandomPosition(float min, float max)
    {
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(min, max);
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
