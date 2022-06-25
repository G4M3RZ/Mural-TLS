using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Achievements : MonoBehaviour
{
    [System.Serializable] private struct Lock
    {
        public bool complete;
        public List<int> index;
        public List<bool> enable;
    }

    [SerializeField] private Lock _lock;
    [SerializeField] private List<Init_Animator> _elements;
    [SerializeField] private List<CustomAchievement> achievements;
    [Space]
    [SerializeField] private TextMeshProUGUI _clue;
    [SerializeField] private UnityEvent onUnlock, onComplete;

    private void Start()
    {
        SaveSystem.Load(ref _lock, FilePath.player);
        UpdateAchivements();
    }

    public void UpdateAchivements()
    {
        bool incomplete = false;
        for (int i = 0; i < achievements.Count; i++)
        {
            CustomAchievement a = achievements[i];

            if (_lock.index.Contains(a.index))
            {
                if (!_lock.enable[a.index])
                {
                    _lock.enable[a.index] = true;
                    _elements[a.index].SetState(a.start);
                    SaveSystem.WriteJson(_lock, FilePath.player);
                }
                else
                {
                    _elements[a.index].SetState(a.complete);
                }
            }
            else
            {
                if (incomplete) continue;
                _clue?.SetText(a.message);
                incomplete = true;
            }
        }

        StartCoroutine(Delay(!incomplete));
    }
    private IEnumerator Delay(bool complete)
    {
        yield return new WaitForSeconds(1f);
        if (complete && !_lock.complete)
        {
            Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSci-QfGA1j2gi4V6huE4ZwWYmvd4W_8nmtFJE8yo2mswH6flg/viewform");
            _lock.complete = true;
            SaveSystem.WriteJson(_lock, FilePath.player);
        } /*onComplete.Invoke();*/
    }
    public void Unlock(CustomAchievement achievement)
    {
        if (_lock.complete) return;
        if (!achievements.Contains(achievement)) return;

        int index = achievement.index;
        if(!_lock.index.Contains(index))
        {
            _lock.index[index] = achievement.index;
            onUnlock.Invoke();

            //if (!_lock.enable.Contains(false)) onComplete.Invoke();

            SaveSystem.WriteJson(_lock, FilePath.player);
        }
    }
    public void Complete()
    {
        _lock.complete = true;
        SaveSystem.WriteJson(_lock, FilePath.player);
    }
}