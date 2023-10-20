using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCube : MonoBehaviour
{
    Vector3 oldMouse;
    Vector3 oldCube;
    bool isHit = false;
    GameObject cube;
    public GameObject a, b,img,jdt;
    GameObject hand;
    // Use this for initialization
    void Start()
    {
        hand = GameObject.Find("hand");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) )
            {
                hand.SetActive(false);
                isHit = true;
                cube = hit.collider.gameObject;
                oldMouse = Input.mousePosition;
                oldCube = Camera.main.WorldToScreenPoint(hit.collider.transform.position);//世界坐标转化屏幕坐标
                img.SetActive(true);
                //StartCoroutine("a");
                //a.GetComponent<Rto>().enabled = true;
                //b.GetComponent<Rto>().enabled = true;
            }
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    b.GetComponent<Rto>().enabled = false;
        //    a.GetComponent<Rto>().enabled = false;

        //    isHit = false;
        //}
        if (isHit)
        {   
            Vector3 offset = Input.mousePosition - oldMouse;//鼠标偏移量
            Vector3 cubeOffset = oldCube + offset;
            cube.transform.position = Camera.main.ScreenToWorldPoint(cubeOffset);//屏幕坐标转化成世界坐标
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        img.SetActive(false);
        jdt.SetActive(true);
        ImgFill.instance.isopen = true;
        a.GetComponent<Rto>().enabled = true;
        b.GetComponent<Rto>().enabled = true;

    }
    private void OnTriggerExit(Collider other)
    {
                a.GetComponent<Rto>().enabled = false;
        jdt.SetActive(false);
        ImgFill.instance.isopen = false;
        b.GetComponent<Rto>().enabled = false;
        a.GetComponent<Rto>().enabled = false;

        b.GetComponent<Rto>().enabled = false;

    }
}

