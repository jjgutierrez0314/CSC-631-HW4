﻿using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {

	private GameObject mainObject;
	// Window Properties
	private float width = 280;
	private float height = 100;
	// Other
	private string user_id = "";
	private string password = "";
	private Rect windowRect;
	private bool isHidden;
	private MessageQueue msgQueue;
	private ConnectionManager cManager;

	void Awake () {
		mainObject = GameObject.Find ("MainObject");
		cManager = mainObject.GetComponent<ConnectionManager> ();
		msgQueue = mainObject.GetComponent<MessageQueue> ();
		msgQueue.AddCallback (Constants.SMSG_REGISTER, ResponseRegister);
	}

	void OnGUI () {
		// Login Interface
		if (!isHidden) {
			windowRect = new Rect ((Screen.width - width) / 2, Screen.height / 2 - height, width, height);
			windowRect = GUILayout.Window ((int) Constants.GUI_ID.Login, windowRect, MakeWindow, "Register");
			if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
				Submit ();
			}

		}
	}

	void MakeWindow (int id) {
		GUILayout.Label ("User ID");
		GUI.SetNextControlName ("username_field");
		user_id = GUI.TextField (new Rect (10, 45, windowRect.width - 20, 25), user_id, 25);
		GUILayout.Space (30);
		GUILayout.Label ("Password");
		GUI.SetNextControlName ("password_field");
		password = GUI.PasswordField (new Rect (10, 100, windowRect.width - 20, 25), password, "*" [0], 25);
		GUILayout.Space (75);
		if (GUI.Button (new Rect (windowRect.width / 2 - 110, 135, 100, 30), "Submit")) {
			Submit ();
		}
		if (GUI.Button (new Rect (windowRect.width / 2 + 10, 135, 100, 30), "Login Page")) {
			SceneManager.LoadScene ("Login");;
		}
	}

	public void Submit () {
		user_id = user_id.Trim ();
		password = password.Trim ();
		Debug.Log ("Client RequestRegister has been sent to Server");
		if (user_id.Length == 0) {
			Debug.Log ("User ID Required");
			GUI.FocusControl ("username_field");
		} else if (password.Length == 0) {
			Debug.Log ("Password Required");
			GUI.FocusControl ("password_field");
		} else {
			cManager.send (requestRegister (user_id, password));
		}
	}

	public RequestRegister requestRegister (string username, string password) {
		RequestRegister request = new RequestRegister ();
		request.send (username, password);
		return request;
	}

	public void ResponseRegister (ExtendedEventArgs eventArgs) {
		Debug.Log ("Debug line here");
		ResponseRegisterEventArgs args = eventArgs as ResponseRegisterEventArgs;
		if (args.status == 0) {
			Constants.USER_ID = args.user_id;
			Debug.Log ("Successful Register response : " + args.ToString ());
			
			EditorUtility.DisplayDialog ("Registration Successful", "You have successfully registered.\nClick Ok to continue execution and see responses on console", "Ok");
		
			SceneManager.LoadScene ("Login");
		} else {
			Debug.Log ("Registration Failed");
			
			EditorUtility.DisplayDialog ("Registration Failed", "User name is taken.", "Ok");
			
		}
	}

	public void Show () {
		isHidden = false;
	}

	public void Hide () {
		isHidden = true;
	}

	// Update is called once per frame
	void Update () { }
}