using Fusion;
using UnityEngine;

public class NetworkRig : NetworkBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private Transform hardwareHead;
    private Transform hardwareLeftHand;
    private Transform hardwareRightHand;

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            var rig = FindObjectOfType<OVRCameraRig>();

            hardwareHead = rig.centerEyeAnchor;
            hardwareLeftHand = rig.leftHandAnchor;
            hardwareRightHand = rig.rightHandAnchor;
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (Object.HasInputAuthority)
        {
            head.position = hardwareHead.position;
            head.rotation = hardwareHead.rotation;

            leftHand.position = hardwareLeftHand.position;
            leftHand.rotation = hardwareLeftHand.rotation;

            rightHand.position = hardwareRightHand.position;
            rightHand.rotation = hardwareRightHand.rotation;
        }
    }
}