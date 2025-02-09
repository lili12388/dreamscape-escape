using UnityEngine;

public class GoblinDeathBehaviour : StateMachineBehaviour
{
    // Called when the animation state is entered
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Goblin is dead!");
        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false; // Disable AI
        animator.GetComponent<Collider>().enabled = false; // Disable collider

        // Destroy the goblin after the death animation finishes
        GameObject.Destroy(animator.gameObject, stateInfo.length);
    }
}