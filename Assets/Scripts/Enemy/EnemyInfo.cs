using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "New Enemy")]
public class EnemyInfo : ScriptableObject
{
    public string EnemyName;
    public int StartingLevel;
    public int BaseHealth;
    public int BaseStr;
    public GameObject EnemyBattleVisualPrefeb;     //What will be Displayed 
    public EnemyStatemachine stateMachine;
    public NavMeshAgent agent;
    

}