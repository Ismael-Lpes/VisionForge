using Fusion;
using UnityEngine;
public class NetworkedGrabbable : NetworkBehaviour
{
 [Networked] public NetworkBool IsGrabbed { get; set; }
 [Networked] public PlayerRef GrabbedBy { get; set; }
 [Networked] public Vector3 Position { get; set; }
 [Networked] public Quaternion Rotation { get; set; }

 private Rigidbody rb;

 public override void Spawned()
 {
 rb = GetComponent<Rigidbody>();
 }

 public override void FixedUpdateNetwork()
 {
 if (IsGrabbed)
 {
 // Desativa física enquanto segurado
 rb.isKinematic = true;

 // Sincroniza posição
 transform.position = Position;
 transform.rotation = Rotation;
 }
 else
 {
 rb.isKinematic = false;
 }
 }

 [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
 public void RPC_Grab(PlayerRef player, Vector3 position, Quaternion
rotation)
 {
 IsGrabbed = true;
 GrabbedBy = player;
 Position = position;
 Rotation = rotation;
 }

 [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
 public void RPC_Release()
 {
 IsGrabbed = false;
 }
}