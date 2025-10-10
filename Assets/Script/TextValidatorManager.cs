using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextValidatorManager : MonoBehaviour
{
    // ce script va contenir une liste avec toutes les r�f�rences de InputChecker � v�rifier
    public List<InputValidator> inputValidatorList = new();


    // l� on va cr�er la fonction qui va �tre appel� quand on essaie de v�rifier si on a juste
    public void CheckSoluce()
    {
        //tu vois comment �a marche les for ? 
        //ok en gros �a prend une liste, et �a passe par chaque �l�ment de cette liste
        // t'as une variable qui s'appelle "i", dont la valeur commence � 0, et qui augmente � chaque fin de la boucle for
        // //(elle augmente parce qu'on a mis i++ � la fin, si on avait mis i--, �a ferait moins 1
        // et du coup, la boucle for est r�p�t�e tant que cette condition "i < inputValidatorList.Count" est vrai
        // si elle devient fausse, on sort de la boucle
        // donc l� en gros la boucle va se jouer, tant que i est inf�rieur au nombre d'�l�ment dans la liste inputValidatorList
        for (int i = 0; i < inputValidatorList.Count; i++)
        {
            //si je veux prendre un �l�ment de la liste en particulier, c'est comme en js, je met le nom de la liste
            // puis je met [ "num�ro" ] derri�re
            // l� on utilise la valeur de i comme num�ro
            // donc l� pour chaque input validator dans la liste input validator list, on va v�rifier si il est correct
            // sachant que CheckIfCorrect() c'est la fonction qu'on a cr�� plut�t qui nous retourne un bool�en
            // donc si check if correct retourne une valeur fausse (et que donc quelque chose est faux dans la liste)
            // alors �a veut dire que la soluce n'est pas bonne
            // dans ce cas l�, on arr�te d"analyser la liste, et on appelle la fonction "WrongSoluce" (il faut la cr�er encore)
            // break c'est pour sortir de la boucle for rapidement
            // ok je me suis tromp�e, faut pas utiliser break, faut utiliser "return", �a permet de mettre fin � la fonction direct en gros
            if (inputValidatorList[i].CheckIfCorrect() == false)
            {
                WrongSoluce();
                return;
            }
        }

        // si toute la boucle for se d�roule sans que la soluce soit fausse, alors tout est vrai, donc le joueur a gagn�
        GoodSoluce();
        //donc on appelle GoodSoluce, parce que la soluce est bonne

        //Tu captes ? 
    }

    public void WrongSoluce()
    {
        Debug.Log("WRONG SOLUCE");
    }

    public void GoodSoluce()
    {
        Debug.Log("GOOD SOLUCE");
    }
}
