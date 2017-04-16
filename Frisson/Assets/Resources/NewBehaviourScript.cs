using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	static void Main() {
		//Initialize new variables
		int count = 0;
		string curr;
		string id = null;
		string start = null;
		string end = null;
		string text = null;

		//Open file
		System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine("JSON Files", "test"));

		//Read file and store each line in the corresponding variable
		while ((curr = file.ReadLine ()) != null) {
			int i = count % 4;
			if (i == 4)
				id = curr;
			else if (i == 3)
				start = curr;
			else if (i == 2)
				end = curr;
			else
				text = curr;

			count++;
		}

		file.Close ();

		//Print values to console -- will be used in another way later
		System.Console.WriteLine (id);
		System.Console.WriteLine (start);
		System.Console.WriteLine (end);
		System.Console.WriteLine (text);
		System.Console.WriteLine ("Hello");

	}

}