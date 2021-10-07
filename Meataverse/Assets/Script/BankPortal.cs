using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BankPortal : MonoBehaviour
{
    public string MapName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(MapName);
        }
    }
    // Update is called once per frame

}
