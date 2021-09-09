using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Vector3 dir;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
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
