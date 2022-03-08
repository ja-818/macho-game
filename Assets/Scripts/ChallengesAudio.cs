using UnityEngine;

public class ChallengesAudio : StateMachineBehaviour
{
    [SerializeField] AudioClip challengeAudio;

    //Plays the audio clip assigned to the animator event when the animation begins
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AudioSource>().PlayOneShot(challengeAudio);
    }
}
