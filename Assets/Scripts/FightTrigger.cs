using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Editor;

public class FightTrigger : MonoBehaviour
{
    [SerializeField] string tagFilter;
    [SerializeField] private GameObject[] walls;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] private Transform place;

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
       
    }
}
