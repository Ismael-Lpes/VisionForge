using UnityEngine;

public class MedicoPedido : MonoBehaviour
{
    public TipoInstrumento instrumentoAtual;

    public AudioSource audioSource;

    [Header("Áudios Instrumentos")]
    public AudioClip bisturiAudio;
    public AudioClip afastadorAudio;
    public AudioClip tesouraAudio;
    public AudioClip pincaTesouraAudio;
    public AudioClip pincaAudio;

    [Header("Áudios Feedback")]
    public AudioClip corretoAudio;
    public AudioClip erradoAudio;

    public void PedirNovoInstrumento()
    {
        int valor = Random.Range(0, 5);

        instrumentoAtual = (TipoInstrumento)valor;

        TocarAudioInstrumento();
    }

    void TocarAudioInstrumento()
    {
        switch (instrumentoAtual)
        {
            case TipoInstrumento.Bisturi:
                audioSource.PlayOneShot(bisturiAudio);
                break;

            case TipoInstrumento.Afastador:
                audioSource.PlayOneShot(afastadorAudio);
                break;

            case TipoInstrumento.Tesoura:
                audioSource.PlayOneShot(tesouraAudio);
                break;

            case TipoInstrumento.PincaTesoura:
                audioSource.PlayOneShot(pincaTesouraAudio);
                break;

            case TipoInstrumento.Pinca:
                audioSource.PlayOneShot(pincaAudio);
                break;
        }
    }

    public void VerificarInstrumento(Instrumento instrumento)
    {
        if (instrumento.tipo == instrumentoAtual)
        {
            audioSource.PlayOneShot(corretoAudio);

            Invoke(nameof(PedirNovoInstrumento), 2f);
        }
        else
        {
            audioSource.PlayOneShot(erradoAudio);
        }
    }
}