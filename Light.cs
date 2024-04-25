using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Define a rotação inicial do objeto quando o Start é chamado
        transform.rotation = Quaternion.Euler(56.387f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se a tecla F foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Altera a rotação do objeto para o valor desejado
            transform.rotation = Quaternion.Euler(-12.43f, 178.24f, -90f);
            // Exibe a mensagem no console
            Debug.Log("Hinokami Kagura");
        }
    }
}
