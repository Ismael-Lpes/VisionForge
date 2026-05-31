using UnityEngine;

public class AreaProximidade : MonoBehaviour
{
    public MedicoPedido medico;

    private bool jogadorEntrou = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entrou: " + other.name);

        if (other.CompareTag("Player") && !jogadorEntrou)
        {
            jogadorEntrou = true;

            Debug.Log("Jogador entrou na área!");

            medico.PedirNovoInstrumento();
        }
    }
}