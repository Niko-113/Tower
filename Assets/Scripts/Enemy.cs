using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Path route;
  private Waypoint[] myPath;
  public int coinWorth;
  public float health;
  public float speed = .25f;
  private int index = 0;
  private Vector3 nextWaypoint;
  private bool stop = false;

  void Awake()
  {
    myPath = route.path;
    transform.position = myPath[index].transform.position;
    Recalculate();
  }

  void Update()
  {
    if (!stop)
    {
      if ((transform.position - myPath[index + 1].transform.position).magnitude < .1f)
      {
        index = index + 1;
        Recalculate();
      }


      Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
      transform.Translate(moveThisFrame);
    }

  }

  void Recalculate()
  {
    if (index < myPath.Length -1)
    {
      nextWaypoint = (myPath[index + 1].transform.position - myPath[index].transform.position).normalized;
    }
    else
    {
      stop = true;
    }
  }
  public void takeDamage(int damage){
    health -= damage;
    if (health <= 0){
      Purse.coinPurse.addCoins(coinWorth);
      Destroy(this.gameObject);
    }
  }
}
