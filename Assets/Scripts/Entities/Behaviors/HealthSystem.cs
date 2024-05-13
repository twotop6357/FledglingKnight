using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;
    private CharacterStatHandler statHandler;
    private float timeSinceLastChange = float.MaxValue;
    private bool isAttacked = false;
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;
    [SerializeField] private Image hpBar;

    public float CurrentHealth {  get; private set; }

    public float MaxHealth => statHandler.CurrentStat.maxHealth;

    private void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
    }
    private void Start()
    {
        CurrentHealth = MaxHealth;
        if (this.tag == "Player" && hpBar != null)
        {
            hpBar.fillAmount = CurrentHealth * 0.1f;
        }
    }
    private void Update()
    {
        if(isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if(timeSinceLastChange >= healthChangeDelay ) 
            {
                OnInvincibilityEnd?.Invoke();
                isAttacked = false;
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if(timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }
        timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        if(this.tag == "Player")
        {
            hpBar.fillAmount = CurrentHealth * 0.1f;
        }
        if (CurrentHealth <= 0f)
        {
            CallDeath();
            return true;
        }
        if (change >= 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
        }
        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}