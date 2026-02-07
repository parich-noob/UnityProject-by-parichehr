using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Stats")]
    public int scoreValue = 10;
    public float moveSpeed = 2f;

    protected Transform gate;

    protected virtual void Start()
    {
        GameObject gateObj = GameObject.FindGameObjectWithTag("Gate");

        if (gateObj != null)
            gate = gateObj.transform;
        else
            Debug.LogError("Gate not found! Tag it as 'Gate'");
    }

    protected virtual void Update()
    {
        MoveToGate();
    }

    protected virtual void MoveToGate()
    {
        if (gate == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            gate.position,
            moveSpeed * Time.deltaTime
        );
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        blade blade = collision.GetComponent<blade>();

        if (blade != null)
        {
            OnSliced(blade.Direction);
        }
    }

    protected virtual void OnSliced(Vector2 sliceDirection)
    {
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

    public virtual void OnReachGate()
    {
        GameManager.Instance.LoseLife();
        Destroy(gameObject);
    }
}
