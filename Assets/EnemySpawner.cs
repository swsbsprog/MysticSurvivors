using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public float delay = 1;
    public float distance = 10;
    IEnumerator Start()
    {
        while (true)
        {
            var angle = Random.Range(0, 360);

            Quaternion qrot = Quaternion.Euler(0, angle, 0);

            Vector3 pos = qrot * new Vector3(0, 0, distance) + transform.position;

            var newEnemy = Instantiate(enemy, pos, Quaternion.identity);
            newEnemy.transform.position = pos;

            yield return new WaitForSeconds(delay);
        }
    }
}
