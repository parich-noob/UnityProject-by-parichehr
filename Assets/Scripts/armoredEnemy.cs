using UnityEngine;

public class armoredEnemy : EnemyBase
{
    public Vector2 requiredDirection;

    // public override void OnCorrectSlice()
    // {
    //     Vector2 swipeDir = SwipeManager.Instance.SwipeDirection;

    //     float dot = Vector2.Dot(
    //         swipeDir.normalized,
    //         requiredDirection.normalized
    //     );

    //     if (dot > 0.7f)
    //     {
    //         base.OnCorrectSlice();
    //     }
    //     else
    //     {
    //         OnWrongSlice();
    //     }
    // }
}
