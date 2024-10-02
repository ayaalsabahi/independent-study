using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    private float maxTime; 

    [SerializeField]
    private float lowTime; 

    [SerializeField]
    private float timeUntilSpawn;  
    // Start is called before the first frame update
    public GameObject npcPrefab; 

    public void Start(){
        SetTimeTillSpawn(); 
    }

    public void Update(){
        timeUntilSpawn -= Time.deltaTime;
        if(timeUntilSpawn <= 0){
            
            Instantiate(npcPrefab, transform.position, Quaternion.identity);
            SetTimeTillSpawn();
        }
    }

    private void SetTimeTillSpawn(){
        timeUntilSpawn = Random.Range(lowTime, maxTime);
    }
}
