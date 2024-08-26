using UnityEngine;

public class GameManager:MonoBehaviour {
    [SerializeField] internal int Level;

    [SerializeField] StartingPoint startingPoint;
    [SerializeField] LevelStartScreen startScreenUI;
    [SerializeField] LevelCompleteScreen levelCompleteScreenUI;

    [ContextMenu("StartGame")]
    public void StartGame() {
        startingPoint.LaunchPlayer();
        startScreenUI.SetScreen(false);
    }

    internal void OnLevelCompleted() { 
        levelCompleteScreenUI.SetScreen(true);
    }

    internal void OnClickNextLevelButton() { 
        
    }
}

