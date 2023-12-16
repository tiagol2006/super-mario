using UnityEngine;

public class MovimentoLateral : MonoBehaviour
{
    public float velocidadeMovimento = 5f;
    public float forcaSalto = 10f;
    public float alturaMaxima = 2f; // Altura máxima do salto
    private Rigidbody2D rb;
    private bool estaNoChao;
    public Transform checarChao;
    public float checarChaoRaio = 0.1f;
    public LayerMask camadaChao;
    public Transform bordaEsquerda; // Objeto representando a borda esquerda da cena
    public Transform bordaDireita; // Objeto representando a borda direita da cena
    private bool pulando = true; // Para controlar o estado do salto

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bordaEsquerda = GameObject.Find("BordaEsquerda").transform; // Nome do objeto representando a borda esquerda
        bordaDireita = GameObject.Find("BordaDireita").transform; // Nome do objeto representando a borda direita
    }

    void Update()
    {
      
{
    estaNoChao = Physics2D.OverlapCircle(checarChao.position, checarChaoRaio, camadaChao);

    float moverHorizontal = Input.GetAxis("Horizontal");
    Vector2 movimento = new Vector2(moverHorizontal * velocidadeMovimento, rb.velocity.y);
    rb.velocity = movimento;

    // Restringir o movimento horizontal às bordas da cena
    if (transform.position.x < bordaEsquerda.position.x)
    {
        transform.position = new Vector2(bordaEsquerda.position.x, transform.position.y);
    }
    else if (transform.position.x > bordaDireita.position.x)
    {
        transform.position = new Vector2(bordaDireita.position.x, transform.position.y);
    }

    // Lógica do salto
    if (estaNoChao)
    {
        pulando = true;
    }
    if (pulando && Input.GetKeyDown(KeyCode.Space))
    {
        rb.velocity = new Vector2(rb.velocity.x, forcaSalto);
        pulando = false;
    }

    if (!estaNoChao && rb.velocity.y <= 0)
    {
        rb.gravityScale = 2f; // Ajuste esse valor conforme necessário para controlar a velocidade de queda
    }
    else
    {
        rb.gravityScale = 1f; // Volta para a gravidade normal
    }
}
    }
}