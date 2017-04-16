using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("I am alive!");
		int time = 0;
		Main();

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
		System.IO.StreamReader file = new System.IO.StreamReader("sample.txt");


		//Read file and store each line in the corresponding variable
		while ((curr = file.ReadLine ()) != null) {
			int i = count;
			if (count == 1)
				word.Id = curr;
			else if (i == 2)
				word.Sub_bass = curr;
			else if (i == 3)
				word.Bass = curr;
			else if (i == 4)
				word.Mid = curr;
			else if (i == 5)
				word.High = curr;
			else if (i == 6)
				word.Name = curr;
			else
				word.Next = curr;
			count++;
		}

		file.Close ();

		change_name (word.Name);
		change_size (word.Bass);
		change_color (word.High);
		change_bold (word.Mid);
		change_pop (word.Sub_bass);

		/*Print values to console -- will be used in another way later
		Debug.Log (word.Id);
		Debug.Log (word.Sub_bass);
		Debug.Log (word.Bass);
		Debug.Log (word.Mid);
		Debug.Log (word.High);
		Debug.Log (word.Name); */

	}

	class ReadWord {
		private string id;
		private string sub_bass;
		private string bass;
		private string mid;
		private string high;
		private string name;
		private string next;

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
		public string Next
		{
			get { return next; }
			set { next = value; }
		}
	}

	static void change_name(string value){
		TextMesh t = GameObject.Find("NewText").GetComponent<TextMesh>();
		t.text = value;
	}

	static void change_size (string value) {
		int fontsize = Int32.Parse(value) * 40 + 10;
		TextMesh t = GameObject.Find("NewText").GetComponent<TextMesh>();
		t.fontSize = fontsize;
	}

	static void change_color(string input) {
		int value = Int32.Parse (input);
		TextMesh t = GameObject.Find("NewText").GetComponent<TextMesh>();

		if (value < 3) {
			t.color = new Color (1f, .8f, .8f);

		}
		else if (value >= 3 && value < 4){
			t.color = new Color (1f, .6f, .6f);

		}
		else if (value >= 4 && value < 5){
			t.color = new Color (1f, .4f, .4f);

		}
		else if (value >= 5){
			t.color = new Color (1f, .2f, .2f);

		}
	}

	static void change_bold(string value) {
		int val = Int32.Parse (value);
		TextMesh t = GameObject.Find ("NewText").GetComponent<TextMesh> ();

		if (val < 2) {
			t.fontStyle = FontStyle.Normal;
		} else {
			t.fontStyle = FontStyle.Bold;
		}
	}

	static void change_pop(string value) {
		int val = Int32.Parse (value);
		TextMesh t = GameObject.Find ("NewText").GetComponent<TextMesh> ();

		if (val > 15 && val < 20) {
			t.fontStyle = FontStyle.Normal;
			System.Threading.Thread.Sleep(500);
			t.fontStyle = FontStyle.Bold;
			System.Threading.Thread.Sleep(500);
			t.fontStyle = FontStyle.Normal;
			System.Threading.Thread.Sleep(500);
			t.fontStyle = FontStyle.Bold;
		} else if (val >= 20 && val < 25){
			t.fontSize = 120;
			System.Threading.Thread.Sleep(100);
			t.fontSize = 100;
			System.Threading.Thread.Sleep(100);
			t.fontSize = 120;
			System.Threading.Thread.Sleep(100);
			t.fontSize = 100;
		} else if (val >= 25){
			t.fontSize = 120;
			System.Threading.Thread.Sleep(100);
			t.fontSize = 100;
			System.Threading.Thread.Sleep(100);
			t.fontStyle = FontStyle.Normal;
			System.Threading.Thread.Sleep(100);
			t.fontStyle = FontStyle.Bold;
			System.Threading.Thread.Sleep(100);
			t.fontSize = 120;
			System.Threading.Thread.Sleep(100);
			t.fontSize = 100;
			System.Threading.Thread.Sleep(100);
			t.fontStyle = FontStyle.Normal;
			System.Threading.Thread.Sleep(100);
			t.fontStyle = FontStyle.Bold;
		}
	}
}