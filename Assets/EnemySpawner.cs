using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            newEnemy.dropItems = GetDropItems();

            yield return new WaitForSeconds(delay);
        }
    }

    private List<DropItem> GetDropItems()
    {
        List<DropItem> dropItems = new();

        int dropCount = Random.Range(ItemDB.Instance.dropCountMin
            , ItemDB.Instance.dropCountMax);
        for (int i = 0; i < dropCount; i++)
        {
            dropItems.Add(
                ItemDB.Instance.dropItems.OrderBy(x => x.ratio)
                .Last().dropItem
                );
        }

        return dropItems;
    }
}
