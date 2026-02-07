using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.OnReachGate();
        }
    }
}
