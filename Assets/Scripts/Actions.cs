using UnityEngine;

[CreateAssetMenu(fileName = "Control", menuName = "Configuration/Actions", order = 1)]
public class Actions : ScriptableObject
{
    public string move;
    public string jump;
    public string shoot;
}
