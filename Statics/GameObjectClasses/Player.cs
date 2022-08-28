using System.Collections;
using System.Collections.Generic;

class Player{
    private float mentalHealth;
    public Player(float mentalHealth){
        this.mentalHealth=mentalHealth;
    }
    public void ChangeMentalHealth(float parameter){
        mentalHealth+=parameter;
    }
}