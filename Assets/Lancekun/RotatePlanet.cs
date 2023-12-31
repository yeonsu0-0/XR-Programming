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
        print("타겟 이미지 발견");
        // enabled = true; // 스크립트 활성화
        gameObject.SetActive(true);
    }

    public void OnTargetLost()
    {
        print("타겟 이미지 없음");
        // enabled = false; // 스크립트 비활성화
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
