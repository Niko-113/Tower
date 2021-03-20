using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            }
        }
    }
}
