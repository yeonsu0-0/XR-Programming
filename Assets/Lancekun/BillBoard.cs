using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform camTr;
    Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // LateUpdate
    // 카메라의 경우 다른 오브젝트들이 다 구현된 뒤에 불러오는 것이 좋음
    void LateUpdate()
    {
        tr.LookAt(camTr.position);
    }
}
