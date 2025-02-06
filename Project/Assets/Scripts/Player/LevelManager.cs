using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    #region Constructer
    public static LevelManager instance;
    private GameObject RealPlayer;
    public GameObject[] Viruses;
    public Transform[] Virusesspawn;
    public GameObject[] Virus;
    [SerializeField] GameObject[] Characters;
    [Space(50)]
    public GameObject[] Heals;
    public Transform[] Healspawn;
    public GameObject Heal;
    [Space(50)]
    public Transform SpawnMark;
    [SerializeField] Transform[] SpawnE;
    [SerializeField] GameObject[] Boom;
    [SerializeField] GameObject BoomPrefab;
    public int CoinsAmount;

    [Space(50)]
    [Header("CameraAndBackGround")]
    [Tooltip("here you can edit the camera and background size and position")]

    public Transform backgroundTransform;
    public Transform backgroundTargetTransform;
    public Transform CameraTargetTransform;
    public Transform CameraTransform;

    public Vector2 BackGroundSize;
    public Vector2 BackGroundPosition;

    public float CameraorthoGraphic;
    #endregion
    [Space(50)]
    #region varibles
    public int PlayerNumber;
    [HideInInspector] public int SpawnTime = 1;
    [HideInInspector] public bool CanSpawnBoom;
    private bool CanSpawnBoom1;
    [HideInInspector] public bool CanSpawnVirus;
    [HideInInspector] public bool Spawn;
    private int virusesCount;
    private int virusesCountPlus = 0;
    public int StageValue;
    // Start is called before the first frame update
    #endregion

    /*
      Diesky = astronaut = free
     Momichi = ninja = star 
Mac  = Knight = 2star
Xhita = solder = 3 star
Light bringer = biker = 4 star

     */

    

    [SerializeField] Sprite[] CharactersSprites;
    [SerializeField] Image[] CharactersImages;
   
    public enum Chars
    {
        Diesky, Momichi, Knight, solder, bringer
    }
    private void Awake()
    {
        instance = this;

        CanSpawnVirus = true;
        Spawn = true;
        Debug.Log(StageValue + "+" + "StageValue");
    }
    private void OnEnable()
    {
        GameManager.instance.CharacterNumber = PlayerPrefs.GetInt("PlayerNumber", 0);
        PlayerNumber = GameManager.instance.CharacterNumber;

    }

    private void Start()
    {

        Invoke(nameof(InstantiatePlayer), 0f);
        SpawnTime = 1;
        InvokeRepeating("instantiateHeal", 15, 45);
        CanSpawnBoom1 = true;
        CanSpawnBoom = false;
        for (int i = 0; i < CharactersImages.Length; i++)
        {
            CharactersImages[i].sprite = CharactersSprites[PlayerNumber];
        }
    }
    private void Update()
    {
        virusesCount = Viruses.Length;

        InvokeRepeating("instantiateVirus", 5, SpawnTime);

        InvokeRepeating("instantiateBoom", 0, 1);

        Viruses = GameObject.FindGameObjectsWithTag("Enemy");
        Heals = GameObject.FindGameObjectsWithTag("Heal");

        if (virusesCount <= 0)
            virusesCountPlus = 0;

      






    }
    void instantiateVirus()
    {
        if (CanSpawnVirus == true && virusesCount < 18 && virusesCountPlus < Virusesspawn.Length && Spawn == true)
        {

            int rand = Random.Range(0, Virusesspawn.Length);
            int rand2 = Random.Range(0, Virus.Length);
            if (Virusesspawn[rand] != null && Virusesspawn[rand].transform.childCount == 0)
            {
                virusesCountPlus += 1;
                Instantiate(Virus[rand2], Virusesspawn[rand].position, Quaternion.identity, Virusesspawn[rand].transform);
            }


            StartCoroutine(disableboolvirus());

        }


    }


    void instantiateBoom()
    {
        if (CanSpawnBoom == true && CanSpawnBoom1 == true)
        {
            int rand = Random.Range(0, Virusesspawn.Length);
            if (Virusesspawn[rand].transform.Find("Virus(Clone)") != null)
            {
                int random = Random.Range(0, Boom.Length);
                BoomPrefab = Instantiate(Boom[random], Virusesspawn[rand].position, Quaternion.identity, Virusesspawn[rand].transform);
                Destroy(BoomPrefab, 1f);
                StartCoroutine(disableboolboom());

            }

        }
    }
    public void InstantiatePlayer()
    {

        RealPlayer = Instantiate(Characters[PlayerNumber], SpawnMark.position, Quaternion.identity, null);
    }
    void instantiateHeal()
    {
        int rand = Random.Range(0, Healspawn.Length);
        if (Healspawn[rand] != null && Healspawn[rand].transform.Find("Heal(Clone)") == null)
            Instantiate(Heal, Healspawn[rand].position, Quaternion.identity, Healspawn[rand].transform);
        else
            return;
        StartCoroutine(disableboolvirus());
        
    }
    IEnumerator disableboolboom()
    {
        CanSpawnBoom1 = false;
        yield return new WaitForSeconds(3);
        CanSpawnBoom1 = true;
    }
    IEnumerator disableboolvirus()
    {

        CanSpawnVirus = false;
        yield return new WaitForSeconds(SpawnTime);
        CanSpawnVirus = true;
    }
    public void DestroyAll()
    {
        for (int i = 0; i < Viruses.Length; i++)
        {
            Destroy(Viruses[i]);

            Spawn = false;
        }
    }

    public IEnumerator DestroyColliders()
    {
        for (int i = 0; i < Viruses.Length; i++)
        {
            Viruses[i].gameObject.GetComponents<CircleCollider2D>()[0].enabled = false;
            Viruses[i].gameObject.GetComponents<CircleCollider2D>()[1].enabled = false;
        }
        yield return new WaitForSeconds(6f);
        for (int i = 0; i < Viruses.Length; i++)
        {
            Viruses[i].gameObject.GetComponents<CircleCollider2D>()[0].enabled = true;
            Viruses[i].gameObject.GetComponents<CircleCollider2D>()[1].enabled = true;
        }
    }
}