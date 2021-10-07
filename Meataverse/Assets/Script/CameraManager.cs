using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;
    public GameObject target;//카메라가 따라갈 대상
    public float moveSpeed;//카메라가 얼마나 빠른 속도로
    public Vector3 targetPosition; //대상의 현재 위치값

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
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
        if(target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position,targetPosition,moveSpeed * Time.deltaTime);

        }
    }
}
