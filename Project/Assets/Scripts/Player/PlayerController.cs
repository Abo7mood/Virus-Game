using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    #region Constructer
    [Header("GameObjects")]
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject CanvasTransform;
    [SerializeField] GameObject Sprite;
    [SerializeField] GameObject DeadPanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject[] HealthImage;
    [SerializeField] GameObject BulletPrefab;
    public GameObject _Weapon;
    public GameObject DeathParticle;
    [Header("References")]
    [SerializeField] GroundCheck groundCheck;
    [SerializeField] HealthBarFade fade;
    [SerializeField] Animator deadanim;
    [SerializeField] Image[] BubbleFill;
    [SerializeField] Image[] BubblesFill;
    [SerializeField] Transform ShootingPoint;
    [SerializeField] Joystick _joystick;
    [SerializeField] Joystick _singleShootJoystick;
    [SerializeField] Joystick _multipleShootJoystick;
    [SerializeField] Button btn;
    BoxCollider2D boxCollider;
    Renderer rend;
    SpriteRenderer mySprite;
    Rigidbody2D rb;
    Animator anim;
    Tween _tween;
    public static PlayerController Instance;
    StageManager _stage;
    PlayerInfo _playerInfo;
    Color c;

 

   

    #endregion

    #region Bool
    [HideInInspector] public bool isDead = false;
    public bool m_FacingRight;
    bool Canmove;
    bool isRunning;
    bool isDamage;
    bool isDamage2;
    bool CanShooting = true;
    bool CanShooting2 = true;
  [HideInInspector] public bool isZoomOut = false;
    bool _isHide;
    bool _isGame;
    bool isJump;
    bool isTransition;
    #endregion

    #region float
    [SerializeField]
    float jump = 10f;
    public float sprint;

    [SerializeField] float PlayerSpeed;
    [SerializeField] float Shoot1Speed;
    [SerializeField] float Shoot2Speed;
    [SerializeField] float TransitionSpeed;
  
    float movX;
    #endregion


    #region int
    int CurrentHealth = -1;
 
    #endregion
    private void Awake()
    {
     
        Instance = this;
        _tween = FindObjectOfType<Tween>().GetComponent<Tween>();
        _stage = FindObjectOfType<StageManager>().GetComponent<StageManager>();
        boxCollider = transform.GetComponent<BoxCollider2D>();
        rend = GetComponentInChildren<Renderer>();
        c = rend.material.color;
        mySprite = GetComponentInChildren<SpriteRenderer>();
        rb = transform.GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        #region MissedReference
        BackGround = GameObject.Find("Background");
        cam = Camera.main.gameObject;
        CanvasTransform = GameObject.Find("PlayerCanvas");
        WinPanel = GameObject.Find("Canvas").transform.Find("WinPanel").gameObject;
        DeadPanel = GameObject.Find("Canvas").transform.Find("DeadPanel").gameObject;
        deadanim = GameObject.Find("Canvas").transform.Find("dead").gameObject.GetComponent<Animator>();
        fade = CanvasTransform.GetComponent<HealthBarFade>();
        #region Health
        HealthImage[0] = GameObject.Find("Canvas").transform.Find("PlayerHealth").transform.GetChild(0).gameObject;
        HealthImage[1] = GameObject.Find("Canvas").transform.Find("PlayerHealth").transform.GetChild(1).gameObject;
        HealthImage[2] = GameObject.Find("Canvas").transform.Find("PlayerHealth").transform.GetChild(2).gameObject;
        #endregion
        #region Joystick
        _singleShootJoystick = GameObject.Find("Canvas").transform.Find("Shoot").
        transform.Find("ShootSingle").GetComponent<Joystick>();

        _multipleShootJoystick = GameObject.Find("Canvas").transform.Find("Shoot").
            transform.Find("ShootMultiple").transform.Find("MultipleShoot").GetComponent<Joystick>();

        _joystick = GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<Joystick>();
        #endregion


        #region Bubbles
        BubbleFill[0] = GameObject.Find("Canvas").transform.Find("Shoot").transform.Find("ShootSingle").transform.Find("Handle")
            .transform.Find("Bubbles").GetComponent<Image>();

        BubblesFill[0] = GameObject.Find("Canvas").transform.Find("Shoot").transform.Find("ShootMultiple").transform.Find("MultipleShoot")
          .transform.Find("Handle").transform.Find("Shoot2Grey").transform.GetChild(0).gameObject.GetComponent<Image>();

        BubblesFill[1] = GameObject.Find("Canvas").transform.Find("Shoot").transform.Find("ShootMultiple").transform.Find("MultipleShoot")
          .transform.Find("Handle").transform.Find("Shoot2Grey").transform.GetChild(1).gameObject.GetComponent<Image>();

        BubblesFill[2] = GameObject.Find("Canvas").transform.Find("Shoot").transform.Find("ShootMultiple").transform.Find("MultipleShoot")
          .transform.Find("Handle").transform.Find("Shoot2Grey").transform.GetChild(2).gameObject.GetComponent<Image>();
        #endregion

        #region Transforms
       LevelManager.instance. backgroundTransform = GameObject.Find("Map").transform.Find("TransformGroup").GetChild(0).transform;
        LevelManager.instance.backgroundTargetTransform = GameObject.Find("Map").transform.Find("TransformGroup").GetChild(1).transform;
        LevelManager.instance.CameraTargetTransform = GameObject.Find("Map").transform.Find("TransformGroup").GetChild(2).transform;
        LevelManager.instance.CameraTransform = GameObject.Find("Map").transform.Find("TransformGroup").GetChild(3).transform;
        #endregion
        #endregion
        btn = GameObject.Find("Canvas").transform.Find("Shoot").transform.Find("MapBackGround").transform.Find("MapButton").
            GetComponent<Button>();
        Button mybtn = btn.GetComponent<Button>();
        mybtn.onClick.AddListener(ZoomEvent);
        _playerInfo = FindObjectOfType<PlayerInfo>().GetComponent<PlayerInfo>();
    }
    void Start()
    {

        //CameraTargetTransform = new Vector3(1.2f, 1.5f, -30);
        LevelManager.instance.backgroundTransform.position = new Vector2(transform.position.x, transform.position.y);
        //backgroundTargetTransform = new Vector2(1.6f, 1.55f);

        isDamage = false;
        _isGame = true;
        Canmove = true;
     
      
    }

    private void LateUpdate()
    {
        if (Canmove == true)
        
        ZoomOut();
    }
    void Update()
    {
        LevelManager.instance.CameraTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 30);
        ShootUI();
        if (_isGame)


        if (Canmove == true)
            {
                animationfather();
                PlayerMove();
               
            }
        if (CanvasTransform.transform != null)
            CanvasTransform.transform.localPosition = new Vector2(transform.position.x + -0.05499995f, transform.position.y + 1.583f);
    }

    public void ChangeHealth(int amount)
    {
        CurrentHealth += amount;
        if (HealthImage[CurrentHealth].gameObject != null)
            HealthImage[CurrentHealth].gameObject.SetActive(false);
        else
            return;

    }
    private void PlayerMove()
    {
        Shoot();

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));




        rb.velocity = new Vector2(movX * PlayerSpeed * sprint, rb.velocity.y);

        if (_joystick.Horizontal >= .2f)       
            movX = _joystick.Horizontal;       

        else if (_joystick.Horizontal <= -.2f)        
            movX = _joystick.Horizontal;       

        else        
            movX = 0;       

        if (movX > 0 && !m_FacingRight)        
            // ... flip the ==false	
            Flip();       

        // Otherwise if the input is moving the player left and the player is facing right...	
        else if (movX < 0 && m_FacingRight)        
            // ... flip the player.	
            Flip();
        

        else { Canmove = true; }

        if (_joystick.Vertical >= .5f && groundCheck.isGrounded == true)
        {

            rb.velocity = new Vector2(0, jump);
            SoundManager.instance.jumpsound();
        }


        if (Mathf.Abs(rb.velocity.y) < 0.001f)
            isJump = false;

        if (_joystick.Horizontal >= .5f && _joystick.Horizontal >= 0 || _joystick.Horizontal <= 0 && _joystick.Horizontal <= -.5f)
        {


            anim.SetBool("Run", true);
            sprint = 2;
            isRunning = true;
        }
        else { anim.SetBool("Run", false); isRunning = false; sprint = 1; }

        //jumping
        if (rb.velocity.y <= 0 && rb.velocity.y > -0.5f)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);


        }
        if (rb.velocity.y > 0.01f)
        {
            anim.SetBool("IsJumping", true);

        }

        if (rb.velocity.y < -1.8)
        {
            anim.SetBool("IsJumping", false);

            anim.SetBool("IsFalling", true);
        }
        if (rb.velocity.y >= 0)
            anim.SetBool("IsFalling", false);


    }
    private void animationfather()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("jump_side"))
        {
            boxCollider.offset = new Vector2(0, 1f);
        }
        else
        {
            boxCollider.offset = new Vector2(0, .7f);

        }

    }
    public void Dead()
    {
        if (!isDead)
        {
          
            StartCoroutine(Died());
            SoundManager.instance.DeadVSound();
            anim.SetTrigger("Dead");

            //mainlose
            Invoke("DeadAnimation", 1.5f);
            StartCoroutine(LevelManager.instance.DestroyColliders());
            isDead = true;
        }
       }
    public void playerhealthdisable() => ChangeHealth(1);

    public void Live()
    {
        if (CurrentHealth < 3)
        {
            anim.SetTrigger("Idle");
            Canmove = true;
            transform.position = new Vector2(LevelManager.instance.SpawnMark.transform.position.x,
                LevelManager.instance.SpawnMark.transform.position.y);
            fade.Health(100);
            isDead = false;
        }
        else
        {
            DeadPanel.SetActive(true);
            _tween.Die(true);
            SoundManager.instance.WhooshVSound();
            CanvasTransform.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Canmove = false;
            _isGame = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isDamage == false)
        {
            SoundManager.instance.playerdamageSound();
            anim.SetTrigger("Hit");
            fade.Damage(20);
            StartCoroutine(Hurt());
        }
        else if (collision.CompareTag("Boom") && isDamage == false)
        {
            SoundManager.instance.playerdamageSound();
            anim.SetTrigger("Hit");
            fade.Damage(50);
            StartCoroutine(Hurt());
        }
        else if (collision.CompareTag("Hammer") && isDamage == false)
        {
            SoundManager.instance.playerdamageSound();
           
            fade.Damage(100);
            StartCoroutine(Hurt());
        }
        else if (collision.CompareTag("Spike")&&isDamage2==false )
        {
            SoundManager.instance.playerdamageSound();
          
            fade.Damage(100);
            StartCoroutine(Hurt());
            StartCoroutine(Hurt2());
        }
        else if (collision.CompareTag("Laser") && isDamage == false)
        {
            SoundManager.instance.playerdamageSound();
          
            fade.Damage(100);
            StartCoroutine(Hurt());
        }
        else if (collision.CompareTag("Heal"))
        {
            SoundManager.instance.ablilitySound();
            fade.Health(34);
            Destroy(collision.gameObject);

        }


        else { return; }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.	
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
   
    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
    
    private void Shoot()
    {
        if (  CanShooting == true)
        {
            if(Mathf.Abs(_singleShootJoystick.Horizontal)> 0.8f|| Mathf.Abs(_singleShootJoystick.Vertical) > 0.8f)
            {
                SoundManager.instance.ShootVSound();
                for (int i = 0; i < BubbleFill.Length; i++)
                {
                    BubbleFill[i].fillAmount = 0;
                }
                anim.SetTrigger("Shoot");
                StartCoroutine(ShootCooldown(1f));
                StartCoroutine(ShootCooldown1());
                Weapon.instance.ShootBullet();

            }


        }

        if (CanShooting2 == true)
        {
            if (Mathf.Abs(_multipleShootJoystick.Horizontal) > 0.8f || Mathf.Abs(_multipleShootJoystick.Vertical) > 0.8f)
            {
                SoundManager.instance.ShootVSound();
                for (int i = 0; i < BubblesFill.Length; i++)
                {
                    BubblesFill[i].fillAmount = 0;
                }
                anim.SetTrigger("Shoot");
                StartCoroutine(ShootCooldown2(2.5f));
                StartCoroutine(ShootCooldown1());
                Weapon.instance.ShootBullet1();
            }
           

        }
    }
    private void DeadAnimation()=> deadanim.SetTrigger("Transition");
    
    private void ZoomOut()
    {
        if (isZoomOut == false)
        {
            BackGround.transform.position = new Vector2(transform.position.x, transform.position.y);
           
            cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(cam.GetComponent<Camera>().orthographicSize, 5f, Time.deltaTime * TransitionSpeed);
            if (isTransition)
                cam.transform.position = Vector3.Lerp(cam.transform.position, LevelManager.instance.CameraTransform.position, TransitionSpeed * 2 * Time.deltaTime);
            else
                        cam.transform.position = LevelManager.instance.CameraTransform.position;

        }
      
        else
        {
            BackGround.transform.position = LevelManager.instance.BackGroundPosition;
            BackGround.transform.localScale = LevelManager.instance.BackGroundSize;
            //BackGround.transform.position = new Vector2(1.6f, 1.55f);
            //BackGround.transform.localScale = new Vector2(5.2f, 5.2f);
            cam.transform.position = Vector3.Lerp(cam.transform.position, LevelManager.instance.CameraTargetTransform.position, TransitionSpeed * Time.deltaTime);
            cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(cam.GetComponent<Camera>().orthographicSize, LevelManager.instance.CameraorthoGraphic, Time.deltaTime * TransitionSpeed);
        }
       
    }
    public void ZoomEvent() { isZoomOut = !isZoomOut; StartCoroutine(CameraTranstion()); } 

    private void ShootUI()
    {
        for (int i = 0; i < BubbleFill.Length; i++)
        {
            BubbleFill[i].fillAmount += Time.deltaTime * Shoot1Speed;
        }
        for (int i = 0; i < BubblesFill.Length; i++)
        {
            BubblesFill[i].fillAmount += Time.deltaTime * Shoot2Speed;
        }
    }
    public void Win()
    {
        _stage.ProgressFunctionality(LevelManager.instance.StageValue);
        SoundManager.instance.WhooshVSound();
        _playerInfo.AddScore(1);
        if (_playerInfo._score%5==0)
          _tween.Chest(true);
          

        
        else
        {
           
            anim.SetTrigger("Win");
            WinPanel.gameObject.SetActive(true);
            _tween.Win(true);
            Canmove = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
            _isGame = false;
          
        }
        

    }
    IEnumerator ShootCooldown(float time)
    {
        CanShooting = false;
        yield return new WaitForSeconds(time);
        CanShooting = true;
    }
    IEnumerator ShootCooldown2(float time)
    {
        CanShooting2 = false;
        yield return new WaitForSeconds(time);
        CanShooting2 = true;
    }
    IEnumerator ShootCooldown1()
    {

        Sprite.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Sprite.SetActive(false);

    }
    IEnumerator CameraTranstion()
    {
        isTransition = true;
            yield return new WaitForSeconds(.5f);
        isTransition = false;

    }
    IEnumerator Died()
    {
      
        Physics2D.IgnoreLayerCollision(9, 10);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.velocity = new Vector2(0, rb.velocity.y);
        Canmove = false;
        StopCoroutine(Hurt());
        yield return new WaitForSeconds(1f);
        anim.ResetTrigger("Dead");
        yield return new WaitForSeconds(3f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Physics2D.IgnoreLayerCollision(9, 10, false);
        Canmove = true;
        deadanim.ResetTrigger("Transition");
        
    }
    IEnumerator Hurt()
    {

        Physics2D.IgnoreLayerCollision(9, 10);
        isDamage = true;
        yield return new WaitForSeconds(2f);
        isDamage = false;
        Physics2D.IgnoreLayerCollision(9, 10, false);


    }
    IEnumerator Hurt2()
    {

        Physics2D.IgnoreLayerCollision(9, 10);
        isDamage2 = true;
        yield return new WaitForSeconds(6f);
        isDamage2 = false;
        Physics2D.IgnoreLayerCollision(9, 10, false);


    }
}




