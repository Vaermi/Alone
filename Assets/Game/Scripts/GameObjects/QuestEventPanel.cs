using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEventPanel : MonoBehaviour
{
    QuestEventPanel qep;
    //public TextMeshProUi Quests;
    // Start is called before the first frame update
    void Start()
    {
        qep = qep.GetComponent<QuestEventPanel>();
        CanvasRenderer renderer = qep.GetComponent<CanvasRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
