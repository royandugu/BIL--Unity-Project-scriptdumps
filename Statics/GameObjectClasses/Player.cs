class Player{
    private float mentalHealth;
    private byte monologueStatus;
    public Player(float mentalHealth){
        this.mentalHealth=mentalHealth;
    }
    public void ChangeMentalHealth(float parameter){
        mentalHealth+=parameter;
    }
}