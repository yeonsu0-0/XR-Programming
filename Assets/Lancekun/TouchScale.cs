using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScale : MonoBehaviour
{

    Vector3 prePos;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.localScale += deltaPos;
        }

        prePos = Input.mousePosition;
    }
}