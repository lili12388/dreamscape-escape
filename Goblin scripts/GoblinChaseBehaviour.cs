using UnityEngine;

public class GoblinChaseBehaviour : StateMachineBehaviour
{
    // Called when the animation state is entered
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Goblin is chasing the player!");
    }
}