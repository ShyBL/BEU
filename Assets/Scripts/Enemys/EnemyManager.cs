using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyInfo[] allEnemies;
    [SerializeField] private List<Enemy> currentEnemies;
    [SerializeField] private Transform[] SpawnPoints;

    private int spawnPointNum;
    private const float LEVEL_MODIFIER = 0.5F;

    private void Start()
    {
        spawnPointNum = SpawnPoints.Length;
    }
    private void GenerateEnemyByName(string enemyName, int Level)
    {
        for (int i = 0; i < allEnemies.Length; i++)
        {
            if (enemyName == allEnemies[i].EnemyName)
            {
                Enemy newEnemy = new Enemy();
                newEnemy.EnemyName = allEnemies[i].EnemyName;
                newEnemy.Level = Level;
                float levelModifier = (LEVEL_MODIFIER * newEnemy.Level);
                newEnemy.MaxHealth = Mathf.RoundToInt(allEnemies[i].BaseHealth + (allEnemies[i].BaseHealth * levelModifier));
                newEnemy.CurrHealth = newEnemy.MaxHealth;
                newEnemy.Strength = Mathf.RoundToInt(allEnemies[i].BaseStr + (allEnemies[i].BaseStr * levelModifier));
                newEnemy.EnemyVisualPrefab = allEnemies[i].EnemyBattleVisualPrefeb;


                currentEnemies.Add(newEnemy);

            }
        }
    }
    public List<Enemy> GetCurrentEnemies()
    {
        return currentEnemies;
    }

    public void  SpawnEnemys()
    {
        for(int i = 0;i < currentEnemies.Count; i++)
        {
            GenerateEnemyByName("EvilCube", 1);
            Instantiate(currentEnemies[i].EnemyVisualPrefab, SpawnPoints[i].position,Quaternion.identity);

        }
    }
}


[System.Serializable]
public class Enemy
{
    public string EnemyName;
    public int Level;
    public int CurrHealth;
    public int MaxHealth;
    public int Strength;
    public GameObject EnemyVisualPrefab;
}
