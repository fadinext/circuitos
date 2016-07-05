using UnityEngine;
using System.Collections;
using System;

public class Furo {
    public enum FuroType {
        Source,
        Ground,
        Normal
    }
    FuroType type = FuroType.Normal; //Define o default

	Protoboard protoboard;
    int x;
    int y;

    public bool hasConectionWith(Furo candidate) {
        if(this.x == candidate.x) {
            return true;
        }
        else {
            return false;
        }
    }

	public Furo(Protoboard protoboard, int x, int y) {
		this.protoboard = protoboard;
		this.x = x;
		this.y = y;
	}
}
