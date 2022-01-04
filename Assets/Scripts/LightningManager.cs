using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class LightningManager : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenStrikes = 3f;
    [SerializeField] private float maxTimeBetweenStrikes = 5f;
    [SerializeField] private List<GameObject> LightningPrefab = new List<GameObject>();
    private float timer;
    private List<LightningBoltScript> lightnings = new List<LightningBoltScript>();
    private int curLightning;

    // Start is called before the first frame update
    void Start()
    {
        
        foreach(GameObject obj in LightningPrefab)
        {
            lightnings.Add(obj.GetComponent<LightningBoltScript>());
        }
        
        timer = Random.Range(minTimeBetweenStrikes, maxTimeBetweenStrikes);
        curLightning = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {

            timer = Random.Range(minTimeBetweenStrikes, maxTimeBetweenStrikes);
            var curLightnings = GetLightningRange();
            foreach(LightningBoltScript lightning in curLightnings)
            {
                RandomStrike(lightning);
            }
            
        }
    }


    private List<LightningBoltScript> GetLightningRange()
    {
        int numOfStrikes = Mathf.RoundToInt(Random.Range(1f, 3f));
        if((curLightning + numOfStrikes) >= lightnings.Count)
        {
            numOfStrikes = lightnings.Count - curLightning;
        }
        var curLightnings = lightnings.GetRange(curLightning, numOfStrikes);
        curLightning = (curLightning + numOfStrikes) % lightnings.Count;
        return curLightnings;
            
    }

    private void RandomStrike(LightningBoltScript lightning)
    {
        float nextX = Random.Range(15f, 30f);
        nextX *= Random.Range(0f, 1f) > 0.5 ? 1 : -1;
        float nextZ = Random.Range(15f, 30f);
        nextZ *= Random.Range(0f, 1f) > 0.5 ? 1 : -1;
        lightning.StartPosition = new Vector3(nextX, 0, nextZ);
        lightning.EndPosition = new Vector3(nextX, 0, nextZ);
        lightning.Trigger();
    }
}
