using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public static Controles Instance { set; get; }
    private bool w, a, s, d, space;
    public bool WKey { get { return w; } }
    public bool AKey { get { return a; } }
    public bool SKey { get { return s; } }
    public bool DKey { get { return d; } }
    public bool FireKey { get { return space; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        w = a = s = d = space = false;

        if (Input.GetKeyDown("w"))
        {
            w = true;
        }
        else if (Input.GetKeyUp("w"))
        {
            w = false;
        }

        if (Input.GetKeyDown("a"))
        {
            a = true;
        }
        else if (Input.GetKeyUp("a"))
        {
            a = false;
        }

        if (Input.GetKeyDown("s"))
        {
            s = true;
        }
        else if (Input.GetKeyUp("s"))
        {
            s = false;
        }

        if (Input.GetKeyDown("d"))
        {
            d = true;
        }
        else if (Input.GetKeyUp("d"))
        {
            d = false;
        }

        if (Input.GetKeyDown("space"))
        {
            space = true;
        }
        else if (Input.GetKeyUp("space"))
        {
            space = false;
        }
    }

}
