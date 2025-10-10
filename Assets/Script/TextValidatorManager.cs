using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextValidatorManager : MonoBehaviour
{
    // ce script va contenir une liste avec toutes les références de InputChecker à vérifier
    public List<InputValidator> inputValidatorList = new();


    // là on va créer la fonction qui va être appelé quand on essaie de vérifier si on a juste
    public void CheckSoluce()
    {
        //tu vois comment ça marche les for ? 
        //ok en gros ça prend une liste, et ça passe par chaque élément de cette liste
        // t'as une variable qui s'appelle "i", dont la valeur commence à 0, et qui augmente à chaque fin de la boucle for
        // //(elle augmente parce qu'on a mis i++ à la fin, si on avait mis i--, ça ferait moins 1
        // et du coup, la boucle for est répétée tant que cette condition "i < inputValidatorList.Count" est vrai
        // si elle devient fausse, on sort de la boucle
        // donc là en gros la boucle va se jouer, tant que i est inférieur au nombre d'élément dans la liste inputValidatorList
        for (int i = 0; i < inputValidatorList.Count; i++)
        {
            //si je veux prendre un élément de la liste en particulier, c'est comme en js, je met le nom de la liste
            // puis je met [ "numéro" ] derrière
            // là on utilise la valeur de i comme numéro
            // donc là pour chaque input validator dans la liste input validator list, on va vérifier si il est correct
            // sachant que CheckIfCorrect() c'est la fonction qu'on a créé plutôt qui nous retourne un booléen
            // donc si check if correct retourne une valeur fausse (et que donc quelque chose est faux dans la liste)
            // alors ça veut dire que la soluce n'est pas bonne
            // dans ce cas là, on arrête d"analyser la liste, et on appelle la fonction "WrongSoluce" (il faut la créer encore)
            // break c'est pour sortir de la boucle for rapidement
            // ok je me suis trompée, faut pas utiliser break, faut utiliser "return", ça permet de mettre fin à la fonction direct en gros
            if (inputValidatorList[i].CheckIfCorrect() == false)
            {
                WrongSoluce();
                return;
            }
        }

        // si toute la boucle for se déroule sans que la soluce soit fausse, alors tout est vrai, donc le joueur a gagné
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
