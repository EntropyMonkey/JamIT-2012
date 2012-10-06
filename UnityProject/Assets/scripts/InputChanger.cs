using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputChanger : MonoBehaviour {

    private List<KeyCode> NormalKeys = new List<KeyCode>();

	// Use this for initialization
	void Start () {
        NormalKeys.Add(KeyCode.A);
        NormalKeys.Add(KeyCode.B);
        NormalKeys.Add(KeyCode.C);
        NormalKeys.Add(KeyCode.D);
        NormalKeys.Add(KeyCode.E);
        NormalKeys.Add(KeyCode.F);
        NormalKeys.Add(KeyCode.G);
        NormalKeys.Add(KeyCode.H);
        NormalKeys.Add(KeyCode.I);
        NormalKeys.Add(KeyCode.J);
        NormalKeys.Add(KeyCode.K);
        NormalKeys.Add(KeyCode.L);
        NormalKeys.Add(KeyCode.M);
        NormalKeys.Add(KeyCode.N);
        NormalKeys.Add(KeyCode.O);
        NormalKeys.Add(KeyCode.P);
        NormalKeys.Add(KeyCode.Q);
        NormalKeys.Add(KeyCode.R);
        NormalKeys.Add(KeyCode.S);
        NormalKeys.Add(KeyCode.T);
        NormalKeys.Add(KeyCode.U);
        NormalKeys.Add(KeyCode.V);
        NormalKeys.Add(KeyCode.X);
        NormalKeys.Add(KeyCode.Y);
        NormalKeys.Add(KeyCode.Z);
        NormalKeys.Add(KeyCode.W);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
            ShuffleKeys();
	}

    public void ShuffleKeys()
    {
        var unuseableKeys = new List<KeyCode>();
        for (int i = 0; i < ChangingInput.Instances.Count; ++i)
        {
            unuseableKeys.Add(ChangingInput.Instances[i].JumpKey);
            unuseableKeys.Add(ChangingInput.Instances[i].AccelerateKey);
        }

        var useableKeys = new List<KeyCode>(NormalKeys);
        useableKeys.RemoveAll(k => unuseableKeys.Contains(k));

        for (int i = 0; i < useableKeys.Count; ++i) //Randomize array
        {
            int newPos = Random.Range(0, useableKeys.Count);
            KeyCode otherKey = useableKeys[newPos];
            useableKeys[newPos] = useableKeys[i];
            useableKeys[i] = otherKey;
        }

        Debug.Log("--------------");
        for (int i = 0; i < ChangingInput.Instances.Count; ++i) //Set new keys
        {
            ChangingInput.Instances[i].JumpKey = useableKeys[i*2];
            ChangingInput.Instances[i].AccelerateKey = useableKeys[i * 2 + 1];
            Debug.Log(i + ": " + ChangingInput.Instances[i].JumpKey+ " , " + ChangingInput.Instances[i].AccelerateKey);
        }
    }
}
