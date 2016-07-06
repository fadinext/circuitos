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
	public int X { get; protected set; }
	public int Y { get; protected set; }

	public bool hasConectionWith(Furo candidate) {
        if(this.X == candidate.X) {
            return true;
        }
        else {
            return false;
        }
    }

	public Furo(Protoboard protoboard, int x, int y) {
		this.protoboard = protoboard;
		this.X = x;
		this.Y = y;
	}
}