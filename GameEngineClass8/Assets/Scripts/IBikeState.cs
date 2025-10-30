using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBikeState
{
    void Handle(BikeController controller);
}
/*
 * Passes an instance of BikeController in the Handle() method.
 * This allows state classes to access public properties of BikeController
 */
