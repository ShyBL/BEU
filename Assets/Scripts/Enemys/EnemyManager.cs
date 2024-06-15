using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyInfo[] allEnemies;
    [SerializeField] private List<EnemyData> currentEnemies;
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private Path path;

    private int spawnPointNum;
    private const float LEVEL_MODIFIER = 0.5F;

    private void Start()
    {
        spawnPointNum = SpawnPoints.Length;
        GenerateEnemyByName("EvilCube", 1);


    }
    private void GenerateEnemyByName(string enemyName, int Level)
    {
        for (int i = 0; i < allEnemies.Length; i++)
        {
            if (enemyName == allEnemies[i].EnemyName)
            {
                EnemyData newEnemy = new EnemyData();
                newEnemy.EnemyName = allEnemies[i].EnemyName;
                newEnemy.Level = Level;
                float levelModifier = (LEVEL_MODIFIER * newEnemy.Level);
                newEnemy.MaxHealth = Mathf.RoundToInt(allEnemies[i].BaseHealth + (allEnemies[i].BaseHealth * levelModifier));
                newEnemy.CurrHealth = newEnemy.MaxHealth;
                newEnemy.Strength = Mathf.RoundToInt(allEnemies[i].BaseStr + (allEnemies[i].BaseStr * levelModifier));
                newEnemy.EnemyVisualPrefab = allEnemies[i].EnemyBattleVisualPrefeb;
                newEnemy.stateMachine = allEnemies[i].stateMachine;
                newEnemy.agent = allEnemies[i].agent;
                currentEnemies.Add(newEnemy);

            }
        }
    }
    public List<EnemyData> GetCurrentEnemies()
    {
        return currentEnemies;
    }

    public void  SpawnEnemys()
    {
       
        for (int i = 0;i < currentEnemies.Count; i++)
        {
            Instantiate(currentEnemies[i].EnemyVisualPrefab, SpawnPoints[i].position,Quaternion.identity);
            currentEnemies[i].path = path;
            currentEnemies[i].stateMachine.Initialized();

        }
    }
}


[System.Serializable]
public class EnemyData
{
    public string EnemyName;
    public int Level;
    public int CurrHealth;
    public int MaxHealth;
    public int Strength;
    public GameObject EnemyVisualPrefab;
    public EnemyStatemachine stateMachine;
    public NavMeshAgent agent;
    public Path path;
}
