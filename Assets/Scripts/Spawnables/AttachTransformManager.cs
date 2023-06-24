using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachTransformManager : MonoBehaviour
{
    [SerializeField] GameObject attachTransform;

    public void RotateAttachTransform(SelectEnterEventArgs args)
    {
        attachTransform.transform.LookAt(args.interactorObject.transform);
        attachTransform.transform.Rotate(-30f, 180f, 0);
    }

}
