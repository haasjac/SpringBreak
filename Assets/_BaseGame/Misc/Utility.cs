using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility {

    public static float SignWithZero(float number) {
        return number < 0 ? -1 : (number > 0 ? 1 : 0);
    }
}
