using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{

    // Start is called before the first frame update

    public Space mySpace;

    Vector3 prePos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���콺�� ������ �ִٸ�
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            // �������� ū�ϳ� !!!!
            deltaPos *= (Time.deltaTime * 10);

            transform.Rotate(deltaPos.y - deltaPos.x, 0, (float)mySpace);
        }

        prePos = Input.mousePosition;
    }
}