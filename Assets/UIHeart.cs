using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeart : MonoBehaviour
{
    public bool grey = false;

    public void BecomeGrey()
    {
        GetComponent<Animator>().Play("Grey");
        grey = true;
    }

    public void BecomeRed()
    {
        GetComponent<Animator>().Play("Red");
        grey = false;
    }

}
