using UnityEngine;
using Cinemachine;

public class FightTrigger : MonoBehaviour
{
    [SerializeField] string tagFilter;
    [SerializeField] private GameObject[] walls;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] private Transform place;
    [SerializeField] private Enemy[] enemies;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (CheckEnemies())
        {
            ResetWalls();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //chack if only player set in
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
            return;
        
        // genarate walls
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.SetActive(true);
        }
        
        // set camre in place
        if(cam.Follow != null)
        {
            cam.Follow = place;
        }
        
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].stateMachine.ChangeState(new AttackState());
        }
       
    }
    private bool CheckEnemies()
    {
        int enemiesAlive = enemies.Length;
        for (int i = 0;i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                if (!enemies[i].IsAlive)
                {
                    enemiesAlive--;
                }
            }
        }
        if(enemiesAlive <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    } 
    private void ResetWalls()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.SetActive(false);
        }
        if (cam.Follow != null)
        {
            cam.Follow = player.transform;
        }

    }
}