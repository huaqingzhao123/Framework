using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace XMLib
{
    /// <summary>
    /// UnityApplication
    /// </summary>
    public class UnityApplication : MonoBehaviour
    {
        public Application app;
        public Action onDestroyed;

        #region Main Thread

        protected Queue<Action> actions = new Queue<Action>(32);

        public void Run(Action callback)
        {
            lock (actions)
            {
                actions.Enqueue(callback);
            }
        }

        protected void RunUpdate()
        {
            lock (actions)
            {
                while (actions.Count > 0)
                {
                    Action act = actions.Dequeue();
                    act();
                }
            }
        }

        #endregion Main Thread

        #region Mono

        protected void Update()
        {
            RunUpdate();

            app?.RunUpdate();
        }

        protected void LateUpdate()
        {
            app?.RunLateUpdate();
        }

        protected void FixedUpdate()
        {
            app?.RunFixedUpdate();
        }

        protected void OnDestroy()
        {
            app?.RunDestroy();

            onDestroyed?.Invoke();
        }

        #endregion Mono
    }
}