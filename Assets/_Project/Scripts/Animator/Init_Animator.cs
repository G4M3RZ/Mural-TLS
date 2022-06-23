using UnityEngine;

public enum States
{
    init, next, last, complete
}
[RequireComponent(typeof(Animator))]
public class Init_Animator : MonoBehaviour
{
    private States _last;
    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    public void SetState(States state)
    {
        if (state.Equals(_last)) return;

        _anim?.Play(state.ToString());
        _last = state;
    }
}