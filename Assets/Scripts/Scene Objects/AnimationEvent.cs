using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private Player player;

    private void AttackEvent() => player.PlayerCombat.Attack();
}
