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
		int count = 1;
		string curr;
		ReadWord word = new ReadWord();

		//Open file
		System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine("JSON Files", "test"));

		//Read file and store each line in the corresponding variable
		while ((curr = file.ReadLine ()) != null) {
			int i = count % 6;
			if (i == 5)
				word.Id = curr;
			else if (i == 4)
				word.Sub_bass = curr;
			else if (i == 3)
				word.Bass = curr;
			else if (i == 2)
				word.Mid = curr;
			else if (i == 1)
				word.High = curr;
			else
				word.Name = curr;
			count++;
		}

		file.Close ();

		//Print values to console -- will be used in another way later
		System.Console.WriteLine (word.Id);
		System.Console.WriteLine (word.Sub_bass);
		System.Console.WriteLine (word.Bass);
		System.Console.WriteLine (word.Mid);
		System.Console.WriteLine (word.High);
		System.Console.WriteLine (word.Name);

	}

	class ReadWord {
		private string id;
		private string sub_bass;
		private string bass;
		private string mid;
		private string high;
		private string name;

		public string Id
		{
			get { return id; }
			set { id = value; }
		}
		public string Sub_bass
		{
			get { return sub_bass; }
			set { sub_bass = value; }
		}
		public string Bass
		{
			get { return bass; }
			set { bass = value; }
		}
		public string Mid
		{
			get { return mid; }
			set { mid = value; }
		}
		public string High
		{
			get { return high; }
			set { high = value; }
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	}

}