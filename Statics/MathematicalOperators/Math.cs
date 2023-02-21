public static class Math{
    public static float DistanceSquare(float x1,float x2,float y1,float y2){
        return (x1-x2)*(x1-x2)+(y1-y2)*(y1-y2);
    }
    public static float IntervalCalculator(){
        System.Random rnd=new System.Random();
        int rndNumber=rnd.Next(0,8);
        return 6-ShopStats.popularity+rndNumber;
    }
}