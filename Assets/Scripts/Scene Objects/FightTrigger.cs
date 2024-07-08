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
    private bool doOnce = true;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = player.gameObject.GetComponent<Player>().mainVCamera;
    }
    
    private void Update()
    {
        if (CheckEnemies())
        {
            ResetTriggered();
        }
        
        TriggerEnemies();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!IsPlayer(collider)) return;

        GenerateWalls(true);

        SetCameraForFollowScene(place);

        TriggerEnemies();
    }

    private void TriggerEnemies()
    {
        if (doOnce)
        {
            foreach (var enemy in enemies)
            {
                // Exit the loop once one enemy has been found to have seen the player
                if (enemy.sawPlayer)
                {
                    foreach (var otherEnemy in enemies)
                    {
                        if (otherEnemy != enemy)
                        {
                            otherEnemy.stateMachine.ChangeState(new MoveState());
                        }
                    }

                    doOnce = false;
                    break;
                }
            }
        }
        
    }

    private void SetCameraForFollowScene(Transform followTransform)
    {
        if (cam.Follow != null)
        {
            cam.Follow = followTransform;
        }
    }

    private void GenerateWalls(bool isTriggered)
    {
        foreach (var wall in walls)
        {
            wall.gameObject.SetActive(isTriggered);
        }
    }

    private bool IsPlayer(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && other.gameObject.CompareTag(tagFilter))
            return true;
        return false;
    }

    private bool CheckEnemies()
    {
        var enemiesAlive = enemies.Length;
        
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                if (!enemy.IsAlive)
                {
                    enemiesAlive--;
                }
            }
        }
        return enemiesAlive <= 0;
    } 
    private void ResetTriggered()
    {
        GenerateWalls(false);

        SetCameraForFollowScene(player.transform);
    }
}