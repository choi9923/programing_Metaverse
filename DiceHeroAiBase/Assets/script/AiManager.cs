using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiManager : MonoBehaviour
{

    public GameObject[] units;
    public GameObject[] attackUnits = new GameObject[4];
    int num = 0;
    private void Start()
    {
        units = GameObject.FindGameObjectsWithTag("Enemy");

        EnemyAi();
    }
    private void Update()
    {
        
    }

    void EnemyAi()
    {

        Debug.Log(units[1].gameObject.name);
        
        foreach (GameObject unit in units)
        {
            //여기서 hp를 받아서 백분율을 낸다.(지금은 아직 백분율 안함)
            int perHp = unit.GetComponent<UnitState>().hp;


            if (perHp> 25)//체력 25% 이상.
            {
                //누가 통과했는지 확인하고 공격가능 인원 한번더 구분함.
                Debug.Log("1차공격가능 인원 :" + unit);
                //여기서 어떻게 함? 도와줘.
                attackUnits[0] = unit; //indexOutOfRangeException 오류 뜸ㅋ
                num++;
                

                attackDis();
            }
            else
            {
                
            }
        }

        num = 0;
    }
    void attackDis()
    {

    }



}
