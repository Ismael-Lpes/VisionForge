using Fusion;
using UnityEngine;
public class AvatarNetworked : NetworkBehaviour
{
 [Header("Referências VR")]
 public Transform vrHead;
 public Transform vrLeftHand;
 public Transform vrRightHand;

 [Header("Representação Visual")]
 public Transform headVisual;
 public Transform leftHandVisual;
 public Transform rightHandVisual;

 [Networked] public Vector3 HeadPosition { get; set; }
 [Networked] public Quaternion HeadRotation { get; set; }
 [Networked] public Vector3 LeftHandPosition { get; set; }
 [Networked] public Quaternion LeftHandRotation { get; set; }
 [Networked] public Vector3 RightHandPosition { get; set; }
 [Networked] public Quaternion RightHandRotation { get; set; }

 public override void FixedUpdateNetwork()
 {
 if (Object.HasInputAuthority)
 {
 // Captura posição do VR local
 HeadPosition = vrHead.position;
 HeadRotation = vrHead.rotation;
 LeftHandPosition = vrLeftHand.position;
 LeftHandRotation = vrLeftHand.rotation;
 RightHandPosition = vrRightHand.position;
 RightHandRotation = vrRightHand.rotation;
 }
 else
 {
 // Aplica posição sincronizada nos outros clientes
 headVisual.position = HeadPosition;
 headVisual.rotation = HeadRotation;
 leftHandVisual.position = LeftHandPosition;
 leftHandVisual.rotation = LeftHandRotation;
 rightHandVisual.position = RightHandPosition;
 rightHandVisual.rotation = RightHandRotation;
 }
 }

 public override void Spawned()
 {
 // Desativa câmera em avatares remotos
 if (!Object.HasInputAuthority)
 {
 vrHead.GetComponent<Camera>().enabled = false;
 }
 }
}