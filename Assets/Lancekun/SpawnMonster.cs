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
            // �ð� ���� �Լ�

            // void Invoke(string name, float time)
            // time�� �Ŀ� name  �޼ҵ� ȣ��
            Invoke("Spawn", 0.5f);
        }
        else if (Input.GetKeyDown("2"))
        {
            // �ݺ� ��ȯ
            // 1�� �Ŀ� 2�ʸ��� ����
            InvokeRepeating("Spawn", 1.0f, 2.0f);
        }
        else if (Input.GetKeyDown("3")) 
        {
            // ȣ�� ���
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
        // �ǽð����� �������� �����Ͽ� ������Ʈ ����

        GameObject obj = Instantiate(monObj);   
        Vector3 randPos;    // ���� ��ġ

        randPos.x = Random.Range(-0.2f, 0.2f);
        randPos.y = 0;
        randPos.z = Random.Range(-0.2f, 0.2f);

        // 0���� 359������ ��(360 ����X)
        float randDeg = Random.Range(0, 360);  

        obj.transform.position = transform.position + randPos;
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0);

    }
}
