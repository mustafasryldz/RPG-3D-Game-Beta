using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Abilities.Filters
{
    [CreateAssetMenu(fileName = "Tag Filter", menuName = "Abilities/Filters/TagFilter", order = 0)]
    public class TagFilter : FilterStrategy
    {
        [SerializeField] string tagToFilter = "";

        public override IEnumerable<GameObject> Filter(IEnumerable<GameObject> objectsToFilter)
        {
            foreach(var gameObjct in objectsToFilter)
            {
                if(gameObjct.CompareTag(tagToFilter))
                {
                    yield return gameObjct;
                }
            }
        }
    }

}
