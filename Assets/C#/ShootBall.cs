using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//당근 던지기 script
public class ShootBall : MonoBehaviour
{
    public GameObject _theBall; //던져질 object
    public Transform _camObj; //camera 위치

    public Vector3 throwPower, dir;
    Vector3 _dir;
    public float Power;

   
     void Start()
    {
        //당근을 화면에 고정해서 시작
        _theBall.transform.position = _camObj.transform.position + dir;//그냥 transform하면 그냥 고정되버림
        _theBall.transform.SetParent(_camObj.transform); //마찬가지
    }
    void Update()
     {
        _dir = transform.TransformDirection(throwPower);

        if ((Input.touchCount == 2) && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //프리팹설정
            //GameObject ball = Instantiate(_theBall) as GameObject;

            //_theBall = Instantiate(_theBall, _camObj.transform.position + dir, _camObj.transform.rotation);
        
            _theBall.transform.parent = null;
            _theBall.GetComponent<Rigidbody>().useGravity = true;
            _theBall.GetComponent<Rigidbody>().AddForce(_dir * Power, ForceMode.Force); //당근 던지기
            //_theBall.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)// 작동을 안함
    {
        if (other.gameObject.tag == "Pudu")
        {
            Destroy(_theBall);
        }
    }
}



