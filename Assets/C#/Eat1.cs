using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����̶� �΋H������ �Դ� �ִϸ��̼�
public class Eat1 : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        //animator component��������
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //tag�� Carrot�� object�� �΋H������ �ִϸ��̼� Ȱ��ȭ
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
