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
                attackUnits[num] = unit; //indexOutOfRangeException 오류 뜸ㅋ
                num++;             
            }
            
        }
        num = 0;
        attackDis();
    }

    void attackDis()
    {
        GameObject chgUnit;

        foreach(GameObject attUnit in attackUnits)//여기서 공격순으로 정렬
        {
            foreach(GameObject attUnit2 in attackUnits)
            {
                Debug.Log("실행됨");

                if (attackUnits[num].GetComponent<UnitState>().hp < attackUnits[num+1].GetComponent<UnitState>().hp)                                                                        
                {

                    Debug.Log(attackUnits[num] + "->" + attackUnits[num + 1]);

                    chgUnit = attackUnits[num];
                    attackUnits[num] = attackUnits[num + 1];
                    attackUnits[num + 1] = chgUnit;

                   
                }
            }         

        }
    }



}
