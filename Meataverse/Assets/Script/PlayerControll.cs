using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    Animator pAnimator;

    static public PlayerControll instance;
    public Vector3 dir;
    public float speed = 10;
    // Start is called before the first frame update

    enum States
    {
        righst = 1,
        left = 2,
        up = 3,
        down = 4,
        idle = 5
            
    }
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        keyInput();
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    void keyInput()
    {
        dir.x = Input.GetAxisRaw("Horizontal");       
        dir.y = Input.GetAxisRaw("Vertical");
        if (dir.x != 0 || dir.y != 0)
        {
            UpdateState();
        }
        else
        {
            pAnimator.SetLayerWeight(1, 1);
        }
        
    }
    private void Move()
    {      
        transform.position += dir * speed * Time.deltaTime;

    }

    private void UpdateState()
    {
        pAnimator.SetLayerWeight(1, 0);
        if (dir.x > 0)
        {
            pAnimator.SetInteger("MoveDir", (int)States.righst);
        }
        else if (dir.x < 0)
        {
            pAnimator.SetInteger("MoveDir", (int)States.left);

        }
        else if (dir.y > 0)
        {

            pAnimator.SetInteger("MoveDir", (int)States.up);
        }
        else if (dir.y < 0)
        {
            pAnimator.SetInteger("MoveDir", (int)States.down);
        }
        
    }

    }
