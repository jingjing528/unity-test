using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgFill : MonoBehaviour
{
    public Material a, b, c;
    public Image img;
    public static ImgFill instance;
    public bool isopen = false;
    public GameObject lizi,bbb,v,s,blender;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        blender = GameObject.Find("blender");
    }
    public void aaa()
    {
        lizi.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (isopen)
        {   
            img.fillAmount += Time.deltaTime * 0.4f;
            if (img.fillAmount >= 1)
            {
                blender.transform.position = Vector3.MoveTowards(blender.transform.position,new Vector3( -0.324f,0.1909f,-0.468f),1f);
                this.GetComponent<Collider>().enabled = false;
                this.GetComponent<MeshRenderer>().material = c;
                bbb.SetActive(false);
                lizi.SetActive(true);
                Invoke("aaa", 1f);
                v.GetComponent<Rto>().enabled = false;
                s.GetComponent<Rto>().enabled = false;

            }
            else
            {
                this.GetComponent<MeshRenderer>().material = b;

            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = a;


        }
    }
}
