using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetTr;
    public float rotSpped;

    Transform tr;

    public void OnTargetFount()
    {
        print("Ÿ�� �̹��� �߰�");
        // enabled = true; // ��ũ��Ʈ Ȱ��ȭ
        gameObject.SetActive(true);
    }

    public void OnTargetLost()
    {
        print("Ÿ�� �̹��� ����");
        // enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.RotateAround(targetTr.position, Vector3.up, Time.deltaTime * rotSpped);
    }
}
