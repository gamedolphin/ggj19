using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeroFormatter;

[ZeroFormattable]
public struct InputData {

    [Index(0)]
    public bool Right;

    [Index(1)]
    public bool Left;

    [Index(2)]
    public bool Up;

    [Index(3)]
    public bool Down;

    public InputData (bool right, bool left, bool up, bool down) {
        Right = right;
        Left = left;
        Up = up;
        Down = down;
    }


    public override string ToString() {
        return $"{Right} {Left} {Up} {Down}";
    }
}
