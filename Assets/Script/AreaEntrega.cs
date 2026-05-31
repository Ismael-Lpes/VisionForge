using UnityEngine;

public class AreaEntrega : MonoBehaviour
{
    public MedicoPedido medico;

    private void OnTriggerEnter(Collider other)
    {
        Instrumento instrumento =
            other.GetComponent<Instrumento>();

        if (instrumento != null)
        {
            medico.VerificarInstrumento(instrumento);
        }
    }
}