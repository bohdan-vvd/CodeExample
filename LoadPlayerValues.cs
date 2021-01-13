using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Animals.Networking.Database
{
    public class LoadPlayerValues : MonoBehaviour
    {
        public FirebaseDataHandler firebase;
        public string sceneForSave;
        public string sceneForNoSave;

        private Coroutine coroutine;

        public IEnumerator LoadSceneCoroutine()
        {
            var saveExistTask = firebase.SaveExist();
            yield return new WaitUntil(() => saveExistTask.IsCompleted);

            if (saveExistTask.Result)
            {
                SceneManager.LoadScene(1);
            }

            else
            {
                Debug.LogError("Load data failed");
            }
        }
    }
}