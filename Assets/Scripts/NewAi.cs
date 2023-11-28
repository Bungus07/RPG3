using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewAi : MonoBehaviour
{
    [Header("Waypoints")]
    public int EnemyID;
    private GameObject[] Waypoints;
    private int WaypointOrder = 0;
    private Vector3 WhereToGo;
    private float AmountOfWaypoints;
    private GameObject Player;
    private Vector3 RotationToChangeTo;
    private Vector3 Rotation;
    [Header("Speed")]
    public float Speed;
    [Header("Raycast")]
    private Vector3 RaycastOffset;
    public float Raydistance;
    [Header("Debug")]
    private GameObject TargetObject;
    public enum State
    {
        [Header("States")]
        WaypointMode,
        ChasePlayer
    }
    public State EnemyState;
    [Header("Respawn")]
    private GameObject RespawnPlain;
    public GameObject RespawnPoint;
    [Header("HealthBar")]
    private Slider EnemyHealthBar;
    private int MaxHealth = 10;
    private int CurrentHealth;
    private HealthBar PlayerHealthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("EnemyWaypoint" + EnemyID);
        AmountOfWaypoints = Waypoints.Length;
        TargetObject = Waypoints[WaypointOrder];
        transform.right = TargetObject.transform.position - transform.position;
        EnemyState = State.WaypointMode;
        Player = GameObject.Find("Player");
        RespawnPlain = GameObject.Find("Respawn Plain");
        PlayerHealthBarScript = GameObject.Find("Player").GetComponent<HealthBar>();
        CurrentHealth = MaxHealth;
        EnemyHealthBar = gameObject.GetComponentInChildren<Slider>();
        EnemyHealthBar.maxValue = MaxHealth;
        EnemyHealthBar.value = MaxHealth;
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int amount)
    {
        CurrentHealth = CurrentHealth - amount;
        EnemyHealthBar.value = CurrentHealth;
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == ("RespawnPlain"))
        {
            transform.position = RespawnPoint.transform.position;
            WayPointMode();
        }
        if (EnemyState == State.WaypointMode)
        {
            if (Other.tag == "EnemyWaypoint" + EnemyID)
            {
                if (WaypointOrder != AmountOfWaypoints - 1)
                {
                    WaypointOrder = ++WaypointOrder;
                    WhereToGo = Waypoints[WaypointOrder].transform.position;
                    TargetObject = Waypoints[WaypointOrder];
                    transform.right = TargetObject.transform.position - transform.position;
                    RotationToChangeTo = transform.right = TargetObject.transform.position - transform.position;
                    Rotation = transform.rotation.eulerAngles;
                }
                else
                {
                    WaypointOrder = 0;
                    WhereToGo = Waypoints[WaypointOrder].transform.position - transform.position;
                    TargetObject = Waypoints[WaypointOrder];
                    transform.right = TargetObject.transform.position - transform.position;
                    Rotation = transform.rotation.eulerAngles;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("EnemyHasHitPlayer");
            PlayerHealthBarScript.TakeDamage(2);
        }
        
        
    }
    private void ChasePlayer()
    {
        EnemyState = State.ChasePlayer;
        TargetObject = Player;
        Rotation = transform.rotation.eulerAngles;
    }
    private void WayPointMode()
    {
        EnemyState = State.WaypointMode;
        TargetObject = Waypoints[WaypointOrder];
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 TheMovement = transform.position = Vector3.MoveTowards(transform.position, TargetObject.transform.position, Speed * Time.deltaTime);
        if (EnemyState == State.ChasePlayer)
        {
            transform.right = TargetObject.transform.position - transform.position;
            RotationToChangeTo = transform.right = TargetObject.transform.position - transform.position;
        }
        var Hits = Physics.RaycastAll(transform.position, transform.right, Raydistance);
        Debug.DrawRay(transform.position, transform.right, Color.magenta);
        
        foreach (var Vision in Hits)
        {
            if (Vision.transform.tag == "Player")
            {
                ChasePlayer();
            }
        }
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
