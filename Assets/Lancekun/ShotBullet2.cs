using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet2 : MonoBehaviour

{
    public GameObject bulletObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shot(transform.forward);
            Shot(-transform.forward);
            Shot(transform.right);
            Shot(-transform.right);
            Shot(transform.up);
            Shot(-transform.up);
        }
    }

    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        obj.GetComponent<BulletMove>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }

    public void OnClickBtn1()
    {
        Shot(transform.forward + transform.right);
        Shot(transform.forward - transform.right);
    }

    public void OnClickBtn2()
    {
        Shot(-transform.forward + transform.right);
        Shot(-transform.forward - transform.right);
    }
}
