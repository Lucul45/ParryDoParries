using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlatformBehavior : MonoBehaviour
{
    private PlatformEffector2D _effector;

    private int _layerP1Shifted = 0;
    private int _layerP2Shifted = 0;

    private bool _p1IsInputingDown = false;
    private bool _p2IsInputingDown = false;

    public bool P1IsInputingDown
    {
        get { return _p1IsInputingDown; }
        set { _p1IsInputingDown = value; }
    }
    public bool P2IsInputingDown
    {
        get { return _p2IsInputingDown; }
        set { _p2IsInputingDown = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _effector = GetComponent<PlatformEffector2D>();

        int layerP1 = LayerMask.NameToLayer("Player1"); // ici ça vaut 7 par ex
        int layerP2 = LayerMask.NameToLayer("Player2"); // ici ça vaut 8 par ex

        _layerP1Shifted = 1 << layerP1; //   1000 0000
        _layerP2Shifted = 1 << layerP2; // 1 0000 0000
    }

    // Update is called once per frame
    void Update()
    {
       /* 
        int mask = 0;

        if (_p1IsInputingDown)
        {
            mask |= _layerP1Shifted; // on OR ici, donc mask devient 1000 0000
        }
        if (_p2IsInputingDown)
        {
            mask |= _layerP2Shifted; // on OR ici, donc mask devient 1 0000 0000 ou 1 1000 000
        }

        _effector.colliderMask = mask;
        */
    }


}
