using UnityEngine;

public class AnimationEndBehaviour : StateMachineBehaviour
{
    // Этот метод вызывается, когда анимация заканчивается
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Анимация завершена!");
        // Здесь можно добавить логику, которая должна выполниться после окончания анимации
    }
}