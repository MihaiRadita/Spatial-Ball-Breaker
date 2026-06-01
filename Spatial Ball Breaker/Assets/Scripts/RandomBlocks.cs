using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlocks : MonoBehaviour
{
    private List<Transform> blockTransforms;
    [SerializeField] private List<Color> blockColors;
    [SerializeField] private List<int> blockScores;

    void Start()
    {
        blockTransforms = new List<Transform>();
        foreach(Transform trans in GetComponentsInChildren<Transform>())
        {
            blockTransforms.Add(trans);
        }
        blockTransforms.Remove(this.transform);

        foreach(Transform trans in blockTransforms)
        {
            int chance = UnityEngine.Random.Range(1, 100);
            int elementNumber;
            if(0 < chance && chance <= 60)
            {
                elementNumber = 0;
            }
            else if(60 < chance && chance <= 90)
            {
                elementNumber = 1;
            }
            else
            {
                elementNumber = 2;
            }
            trans.GetComponent<SpriteRenderer>().color = blockColors[elementNumber];
            trans.GetComponent<Block_Script>().ScoreAward = blockScores[elementNumber];
        }
    }
}
