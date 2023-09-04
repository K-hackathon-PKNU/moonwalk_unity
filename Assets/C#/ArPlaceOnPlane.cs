using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//��ġ�ϴ°��� ���׸���Ʈ ��ġ��Ű��
public class ArPlaceOnPlane : MonoBehaviour
{
    public Transform _camObj;
    public ARRaycastManager arRaycaster; //����
    public GameObject placeObject; //object����
    GameObject spawnObject;

    public Vector3 dir;

    void Update()
    {
        
        {
            PlaceObjectByTouch();
        }

        //UpdateCenterObject(); //ī�޶�տ��� �ʹ� ��¯�Ÿ�
        //if (Input.touchCount == 3)
        //{
        //    Destroy(spawnObject);
        //    PlaceObjectByTouchtoCenter();
        //}


    }
    void PlaceObjectByTouch()
    {
        //����Ʈ����ũ���� ��ġ����
        if (Input.touchCount ==1)
        {
            Touch touch = Input.GetTouch(0);//GetTouch : �հ���������� ��ȣ ��ȯ

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            //��ġ�� �Ͼ �������� ray�� ��
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                //spawnObject.GetComponent<Rigidbody>().useGravity = true;
                //������ ����
                if (!spawnObject)
                {
                    //playObject�� hitPose(��ġ)�� �ڸ�(position)�� ��ġ(rotation)��Ų��
                    spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
                    Vector3 lookAtPosition = spawnObject.transform.position; //����� �ٶ󺸱�
                    lookAtPosition.x = _camObj.transform.position.x; //����� �ٶ󺸱�
                    lookAtPosition.z = _camObj.transform.position.z; //����� �ٶ󺸱�
                    transform.LookAt(lookAtPosition); //����� �ٶ󺸱�
                }
                
                //��ġ�� �ٲ��ֱ�
                else
                {
                    //��ġ�� rotation�� ������Ʈ
                    spawnObject.transform.position = hitPose.position;
                    spawnObject.transform.rotation = hitPose.rotation;
                    Vector3 lookAtPosition = spawnObject.transform.position; //����� �ٶ󺸱�
                    lookAtPosition.x = _camObj.transform.position.x; //����� �ٶ󺸱�
                    lookAtPosition.z = _camObj.transform.position.z; //����� �ٶ󺸱�
                    spawnObject.transform.LookAt(lookAtPosition); //����� �ٶ󺸱�
                }
            }
        }
    }
}
