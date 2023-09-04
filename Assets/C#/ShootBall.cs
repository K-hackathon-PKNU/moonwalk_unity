using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//��� ������ script
public class ShootBall : MonoBehaviour
{
    public GameObject _theBall; //������ object
    public Transform _camObj; //camera ��ġ

    public Vector3 throwPower, dir;
    Vector3 _dir;
    public float Power;

   
     void Start()
    {
        //����� ȭ�鿡 �����ؼ� ����
        _theBall.transform.position = _camObj.transform.position + dir;//�׳� transform�ϸ� �׳� �����ǹ���
        _theBall.transform.SetParent(_camObj.transform); //��������
    }
    void Update()
     {
        _dir = transform.TransformDirection(throwPower);

        if ((Input.touchCount == 2) && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //�����ռ���
            //GameObject ball = Instantiate(_theBall) as GameObject;

            //_theBall = Instantiate(_theBall, _camObj.transform.position + dir, _camObj.transform.rotation);
        
            _theBall.transform.parent = null;
            _theBall.GetComponent<Rigidbody>().useGravity = true;
            _theBall.GetComponent<Rigidbody>().AddForce(_dir * Power, ForceMode.Force); //��� ������
            //_theBall.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)// �۵��� ����
    {
        if (other.gameObject.tag == "Pudu")
        {
            Destroy(_theBall);
        }
    }
}



