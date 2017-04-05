using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();

    public InputAction[] inputActions;
    public Text displayText;

    List<string> actionLog = new List<string>();

	void Awake ()
    {
        roomNavigation = GetComponent<RoomNavigation>();
	}

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

 

    public void DisplayLoggedText ()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
    }
	
    public void DisplayRoomText ()
    {
        ClearCollectionsForNewRoom();
        UnpackRoom();
        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn (combinedText);
    }

    void UnpackRoom ()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionsForNewRoom ()
    {
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn (string stringToAdd)
    {
        actionLog.Add (stringToAdd + "\n");
    }

	void Update () {
		
	}
}
