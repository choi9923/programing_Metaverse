using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    static public PlayerControll instance;
    public Vector3 dir;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
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
    }
    private void Move()
    {      
        transform.position += dir * speed * Time.deltaTime;

    }
}
