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
    // ī�޶��� ��� �ٸ� ������Ʈ���� �� ������ �ڿ� �ҷ����� ���� ����
    void LateUpdate()
    {
        tr.LookAt(camTr.position);
    }
}
