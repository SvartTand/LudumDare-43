using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSpawningSystem : MonoBehaviour {

    public GameObject meteor;
    public GameObject lightning;

    public float meteorAmount;
    public float lightningAmount;

    public float maxX = 30;
    public float maxZ = 30;

    private float timeUntillUnhappy;
    public float timeUntillUnhappyMax;

    public float height;

    private bool active;

    public float meteorInterval = 0.2f;
    public float lightningInterval = 0.1f;

    private float meteorCooldown;
    private float lightningCooldown;

    private float tot;

    [SerializeField] private Text sacrificeText;
    [SerializeField] private Image imgBar;

    // Use this for initialization
    void Start () {
        tot = 0;
        timeUntillUnhappy = timeUntillUnhappyMax;
	}
	
	// Update is called once per frame
	void Update () {
        timeUntillUnhappy -= Time.deltaTime;
        //Debug.Log(lightningCooldown + ", " + meteorCooldown);

        if(timeUntillUnhappy <= 0)
        {
            //Debug.Log("Unhappy");
            sacrificeText.text = "God is Unhappy!";
            if(meteorCooldown <= 0)
            {
                SpawnMeteor();
                meteorCooldown = meteorInterval;
                tot++;
            }

            if(lightningCooldown <= 0)
            {
                SpawnLightning();
                lightningCooldown = lightningInterval;
                tot++;
            }

            if(tot == meteorAmount + lightningAmount)
            {
                timeUntillUnhappy = timeUntillUnhappyMax;
                tot = 0;
            }
            lightningCooldown -= Time.deltaTime;
            meteorCooldown -= Time.deltaTime;

        }
        else
        {

            sacrificeText.text = "Happiness: " + (int)timeUntillUnhappy;
            imgBar.fillAmount = timeUntillUnhappy / timeUntillUnhappyMax;
        }

        
        
		
	}

    private void SpawnMeteor()
    {
        GameObject m = GameObject.Instantiate(meteor, new Vector3(Random.Range(-maxX,maxX), height, Random.Range(-maxZ, maxZ)), Random.rotation);
        Destroy(m, 10f);
    }

    private void SpawnLightning()
    {
        GameObject l = GameObject.Instantiate(lightning, new Vector3(Random.Range(-maxX, maxX), height*0.5f, Random.Range(-maxZ, maxZ)), transform.rotation);
        Destroy(l, 10f);
    }

    public void AddTime(float time)
    {
        timeUntillUnhappy += time;
    }
}
