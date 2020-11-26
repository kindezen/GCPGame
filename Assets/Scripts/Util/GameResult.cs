using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Result Data", menuName = "ScriptableObjects/Game Result", order = 1)]
public class GameResult : ScriptableObject
{
    public int score, maxScore;
    
    public List<Trash> failedTrashes;

    public void Init(){
        score = maxScore = 0;
        failedTrashes = new List<Trash>();
    }
}