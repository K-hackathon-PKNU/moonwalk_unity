using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSomething : MonoBehaviour
{
    public GameObject _theBall;
    public Transform _camObj;

    public Vector3 dir;

    //0
    void Start()
    {
        _theBall.transform.position = _camObj.transform.position + dir;//그냥 transform하면 그냥 고정되버림
        _theBall.transform.SetParent(_camObj.transform); //마찬가지
        _theBall.GetComponent<Rigidbody>().useGravity = false;

    }
    void Update()
    {
        if (Input.touchCount == 1)
        {
            _theBall.gameObject.SetActive(false);
        }
    }
}
