using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    private GameObject Player;
    public float MoveSpeed;
    public float MaxDist;
    public float MinDist;
    public float gravity;

    public float lowestPoint;
    public Transform targetWhenNotChasing;

    public float damage;
    public float AttackCooldown;

    private Transform previousLocation;
    private Vector3 moveDirection = Vector3.zero;
    private float cooldown;
    public float baseRotationStep;

    //private Gun gun;
    //[SerializeField] private int scoreValue;
    //[SerializeField] private GameObject explosionParticles;

    public Transform bulletEmitter;
    public GameObject bullet;    
    public float Bullet_Forward_Force;
    [SerializeField] private float rotChangeInterval;
    private float time;
    private float rotationStep;
    private float StraifeCooldown = 5;
    private float STRAIF_RESET_TIME = 5;
    public EnemySpawnerSystem spawnerSystem = null;

    public enum enemyType
    {
        Ranged,
        Close
    };

    public enemyType type;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        previousLocation = transform;
        //gun = gameObject.GetComponent<Gun>();
    }

    void Update()
    {
        cooldown += Time.deltaTime;
        Vector3 relativePos;
        StraifeCooldown += Time.deltaTime;
        //Debug.Log(transform.position.y);
        if (transform.position.y <= lowestPoint)
        {
            relativePos = targetWhenNotChasing.position - transform.position;
            StraifeCooldown = 0;
            
        }
        else
        {
            if (StraifeCooldown <= STRAIF_RESET_TIME)
            {
                relativePos = targetWhenNotChasing.position - transform.position;
            }
            else
            {
                relativePos = Player.transform.position - transform.position;
            }
            
        }
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        if (time >= rotChangeInterval)
        {
            float rand = Random.Range(1f, 4f);
            rotationStep = baseRotationStep * rand;
            time = 0;
        }

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotation, rotationStep * Time.deltaTime);

        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = transform.forward;
        moveDirection *= MoveSpeed;


        //System.Diagnostics.Debug.WriteLine(moveDirection);
        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);


        if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist && cooldown >= AttackCooldown)
        {

            Debug.Log("SHOOT");
            //SHOOT
            GameObject shot = Instantiate(bullet, bulletEmitter.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * Bullet_Forward_Force);
            cooldown = 0;
            Destroy(shot, 5);
            //Player.GetComponent<PlayerHealth> ().takeDmg (-damage);
            //Destroy (gameObject);
        }
        previousLocation = transform;
        time += Time.deltaTime;
    }

    public void Damage(float dmg)
    {
        try
        {
            spawnerSystem.KillEnemy();
        }
        catch
        {

        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        //if (other.CompareTag("Bullet"))
        //{

        //}

    }

   
}
