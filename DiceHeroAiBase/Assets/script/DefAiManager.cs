using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefAiManager : MonoBehaviour
{

    public int attChace;
    public int defChace;
    public int moveChace;
    public List<GameObject> Units = new List<GameObject>();
    public List<GameObject> dirUnits = new List<GameObject>();
    public GameObject[] units;

    //public GameObject[] attackUnits = new GameObject[3];
    //int num = 0;
    private void Start()
    {
        units = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject unit in units)
            Units.Add(unit);


        EnemyAi();
    }
    private void Update()
    {

    }

    void EnemyAi()
    {

        if (defChace > 0)
        {
            foreach (GameObject unit in Units)
            {
                //여기서 hp를 받아서 백분율을 낸다.(지금은 아직 백분율 안함)
                double maxHp = unit.GetComponent<UnitState>().maxhp;
                double curHp = unit.GetComponent<UnitState>().curhp;


                if (curHp / maxHp * 100.0 > 30)//체력 30% 이상.
                {
                    dirUnits.Add(unit);
                }

            }
            if (dirUnits.Count == 0)
            {
                dirUnits.Add(Units[0]);//제일 처음꺼 아니면 랜덤으로 할 예정
            }

            DefDis();

        }
        //Debug.Log(units[1].gameObject.name);
        if (attChace > 0)
        {
            foreach (GameObject unit in Units)
            {
                //여기서 hp를 받아서 백분율을 낸다.(지금은 아직 백분율 안함)
                double maxHp = unit.GetComponent<UnitState>().maxhp;
                double curHp = unit.GetComponent<UnitState>().curhp;


                if (curHp / maxHp * 100.0 > 25)//체력 25% 이상.
                {
                    //누가 통과했는지 확인하고 공격가능 인원 한번더 구분함.
                    //Debug.Log("1차공격가능 인원 :" + unit);

                    //attackUnits[num] = unit; 
                    //num++;
                    dirUnits.Add(unit);
                }

            }
            if (dirUnits.Count == 0)
            {
                dirUnits.Add(Units[0]);//제일 처음꺼 아니면 랜덤으로 할 예정
            }
            attackDis();

        }
        else if (defChace > 0)
        {
            foreach (GameObject unit in Units)
            {
                //여기서 hp를 받아서 백분율을 낸다.(지금은 아직 백분율 안함)
                double maxHp = unit.GetComponent<UnitState>().maxhp;
                double curHp = unit.GetComponent<UnitState>().curhp;


                if (curHp / maxHp * 100.0 > 30)//체력 30% 이상.
                {
                    dirUnits.Add(unit);
                }

            }
            if (dirUnits.Count == 0)
            {
                dirUnits.Add(Units[0]);//제일 처음꺼 아니면 랜덤으로 할 예정
            }

            DefDis();

        }
        else if (moveChace > 0)
        {

            moveDis();

        }
        else
        {
            Debug.Log("이제 주사위 없음");
        }
    }


    void attackDis()
    {
        attChace--;
        int maxAtt = 0;
        GameObject dicAtt = units[0];
        foreach (GameObject attUnit in dirUnits)//여기서 공격순으로 정렬
        {
            if (maxAtt < attUnit.gameObject.GetComponent<UnitState>().att)
            {

                maxAtt = attUnit.GetComponent<UnitState>().att;
                dicAtt = attUnit;

            }

        }
        Debug.Log("공격선택 : " + dicAtt.GetComponent<UnitState>().unitName);
        Units.Remove(dicAtt);
        dirUnits.Clear();

        EnemyAi();
    }

    void DefDis()
    {
        defChace--;
        int maxDef = 0;
        GameObject dicAtt = units[0];
        foreach (GameObject defUnit in dirUnits)//여기서 공격순으로 정렬
        {
            if (maxDef < defUnit.gameObject.GetComponent<UnitState>().def)
            {

                maxDef = defUnit.GetComponent<UnitState>().def;
                dicAtt = defUnit;

            }

        }
        Debug.Log("방어선택 : " + dicAtt.GetComponent<UnitState>().unitName);
        Units.Remove(dicAtt);
        dirUnits.Clear();

        EnemyAi();
    }
    void moveDis()
    {
        moveChace--;
        Debug.Log("이동선택 : " + Units[0].GetComponent<UnitState>().unitName);
        Units.Remove(Units[0]);
        EnemyAi();

    }


}


