using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    enum State
    {
        Move,
        Spin,
        Zoom
    }

    public Text stateText;
    Vector3 prePos;
    State curState = State.Move;

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� ��ġ�� ���콺 Ŀ�� ��ġ��!
        if(Input.GetMouseButtonDown(0))
        {
            prePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaPos = Input.mousePosition - prePos;

            switch (curState) {
                case State.Move:
                    deltaPos *= (Time.deltaTime * 0.1f);
                    transform.Translate(deltaPos.x, 0, deltaPos.y, Space.World);
                    break;

                case State.Spin:
                    deltaPos *= (Time.deltaTime * 10);
                    transform.Rotate(deltaPos.y, -deltaPos.x, 0, Space.World);
                    break;

                case State.Zoom:
                    deltaPos *= (Time.deltaTime * 0.1f);
                    transform.localScale += deltaPos;
                    break;
            }
        }
        prePos = Input.mousePosition;

    }

    public void OnClickMove(string name)
    {
        curState = State.Move;
        stateText.text = name;
    }

    public void OnClickSpin(string name)
    {
        curState = State.Spin;
        stateText.text = name;
    }

    public void OnClickZoom(string name)
    {
        curState = State.Zoom;
        stateText.text = name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
            print("�浹 ����");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
            print("�浹 ����");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
            print("�浹 ����");
    }
}
