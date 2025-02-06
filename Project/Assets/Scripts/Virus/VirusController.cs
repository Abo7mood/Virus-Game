using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    [SerializeField] HealthBarFade1 fade1;
    [SerializeField] HealthBarFade3 fade3;
   [SerializeField] Animator anim;
    bool isDamaged=false;
    // Start is called before the first frame update
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && isDamaged==false)
        {
            SoundManager.instance.hitvirusSound();
            anim.SetTrigger("Hit");
            fade3.Damage(1);
            StartCoroutine(DamageCooldown());
        }
    }
    private IEnumerator DamageCooldown()
    {
        isDamaged = true;
        yield return new WaitForSeconds(0.05f);
        isDamaged = false;
    }
}
