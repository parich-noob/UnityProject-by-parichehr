using UnityEngine;

public class blade : MonoBehaviour
{
    private Camera mainCamera;
    private bool isSlicing;

    private Collider2D bladeCollider;
    private TrailRenderer bladeTrail;

    public Vector2 Direction { get; private set; }

    [Header("Slice Settings")]
    public float minSliceVelocity = 5f;

    public float sliceforce = 5f;
    private Vector2 lastPosition;

    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider2D>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (isSlicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        Vector2 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        lastPosition = pos;
        isSlicing = true;

        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }

    private void StopSlicing()
    {
        isSlicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector2 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Direction = newPos - lastPosition;

        float velocity = Direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPos;
        lastPosition = newPos;
    }
}
