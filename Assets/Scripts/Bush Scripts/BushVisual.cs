using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisual : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bushSprites, fruitSprites, drySprites;
    [SerializeField]
    private SpriteRenderer[] fruitRenderers;

    public enum BushVariant { Green, Cyan, Yellow };
    private BushVariant bushVariant;
    public float hideTimePerFruit = 0.2f;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bushVariant = (BushVariant)Random.Range(0, bushSprites.Length);
        sr.sprite = bushSprites[(int)bushVariant];
        if (Random.Range(0, 2) == 1)
        {
            sr.flipX = true;
        }
        for (int i=0; i<fruitRenderers.Length;i++)
        {
            fruitRenderers[i].sprite = fruitSprites[(int)bushVariant];
            fruitRenderers[i].enabled = false;
        }
    }
    public BushVariant GetBushVariant()
    {
        return bushVariant;
    }
    public void SetToDry()
    {
        sr.sprite = drySprites[(int)bushVariant];

    }
    IEnumerator _HideFruits(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitRenderers[index].enabled = false;
    }
    public void HideFruits()
    {
        float waitTimeForFruit = hideTimePerFruit;
        for (int i=0; i < fruitRenderers.Length; i++)
        {
            StartCoroutine(_HideFruits(waitTimeForFruit,i));
            waitTimeForFruit += hideTimePerFruit;
        }
    }
    public void ShowFruits()
    {
        for(int i=0; i < fruitRenderers.Length; i++)
        {
            fruitRenderers[i].enabled = true;

        }
    }
}
