using System.Collections;
using System;

public class Furo {
    public enum FuroType {
        Source,
        Ground,
        Normal
    }
    FuroType type = Furo.Normal; //Define o defauld
    int x;
    int y;

    public static bool hasConectionWith(this,Furo candidate) {
        if(this.y == candidate.y) {
            return true;
        }
        else {
            return false;
        }
    }
}
