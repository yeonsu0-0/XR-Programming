using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTranslate : MonoBehaviour
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
        if(Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        prePos = Input.mousePosition;
    }
}
