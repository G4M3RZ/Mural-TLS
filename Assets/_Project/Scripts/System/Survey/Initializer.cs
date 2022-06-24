//using System.Collections;
//using UnityEngine;
//using Firebase;
//using Firebase.Firestore;

//public class Initializer : MonoBehaviour
//{
//    public static FirebaseApp firebaseApp;
//    public static FirebaseFirestore firestore;

//    private IEnumerator Start()
//    {
//        var task = FirebaseApp.CheckAndFixDependenciesAsync();
//        yield return new WaitUntil(() => task.IsCompleted);

//        if(task.Result == DependencyStatus.Available)
//        {
//            firebaseApp = FirebaseApp.DefaultInstance;
//            firestore = FirebaseFirestore.DefaultInstance;
//            print("Firebase Initilized");
//        }
//        else
//        {
//            print(string.Format("Could not resolve all Firebase dependencies: {0}", task.Result));
//        }
//    }
//}