using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinokami : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Desativa o objeto quando o jogo é iniciado
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se a tecla F foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Ativa o objeto quando a tecla F é pressionada
            gameObject.SetActive(true);
        }
    }
}
