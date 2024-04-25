using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player; // Referência ao GameObject do personagem

    // Variáveis de visão
    public float rotationSpeed = 1f; // Velocidade de rotação da câmera
    public float maxPitchDown = -60f; // Limite máximo de inclinação para baixo (em graus)
    public float maxPitchUp = 90f; // Limite máximo de inclinação para cima (em graus)
    private float yaw = 0f;
    private float pitch = 0f;
    public float smoothSpeed = 0.1f;


    void Update()
    {
        Vision();
    }

    void Vision()
    {
        // Rotação da câmera baseada no movimento do mouse
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, maxPitchDown, maxPitchUp);

        // Define a nova rotação desejada da câmera
        Quaternion desiredRotation = Quaternion.Euler(pitch, yaw, 0f);

        // Interpola suavemente entre a rotação atual e a nova rotação desejada
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * smoothSpeed);

        // Rotação do personagem apenas nos lados
        float rotationInput = Input.GetAxis("Mouse X");
        player.transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }
}
