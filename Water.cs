using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    bool isActive = false;
    float lastKeyPressTime = 0f;
    float deactivationDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se uma das teclas foi pressionada
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V))
        {
            isActive = true;
            lastKeyPressTime = Time.time; // Armazena o tempo da última tecla pressionada
            gameObject.SetActive(true); // Ativa o objeto
        }

        // Verifica se o objeto está ativo e se já passou 1 segundo desde a última tecla pressionada
        if (isActive && Time.time - lastKeyPressTime > deactivationDelay)
        {
            isActive = false;
            gameObject.SetActive(false); // Desativa o objeto
        }
    }
}
