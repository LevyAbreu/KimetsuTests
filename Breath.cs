using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    public ParticleSystem smokeParticleSystem; // Referência ao Particle System de fumaça

    void Start()
    {
        // Desliga o Particle System no início
        smokeParticleSystem.Stop();
    }

    void Update()
    {
        // Verifica se o botão E foi pressionado
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Liga o Particle System
            smokeParticleSystem.Play();
        }
        // Verifica se o botão E foi solto
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            // Desliga o Particle System
            smokeParticleSystem.Stop();
        }
        // Se o Particle System estiver ativo
        if (smokeParticleSystem.isPlaying)
        {
            // Reduz a duração das partículas para que elas desapareçam mais rapidamente
            ParticleSystem.MainModule mainModule = smokeParticleSystem.main;
            mainModule.startLifetime = 1f; // Defina o valor que desejar aqui
        }
    }
}