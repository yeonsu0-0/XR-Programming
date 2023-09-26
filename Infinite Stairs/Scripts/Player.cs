using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;
    private Vector3 oldPosition;
    private bool isTurn = false;

    private int moveCount = 0;
    private int turnCount = 0;
    private int spawnCount = 0;
    private bool isDie = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            CharTurn();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            CharMove();
        }
    }

    private void Init()
    {
        anim.SetBool("Die", false);
        moveCount = 0;
        spawnCount = 0;
        turnCount = 0;
        isTurn = false;
        spriteRenderer.flipX = false;
        isDie = false;
    }

    private void CharTurn()
    {
        isTurn = isTurn == true ? false : true;
        spriteRenderer.flipX = isTurn;
    }

    private void CharMove()
    {
        moveCount++;
        MoveDirection();
        
        // »ç¸Á ÆÇÁ¤
        if(isFailTurn())
        {
            CharDie();
            Debug.Log("À¸¾Ó Áê±Ý");
            return;
        }

        if(moveCount > 5)
        {
            RespawnStair();
        }
    }

    private void MoveDirection()
    {
        if (isTurn)
        {
            oldPosition += new Vector3(-0.75f, 0.5f, 0);
        }
        else
        {
            oldPosition += new Vector3(0.75f, 0.5f, 0);
        }

        transform.position = oldPosition;
        anim.SetTrigger("Move");
    }

    private bool isFailTurn()
    {
        bool result = false;

        if (GameManager.Instance.isTurn[turnCount] != isTurn)
        {
            result = true;
        }

        turnCount++;

        if(turnCount > GameManager.Instance.Stairs.Length - 1)
        {
            turnCount = 0;
        }


        return result;
    }

    private void RespawnStair()
    {
        GameManager.Instance.SpawnStair(spawnCount);
        spawnCount++;
        
        if(spawnCount > GameManager.Instance.Stairs.Length - 1)
        {
            spawnCount = 0;
        }
    }

    private void CharDie()
    {
        anim.SetBool("Die", true);
        isDie = true;
    }
}
