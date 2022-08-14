using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public List<ActionRatio> actionRatio = new();
    public int hp = 100;
    
    IEnumerator Start()
    {
        Animator animator = GetComponent<Animator>();   
        while (hp > 0)
        {
            ActionType nextAction = actionRatio
                .OrderBy(x => Random.Range(0, x.ratio))
                .Last().type;
            switch(nextAction)
            {
                case ActionType.Idle:
                    animator.SetTrigger("Idle");
                    break;
                case ActionType.Idle2:
                    animator.SetTrigger("IdleJump");
                    break;
                case ActionType.IdleMove: // 주변 랜덤 지역으로 이동.
                    break;
            }
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
    }
}

public enum ActionType
{
    Idle,
    Idle2,
    IdleMove,
}
[System.Serializable]
public class ActionRatio
{
    public ActionType type;
    public float ratio;
}