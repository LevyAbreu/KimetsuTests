using System.Collections;
using UnityEngine;

public class TanjiroMove : MonoBehaviour{
    public GameObject player;

    // Variáveis de visão
    public float rotationSpeed = 1f;
    private float yaw = 0f;
    public float smoothSpeed = 0.1f;

    // Variáveis de controle
    public float moveSpeed = 3f;
    int lastAttack = 0;

    private CharacterController characterController;
    private Animator animator;
    private Vector3 moveDirection;
    private bool sprint = false;
    private bool isBreathing = false;
    private float breathing = 0f;

    void Start(){
        characterController = player.GetComponent<CharacterController>();
        animator = player.GetComponent<Animator>();

        // Bloqueia e esconde o cursor do mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){
        //Controles
        Vision();
        Move();
        Sprint();
        Passive();
        Breath();
        StartCoroutine(Skill1());
        StartCoroutine(Skill2());
        StartCoroutine(Skill3());
        StartCoroutine(Skill4());


        Animations();
    }

    void Vision(){
        // Rotação da câmera baseada no movimento do mouse
        yaw += rotationSpeed * Input.GetAxis("Mouse X");

        // Define a nova rotação desejada da câmera
        Quaternion desiredRotation = Quaternion.Euler(0f, yaw, 0f);

        // Interpola suavemente entre a rotação atual e a nova rotação desejada
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * smoothSpeed);

        // Rotação do personagem apenas nos lados
        float rotationInput = Input.GetAxis("Mouse X");
        player.transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }

    void Move(){
        // Movimento horizontal e vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento
        moveDirection = transform.forward * moveVertical + transform.right * moveHorizontal;

        // Aplica a velocidade de movimento ao CharacterController
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (sprint == true){
            moveSpeed = 7f;
        } else {
            moveSpeed = 3f;
        }
    }

    void Breath(){
        // Se o jogador está pressionando o botão Q
        if (Input.GetKey(KeyCode.Q))
        {
            // Atualiza a variável de respiração
            if (breathing < 100f)
            {
                breathing += Time.deltaTime * 10f;
                Debug.Log("Valor da respiração enquanto pressionado Q: " + breathing);
            }
            else
            {
                breathing = 100f;
            }

            // Atualiza o estado de respiração
            isBreathing = true;
        }
        else
        {
            // Se o jogador soltou o botão Q, inicia a redução da respiração
            if (isBreathing)
            {
                StartCoroutine(DecreaseBreathing());
                isBreathing = false;
            }
        }
    }
    IEnumerator DecreaseBreathing()
    {
        // Diminui gradualmente a respiração a cada segundo
        while (breathing > 0f)
        {
            breathing -= 10f; // Diminui 10 a cada segundo
            yield return new WaitForSeconds(1f);
            Debug.Log("Valor da respiração enquanto pressionado Q: " + breathing);
        }
    }

    void Sprint(){
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            if (sprint == false){
                sprint = true;
                Debug.Log("Sprint Ativado");
            } else {
                sprint = false;
                Debug.Log("Sprint Desativado");
            }
        }
        
    }

    void Passive(){
        //Passiva
        if (Input.GetMouseButtonDown(0))
        {
            // Incrementa a variável de controle do último ataque
            lastAttack = (lastAttack + 1) % 2;

            // Define qual ataque ativar com base no último ataque realizado
            if (lastAttack == 1)
            {
                animator.SetBool("HitOne", true);
                animator.SetBool("HitTwo", false);
            }
            else if (lastAttack == 0)
            {
                animator.SetBool("HitOne", false);
                animator.SetBool("HitTwo", true);
            }
        }
        else{
            animator.SetBool("HitOne", false);
            animator.SetBool("HitTwo", false);
        }
    }
    IEnumerator Skill1(){
        if (breathing > 10f){
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Primeira forma...");
                animator.SetBool("SkillOne", true);

                // Aguarda 1 segundo
                yield return new WaitForSeconds(0.8f);
                // Define a velocidade do dash
                float dashSpeed = moveSpeed * 5f;

                // Move o personagem para frente por 1 segundo
                float timer = 0f;
                while (timer < 0.2f)
                {
                    Vector3 moveDirection = transform.forward * dashSpeed * Time.deltaTime;
                    characterController.Move(moveDirection);
                    timer += Time.deltaTime;
                    yield return null;
                }
                Debug.Log("Minamogiri");
            } else {
                animator.SetBool("SkillOne", false);
            }
        } else {
            isBreathing = false;
        }
    }

    IEnumerator Skill2(){
        if (breathing > 20f){
            if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("Segunda forma...");
                animator.SetBool("SkillTwo", true);
                // Aguarda 1 segundo
                yield return new WaitForSeconds(0.8f);
                Debug.Log("Mizuguruma...");
            }
            else{
                animator.SetBool("SkillTwo", false);
            }
        }
    }

    IEnumerator Skill3(){
        if (breathing > 30f){
            if (Input.GetKey(KeyCode.C))
            {
                Debug.Log("Terceira forma...");
                animator.SetBool("SkillThree", true);
                // Aguarda 1 segundo
                yield return new WaitForSeconds(0.8f);
                Debug.Log("Ryuuriuu Mai...");
            }
            else{
                animator.SetBool("SkillThree", false);
            }
        }
    }

    IEnumerator Skill4(){
        if (breathing > 40f){
            if (Input.GetKey(KeyCode.V))
            {
                Debug.Log("Quarta forma...");
                animator.SetBool("SkillFour", true);
                // Aguarda 1 segundo
                yield return new WaitForSeconds(0.8f);
                Debug.Log("Seisei Ruten...");
            }
            else{
                animator.SetBool("SkillFour", false);
            }
        }
    }

    IEnumerator Super(){
        if (breathing > 50f){
            if (Input.GetKey(KeyCode.V))
            {
                Debug.Log("Marca do caçador...");
                animator.SetBool("Super", true);
                // Aguarda 1 segundo
                yield return new WaitForSeconds(0.8f);
                Debug.Log("Hinokami Kagura...");
            }
            else{
                animator.SetBool("Super", false);
            }
        }
    }


    void Animations(){
        // Define os bools correspondentes nas animações com base nas teclas pressionadas
        if (sprint == true){
            animator.SetBool("Sprint", Input.GetKey(KeyCode.W));
            animator.SetBool("SprintBack", Input.GetKey(KeyCode.S));
            animator.SetBool("SprintLeft", Input.GetKey(KeyCode.A));
            animator.SetBool("SprintRight", Input.GetKey(KeyCode.D));
        } else {
            animator.SetBool("Walk", Input.GetKey(KeyCode.W));
            animator.SetBool("WalkBack", Input.GetKey(KeyCode.S));
            animator.SetBool("WalkLeft", Input.GetKey(KeyCode.A));
            animator.SetBool("WalkRight", Input.GetKey(KeyCode.D));
        }
        animator.SetBool("Respiration", Input.GetKey(KeyCode.Q));
        animator.SetBool("Defense", Input.GetMouseButtonDown(1));
        animator.SetBool("Jump", Input.GetKey(KeyCode.Space));
    }
}
