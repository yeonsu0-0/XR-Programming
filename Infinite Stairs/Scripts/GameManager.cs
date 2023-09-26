using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameManager : MonoBehaviour
{
    // Instance 변수 선언(다른 스크립트에서도 접근 가능)
    public static GameManager Instance;

    // Inspector에서 해당 변수 그룹의 헤더 설정
    [Header("계단")]
    [Space(10)]

    // 계단 오브젝트들을 저장하는 배열
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

            if(i != 0)  // 첫 번째 계단 제외
            {
                int ran = Random.Range(0, 5);

                if (ran < 2 && i < Stairs.Length - 1)   // 0 또는 1일 때 참
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
