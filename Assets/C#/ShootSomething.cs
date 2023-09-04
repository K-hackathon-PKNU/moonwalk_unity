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
        _theBall.transform.position = _camObj.transform.position + dir;//�׳� transform�ϸ� �׳� �����ǹ���
        _theBall.transform.SetParent(_camObj.transform); //��������
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
