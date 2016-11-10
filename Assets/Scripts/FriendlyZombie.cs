using UnityEngine;
using System.Collections;

public class FriendlyZombie : CrookedZombie {
    override protected void OnMouseDown() {
        if (!GameController.IsGameRunning()) return;
        GameController.SpendLives(3);
        Kill();
    }
}
