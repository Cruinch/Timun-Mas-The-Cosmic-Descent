using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Transform karakter pemain yang akan diikuti
    public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera (semakin kecil nilainya, semakin mulus)
    public Vector3 playerOffset = Vector3.zero; // Offset posisi karakter pemain dalam kamera
    public float cameraSizeMin = 5f; // Ukuran kamera minimum
    public float cameraSizeMax = 10f; // Ukuran kamera maksimum

    private Vector3 offset; // Jarak antara kamera dan karakter pemain
    private Camera mainCamera; // Referensi ke komponen kamera

    private void Start()
    {
        // Hitung offset antara kamera dan karakter pemain
        offset = transform.position - target.position;
        mainCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        // Hitung posisi yang diinginkan untuk kamera berdasarkan posisi karakter pemain
        Vector3 desiredPosition = target.position + offset + playerOffset;

        // Interpolasi linier (Lerp) dari posisi kamera saat ini ke posisi yang diinginkan
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Terapkan posisi yang dihitung ke transform kamera
        transform.position = smoothedPosition;

        // Atur ukuran kamera berdasarkan jarak antara karakter pemain dan kamera
        float distance = Vector3.Distance(transform.position, target.position);
        float cameraSize = Mathf.Clamp(distance, cameraSizeMin, cameraSizeMax);
        mainCamera.orthographicSize = cameraSize;
    }
}
