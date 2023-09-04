using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//당근이랑 부딫였을때 먹는 애니메이션
public class Eat1 : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        //animator component가져오기
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //tag가 Carrot인 object가 부딫였을때 애니메이션 활성화
        if (other.gameObject.tag == "Carrot")
        {
            anim.SetTrigger("EatTrigger");
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.tag == "Carrot")
    //    {
    //        animator.Play("Eat", -1, 0);
    //    }
    //}
}
