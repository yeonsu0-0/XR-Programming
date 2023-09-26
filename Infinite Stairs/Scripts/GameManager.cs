using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameManager : MonoBehaviour
{
    // Instance ���� ����(�ٸ� ��ũ��Ʈ������ ���� ����)
    public static GameManager Instance;

    // Inspector���� �ش� ���� �׷��� ��� ����
    [Header("���")]
    [Space(10)]

    // ��� ������Ʈ���� �����ϴ� �迭
    public GameObject[] Stairs;

    public bool[] isTurn;

    private enum State { Start, Left, Right };
    private State state;
    private Vector3 oldPosition;

    void Start()
    {
        Instance = this;
        Init();
        InitStairs();
    }

    private void Init()
    {
        state = State.Start;
        oldPosition = Vector3.zero;
        isTurn = new bool[Stairs.Length];

        for (int i = 0; i < isTurn.Length; i++)
        {
            Stairs[i].transform.position = Vector3.zero;
            isTurn[i] = false;
        }

    }

    private void InitStairs()
    {
        for (int i = 0; i < Stairs.Length; i++)
        {
            switch(state)
            {
                case State.Start:
                    Stairs[i].transform.position = new Vector3(0.75f, -0.1f, 0);
                    state = State.Right;
                    break;

                case State.Left:
                    Stairs[i].transform.position = oldPosition + new Vector3(-0.75f, 0.5f, 0);
                    isTurn[i] = true;
                    break;

                case State.Right:
                    Stairs[i].transform.position = oldPosition + new Vector3(0.75f, 0.5f, 0);
                    isTurn[i] = false;
                    break;

            }
            oldPosition = Stairs[i].transform.position;

            if(i != 0)  // ù ��° ��� ����
            {
                int ran = Random.Range(0, 5);

                if (ran < 2 && i < Stairs.Length - 1)   // 0 �Ǵ� 1�� �� ��
                {
                    state = state == State.Left ? State.Right : State.Left;
                }
            }
        }
    }

    public void SpawnStair(int count)
    {
        int ran = Random.Range(0, 5);

        if(ran < 2)
        {
            state = state == State.Left ? State.Right : State.Left;
        }

        switch (state)
        {
            case State.Left:
                Stairs[count].transform.position = oldPosition + new Vector3(-0.75f, 0.5f, 0);
                isTurn[count] = true;
                break;

            case State.Right:
                Stairs[count].transform.position = oldPosition + new Vector3(0.75f, 0.5f, 0);
                isTurn[count] = false;
                break;
        }
        oldPosition = Stairs[count].transform.position;
    }
}
