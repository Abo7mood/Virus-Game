
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarFade3 : MonoBehaviour
{
    [SerializeField] Collider2D[] turnoffcollider;
   [SerializeField] Animator anim;
    HealthBarFade1 fade1;
    private const float DAMAGED_HEALTH_FADE_TIMER_MAX = .6f;
    public float MaxHealth = 100f;
    private Image barImage;
    private Image damagedBarImage;
    private Color damagedColor;
    private float damagedHealthFadeTimer;
    private HealthSystem2 healthSystem;

    private void Awake()
    {
        fade1 = FindObjectOfType<HealthBarFade1>();
        healthSystem = GetComponent<HealthSystem2>();
        barImage = transform.Find("Fade2").GetComponent<Image>();
        damagedBarImage = transform.Find("BackGround2").GetComponent<Image>();
        damagedColor = damagedBarImage.color;
        damagedColor.a = 0f;
        damagedBarImage.color = damagedColor;
        turnoffcollider = anim.gameObject.GetComponentsInChildren<Collider2D>();
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
        //if (Input.GetKey(KeyCode.B))
        //    fade1.Damage(1);
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
        //if (Input.GetKeyDown(KeyCode.P))
        //    Damage(10);
    }

    private void HealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(healthSystem.GetHealthNormalized());
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
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

            
            for (int i = 0; i < turnoffcollider.Length; i++)
            {
                turnoffcollider[i].enabled = false;
            }
            fade1.Damage(1);
            Destroy(anim.gameObject, 1f);

           anim.SetTrigger("Dead");
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
