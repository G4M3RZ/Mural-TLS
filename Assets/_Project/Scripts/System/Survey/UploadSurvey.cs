using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Firebase.Firestore;

public class UploadSurvey : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private UnityEvent onComplete;
    [SerializeField] private SceneController _scene;

    #region Variables
    public string Name { private get; set; }
    public string LastName { private get; set; }
    public string Mail { private get; set; }
    public string Phone { private get; set; }
    #endregion

    public void CompareData()
    {
        bool emptyName = string.IsNullOrWhiteSpace(Name);
        bool emptyLast = string.IsNullOrWhiteSpace(LastName);
        bool validEmail = IsValidEmail(Mail);
        bool incompletePhone = string.IsNullOrWhiteSpace(Phone) ? true : Phone.Length < 9;

        button.interactable = !emptyName && !emptyLast && validEmail && !incompletePhone;
    }
    private bool IsValidEmail(string email)
    {
        try
        {
            string s = email.Replace(" ", string.Empty);
            MailAddress mail = new MailAddress(s);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Upload() => StartCoroutine(SendData());
    private IEnumerator SendData()
    {
        yield return new WaitUntil(() => Initializer.firebaseApp != null);

        CollectionReference collection = Initializer.firestore.Collection("Explosion Creativa");
        Dictionary<string, string> user = new Dictionary<string, string>
        {
            { "nombre", Name },
            { "apellido", LastName },
            { "correo", Mail },
            { "telefono", Phone }
        };

        collection.AddAsync(user);
        onComplete.Invoke();

        yield return new WaitForEndOfFrame();

        _scene?.CutScene(1);
    }
}