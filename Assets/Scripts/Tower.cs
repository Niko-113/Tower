using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
  public List<Enemy> currentEnemies;
  public Enemy currentTarget;
  public float damage;

  public Transform turret;
  private LineRenderer laser;


  void Start(){
    laser = GetComponent<LineRenderer>();
    laser.SetPosition(0, this.transform.position);
  }

  void Update(){
    if (currentTarget)
    {
      laser.SetPosition(1, currentTarget.transform.position);
      currentTarget.takeDamage(damage * Time.deltaTime);
    }
    else if (laser.GetPosition(1) != this.transform.position)
    {
      // Reset laser position to neutral
      laser.SetPosition(1, this.transform.position);
    }
  }

  void OnTriggerEnter(Collider collider)
  {
    if (collider.GetComponent<Enemy>() != null)
    {
      Enemy newEnemy = collider.GetComponent<Enemy>();
      newEnemy.deathEvent.AddListener(delegate { BookKeeping(newEnemy);});
      currentEnemies.Add(newEnemy);
      if (currentTarget == null) currentTarget = newEnemy;
    }
  }

  void OnTriggerExit(Collider collider)
  {
    if (collider.GetComponent<Enemy>() != null)
    {
      Enemy oldEnemy = collider.GetComponent<Enemy>();
      BookKeeping(oldEnemy);
    }
  }

  void BookKeeping(Enemy enemy)
  {
    currentEnemies.Remove(enemy);
    currentTarget = (currentEnemies.Count > 0) ? currentEnemies[0]: null;
  }
}
