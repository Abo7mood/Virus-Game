
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarFade1 : MonoBehaviour
{
    private float HealthPercentage;
    private const float DAMAGED_HEALTH_FADE_TIMER_MAX = .6f;
    public float MaxHealth = 100f;
    private Image barImage;
    private Image damagedBarImage;
    private Color damagedColor;
    private float damagedHealthFadeTimer;
    private HealthSystem1 healthSystem;
    public Phases state;
    [SerializeField] GameObject[] IndustrialAnimations;
    Adds _adds;
   public enum Phases
    {
        idle,
        Angry,
        SuperAngry,
    }

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem1>();
        barImage = transform.Find("Fade1").GetComponent<Image>();
        damagedBarImage = transform.Find("BackGround1").GetComponent<Image>();
        damagedColor = damagedBarImage.color;
        damagedColor.a = 0f;
        damagedBarImage.color = damagedColor;
        IndustrialAnimations = GameObject.FindGameObjectsWithTag("Hammer");
        _adds = FindObjectOfType<Adds>().GetComponent<Adds>();
    }

    private void Start()
    {
        healthSystem.SetUp(MaxHealth);
        SetHealth(healthSystem.GetHealthNormalized());
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnHealed += HealthSystem_OnHealed;
        
    }

    private void Update()
    {
        stateswitcher();
        stateActivator();
        if (damagedColor.a > 0)
        {
            damagedHealthFadeTimer -= Time.deltaTime;
            if (damagedHealthFadeTimer < 0)
            {
                float fadeAmount = 5f;
                damagedColor.a -= fadeAmount * Time.deltaTime;
                damagedBarImage.color = damagedColor;
            }
        }
       
    }


    private void stateswitcher()
    {
        if (HealthPercentage > 66)
        {
            state = Phases.idle;
        }
        else if (HealthPercentage < 66 && HealthPercentage > 33)
        {
            state = Phases.Angry;

        }
        else if (HealthPercentage < 33 &&HealthPercentage >0 )
        {
            state = Phases.SuperAngry;

        }
        else { return; }



    }
    private void stateActivator()
    {
        switch (state)
        {
            default:

            case Phases.idle:
                break;
            case Phases.Angry:
                for (int i = 0; i < IndustrialAnimations.Length; i++)
                {
                    IndustrialAnimations[i].GetComponent<Animator>().enabled = true;
                }
                LevelManager.instance.SpawnTime = 7;
                break;

            case Phases.SuperAngry:
              
                LevelManager.instance.CanSpawnBoom = true;
               


                break;

        }


    }
    private void HealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(healthSystem.GetHealthNormalized());
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        HealthPercentage = (this.healthSystem.healthAmount / MaxHealth) * 100;
      
        if (damagedColor.a <= 0)
        {
            // Damaged bar image is invisible
            damagedBarImage.fillAmount = barImage.fillAmount;
        }
        damagedColor.a = 1;
        damagedBarImage.color = damagedColor;
        damagedHealthFadeTimer = DAMAGED_HEALTH_FADE_TIMER_MAX;

        SetHealth(healthSystem.GetHealthNormalized());
    }
  

    private void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
        if (this.healthSystem.healthAmount <= 0)
        {
            _adds.StartGame();
            LevelManager.instance.DestroyAll();
            Destroy(gameObject, 3f);
           
        }
           
    }
    public void Damage(int SetDamage)
    {
        healthSystem.Damage(SetDamage);
    }
    public void Health(int SetHealth)
    {
        healthSystem.Heal(SetHealth);
    }
}
