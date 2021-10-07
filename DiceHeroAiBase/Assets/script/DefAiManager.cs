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
                //���⼭ hp�� �޾Ƽ� ������� ����.(������ ���� ����� ����)
                double maxHp = unit.GetComponent<UnitState>().maxhp;
                double curHp = unit.GetComponent<UnitState>().curhp;


                if (curHp / maxHp * 100.0 > 30)//ü�� 30% �̻�.
                {
                    dirUnits.Add(unit);
                }

            }
            if (dirUnits.Count == 0)
            {
                dirUnits.Add(Units[0]);//���� ó���� �ƴϸ� �������� �� ����
            }

            DefDis();

        }
        //Debug.Log(units[1].gameObject.name);
        if (attChace > 0)
        {
            foreach (GameObject unit in Units)
            {
                //���⼭ hp�� �޾Ƽ� ������� ����.(������ ���� ����� ����)
                double maxHp = unit.GetComponent<UnitState>().maxhp;
                double curHp = unit.GetComponent<UnitState>().curhp;


                if (curHp / maxHp * 100.0 > 25)//ü�� 25% �̻�.
                {
                    //���� ����ߴ��� Ȯ���ϰ� ���ݰ��� �ο� �ѹ��� ������.
                    //Debug.Log("1�����ݰ��� �ο� :" + unit);

                    //attackUnits[num] = unit; 
                    //num++;
                    dirUnits.Add(unit);
                }

            }
            if (dirUnits.Count == 0)
            {
                dirUnits.Add(Units[0]);//���� ó���� �ƴϸ� �������� �� ����
            }
            attackDis();

        }
        else if (defChace > 0)
        {
            foreach (GameObject unit in Units)
            {
                //���⼭ hp�� �޾Ƽ� ������� ����.(������ ���� ����� ����)
                double maxHp = unit.GetComponent<UnitState>().maxhp;
                double curHp = unit.GetComponent<UnitState>().curhp;


                if (curHp / maxHp * 100.0 > 30)//ü�� 30% �̻�.
                {
                    dirUnits.Add(unit);
                }

            }
            if (dirUnits.Count == 0)
            {
                dirUnits.Add(Units[0]);//���� ó���� �ƴϸ� �������� �� ����
            }

            DefDis();

        }
        else if (moveChace > 0)
        {

            moveDis();

        }
        else
        {
            Debug.Log("���� �ֻ��� ����");
        }
    }


    void attackDis()
    {
        attChace--;
        int maxAtt = 0;
        GameObject dicAtt = units[0];
        foreach (GameObject attUnit in dirUnits)//���⼭ ���ݼ����� ����
        {
            if (maxAtt < attUnit.gameObject.GetComponent<UnitState>().att)
            {

                maxAtt = attUnit.GetComponent<UnitState>().att;
                dicAtt = attUnit;

            }

        }
        Debug.Log("���ݼ��� : " + dicAtt.GetComponent<UnitState>().unitName);
        Units.Remove(dicAtt);
        dirUnits.Clear();

        EnemyAi();
    }

    void DefDis()
    {
        defChace--;
        int maxDef = 0;
        GameObject dicAtt = units[0];
        foreach (GameObject defUnit in dirUnits)//���⼭ ���ݼ����� ����
        {
            if (maxDef < defUnit.gameObject.GetComponent<UnitState>().def)
            {

                maxDef = defUnit.GetComponent<UnitState>().def;
                dicAtt = defUnit;

            }

        }
        Debug.Log("���� : " + dicAtt.GetComponent<UnitState>().unitName);
        Units.Remove(dicAtt);
        dirUnits.Clear();

        EnemyAi();
    }
    void moveDis()
    {
        moveChace--;
        Debug.Log("�̵����� : " + Units[0].GetComponent<UnitState>().unitName);
        Units.Remove(Units[0]);
        EnemyAi();

    }


}


