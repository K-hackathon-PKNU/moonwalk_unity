using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//터치하는곳에 러닝메이트 위치시키기
public class ArPlaceOnPlane : MonoBehaviour
{
    public Transform _camObj;
    public ARRaycastManager arRaycaster; //선언
    public GameObject placeObject; //object선언
    GameObject spawnObject;

    public Vector3 dir;

    void Update()
    {
        
        {
            PlaceObjectByTouch();
        }

        //UpdateCenterObject(); //카메라앞에서 너무 알짱거림
        //if (Input.touchCount == 3)
        //{
        //    Destroy(spawnObject);
        //    PlaceObjectByTouchtoCenter();
        //}


    }
    void PlaceObjectByTouch()
    {
        //스마트폰스크린에 터치여부
        if (Input.touchCount ==1)
        {
            Touch touch = Input.GetTouch(0);//GetTouch : 손가락순서대로 번호 반환

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            //터치가 일어난 방향으로 ray를 쏨
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                //spawnObject.GetComponent<Rigidbody>().useGravity = true;
                //여러대 방지
                if (!spawnObject)
                {
                    //playObject를 hitPose(터치)한 자리(position)에 위치(rotation)시킨다
                    spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
                    Vector3 lookAtPosition = spawnObject.transform.position; //사용자 바라보기
                    lookAtPosition.x = _camObj.transform.position.x; //사용자 바라보기
                    lookAtPosition.z = _camObj.transform.position.z; //사용자 바라보기
                    transform.LookAt(lookAtPosition); //사용자 바라보기
                }
                
                //위치만 바꿔주기
                else
                {
                    //위치와 rotation만 업데이트
                    spawnObject.transform.position = hitPose.position;
                    spawnObject.transform.rotation = hitPose.rotation;
                    Vector3 lookAtPosition = spawnObject.transform.position; //사용자 바라보기
                    lookAtPosition.x = _camObj.transform.position.x; //사용자 바라보기
                    lookAtPosition.z = _camObj.transform.position.z; //사용자 바라보기
                    spawnObject.transform.LookAt(lookAtPosition); //사용자 바라보기
                }
            }
        }
    }
}
