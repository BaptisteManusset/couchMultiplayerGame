using UnityEditor;

[CustomEditor(typeof(StateMachine), true)]
public class StateMachineEditor : Editor
{
    private StateMachine m_machine;

    public override void OnInspectorGUI()
    {
        m_machine = target as StateMachine;

        EditorGUILayout.LabelField("Current State",m_machine.CurrentState != null ? m_machine.CurrentState.ToString() : "No state found");
        base.OnInspectorGUI();
    }
}