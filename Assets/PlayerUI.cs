using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;
    [SerializeField] private Slider healthSlider;
    
    [Header(" Actions ")]
    public Action<float> onGetHit;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        onGetHit += UpdateHealth;
    }

    private void OnDestroy()
    {
        onGetHit -= UpdateHealth;
    }

    private void Start()
    {
        healthSlider.maxValue = Player.Instance.PlayerCombat.MaxHealth;
        healthSlider.value = healthSlider.maxValue;
    }

    void UpdateHealth(float amount)
    {
        var temp = healthSlider.value;
        healthSlider.value = temp - amount;
    }
}
