using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnableMenu : MonoBehaviour
{
    [SerializeField] Vector3 rightSidePosition; //use this to translate when holding with left hand

    public GameObject menu;

    private bool onRightHand;
    private bool isMenuOnRight;

    public void GetHoldingHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.gameObject.name.Equals("RightHand Controller"))
            onRightHand = true;
        else
            onRightHand = false;
    }

    //make button work when menu is closed, object is grabbed and the button must be touched by a controller
    public void OpenMenu()
    {
        //move menu on the right side of the gun
        if (onRightHand)
        {
            if (isMenuOnRight)
            {
                menu.transform.Translate(-rightSidePosition, Space.Self);
                isMenuOnRight = false;
            }

        }
        else
        {
            if (!isMenuOnRight)
            {
                menu.transform.Translate(rightSidePosition, Space.Self);
                isMenuOnRight = true;
            }
        }
        menu.SetActive(true);
    }
}
