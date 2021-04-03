using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    public GameObject tower;
    public GameObject terrain;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(mouse, out hit)){
                if(hit.collider.tag == "Enemy"){
                    hit.collider.gameObject.GetComponent<Enemy>().takeDamage(1);
                }
                if(hit.collider.tag == "TowerSpot" && Purse.coinPurse.coins >= 25){
                    Purse.coinPurse.addCoins(-25);
                    hit.transform.gameObject.SetActive(false);
                    Instantiate(tower, hit.transform.position, Quaternion.identity, terrain.transform);
                }
            }
        }
    }
}
