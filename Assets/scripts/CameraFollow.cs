using System.Collections;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public string targetObjectName = "Player"; // Nome do objeto que a câmera seguirá

    private Transform target; // A referência para o objeto que a câmera seguirá

    void Start()
    {
        // Procura o objeto na cena pelo nome
        GameObject targetObject = GameObject.Find(targetObjectName);

        // Verifica se o objeto foi encontrado
        if (targetObject != null)
        {
            // Obtém o componente Transform do objeto encontrado
            target = targetObject.transform;
        }
        else
        {
            Debug.LogError("Objeto alvo não encontrado na cena.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}