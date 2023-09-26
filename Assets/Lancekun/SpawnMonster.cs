using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            // 시간 지연 함수

            // void Invoke(string name, float time)
            // time초 후에 name  메소드 호출
            Invoke("Spawn", 0.5f);
        }
        else if (Input.GetKeyDown("2"))
        {
            // 반복 소환
            // 1초 후에 2초마다 생성
            InvokeRepeating("Spawn", 1.0f, 2.0f);
        }
        else if (Input.GetKeyDown("3")) 
        {
            // 호출 취소
            CancelInvoke("Spawn");
        }
        else if (Input.GetKeyDown("4"))
        {
            CancelInvoke();
        }
    }

    void Spawn()
    {
        // Instantiate
        // 실시간으로 프리팹을 복제하여 오브젝트 생성

        GameObject obj = Instantiate(monObj);   
        Vector3 randPos;    // 랜덤 위치

        randPos.x = Random.Range(-0.2f, 0.2f);
        randPos.y = 0;
        randPos.z = Random.Range(-0.2f, 0.2f);

        // 0부터 359까지만 들어감(360 포함X)
        float randDeg = Random.Range(0, 360);  

        obj.transform.position = transform.position + randPos;
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0);

    }
}
