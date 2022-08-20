using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public Missile missile;
    public float delay = 0.5f;

    IEnumerator Start()
    {
        while(true)
        {
            var pos = transform.position;
            var nearnestEnemy = enemies
                .Where(enemy => enemy.hp > 0)
                .OrderBy(x => Vector3.Distance(x.transform.position, pos))
                .LastOrDefault();
            if (nearnestEnemy != null)
            {
                var toDirection = nearnestEnemy.transform.position - pos;
                toDirection.y = 0;
                toDirection.Normalize();

                var newMissile = Instantiate(missile);
                newMissile.transform.position = pos;
                newMissile.transform.forward = toDirection;
            }
            yield return new WaitForSeconds(delay);
        }
    }
    HashSet<Enemy> enemies = new();
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if(enemy != null)
            enemies.Add(enemy);
    }
    private void OnTriggerExit(Collider other)
    {
        enemies.Remove(other.GetComponent<Enemy>());
    }
}
