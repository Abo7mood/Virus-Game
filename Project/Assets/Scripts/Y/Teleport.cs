using UnityEngine;
using System.Collections;
public class Teleport : MonoBehaviour
{
    
   Animator anim;
    [SerializeField] Transform Target;
    [SerializeField] GameObject _particle;
    Transform Player;
    bool Enter=false;
    float _time=0;
     float speed=1;
    [SerializeField] GameObject TeleportSound;
    GameObject _teleport;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        Invoke("ReferencePlayer", 0.01f);
    }
    private void ReferencePlayer() => Player = FindObjectOfType<PlayerController>().transform;
    private void Update()
    {
       
       
        if (Enter)
        {
            _particle.SetActive(true);
             _time +=Time.deltaTime*speed;
        }else
            _particle.SetActive(false);
        if (_time > 3.4f)
        {
            _time = 0;
            Player.position = Target.position;
            

        }
       

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<PlayerController>().isZoomOut = true;
            Enter = true;      
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            if(_teleport == null)
            {
                _teleport = Instantiate(TeleportSound, transform.position, Quaternion.identity, null);
                Destroy(_teleport, 3.4f);
            }
               

               anim.SetBool("Enter", true);
           

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_teleport != null)
            {
              
                Destroy(_teleport);
            }
            anim.SetBool("Enter", false);
            Enter = false;
            _time = 0;
            Player.GetComponent<PlayerController>().isZoomOut = false;
        }
    }
  
}
