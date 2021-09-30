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
            //���⼭ hp�� �޾Ƽ� ������� ����.(������ ���� ����� ����)
            int perHp = unit.GetComponent<UnitState>().hp;


            if (perHp> 25)//ü�� 25% �̻�.
            {
                //���� ����ߴ��� Ȯ���ϰ� ���ݰ��� �ο� �ѹ��� ������.
                Debug.Log("1�����ݰ��� �ο� :" + unit);
                //���⼭ ��� ��? ������.
                attackUnits[num] = unit; //indexOutOfRangeException ���� �䤻
                num++;             
            }
            
        }
        num = 0;
        attackDis();
    }

    void attackDis()
    {
        GameObject chgUnit;

        foreach(GameObject attUnit in attackUnits)//���⼭ ���ݼ����� ����
        {
            foreach(GameObject attUnit2 in attackUnits)
            {
                Debug.Log("�����");

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
