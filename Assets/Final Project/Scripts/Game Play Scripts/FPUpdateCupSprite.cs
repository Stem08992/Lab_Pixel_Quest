using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPUpdateCupSprite : MonoBehaviour
{
    public Sprite emptyCup;
    public Sprite iceCup1;
    public Sprite iceCup2;
    public Sprite coffeeCup1;
    public Sprite coffeeCup2;
    public Sprite coffeeCup3;
    public Sprite coffeeCup4;
    public Sprite sodaCup1;
    public Sprite sodaCup2;
    public Sprite sodaCup3;
    public Sprite sodaCup4;
    public Sprite sodaCoffeeCup1;
    public Sprite sodaCoffeeCup2;
    public Sprite sodaCoffeeCup3;


    private SpriteRenderer iceRenderer;
    private SpriteRenderer cupRenderer;
    private FPCupStats stats;

    private string emptyCupName = "EmptyCup";
    private string iceLayerName = "IceLayer";

    private void Start()
    {
       
    }

    private void Update()
    {
        stats = GetComponent<FPCupStats>();

        cupRenderer = gameObject.transform.Find(emptyCupName).GetComponent<SpriteRenderer>();
        iceRenderer = gameObject.transform.Find(iceLayerName).GetComponent<SpriteRenderer>();

        if (stats.ice == 1) {
            iceRenderer.sprite = iceCup1; }
        else if (stats.ice == 2) {
            iceRenderer.sprite = iceCup2;}
        else {
            cupRenderer.sprite = emptyCup;
            iceRenderer.sprite = null; }

        if (stats.coffee == 1 && stats.totalIngredients == 1) {
            cupRenderer.sprite = coffeeCup1; }
        else if(stats.coffee == 2 && stats.totalIngredients == 2) {
            cupRenderer.sprite = coffeeCup2; }
        else if (stats.coffee == 3 && stats.totalIngredients == 3) {
            cupRenderer.sprite = coffeeCup3; }
        else if (stats.coffee >= 4 && stats.totalIngredients >= 4) {
            cupRenderer.sprite = coffeeCup4; }

        if (stats.soda == 1 && stats.totalIngredients == 1) {
            cupRenderer.sprite = sodaCup1; }
        else if(stats.soda == 2 && stats.totalIngredients == 2) {
            cupRenderer.sprite = sodaCup2; }
        else if (stats.soda == 3 && stats.totalIngredients == 3) {
            cupRenderer.sprite = sodaCup3; }
        else if (stats.soda >= 4 && stats.totalIngredients >= 4) {
            cupRenderer.sprite = sodaCup4; }

        if ((stats.soda >= 1 && stats.coffee >= 1) && stats.totalIngredients == 2) {
            cupRenderer.sprite = sodaCoffeeCup1; }
        else if ((stats.soda >= 1 && stats.coffee >= 1) && stats.totalIngredients == 3) {
            cupRenderer.sprite = sodaCoffeeCup2;
        }
        else if ((stats.soda >= 1 && stats.coffee >= 1) && stats.totalIngredients == 4) {
            cupRenderer.sprite = sodaCoffeeCup3;
        }

    }
}
