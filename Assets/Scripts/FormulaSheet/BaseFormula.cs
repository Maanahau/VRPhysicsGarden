using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public abstract class BaseFormula : MonoBehaviour
    {
        [SerializeField] protected Button computeButton;
        [SerializeField] protected GameObject valueDatacardPrefab;
        [SerializeField] protected Transform sheetRootTransform;

        protected ReferenceProvider refProvider;
        protected GameObject outputSocket;

        // Start is called before the first frame update
        protected virtual void Awake()
        {
            refProvider = sheetRootTransform.parent.GetComponent<ReferenceProvider>();
            outputSocket = refProvider.outputSocket;
        }
        protected abstract void Update();
        public abstract void Compute();
        public abstract void SetupSockets();

        public void DisableSockets()
        {
            refProvider.valueSocket1.SetActive(false);
            refProvider.valueSocket2.SetActive(false);
            refProvider.valueSocket3.SetActive(false);
            refProvider.valueSocket4.SetActive(false);
        }

    }

