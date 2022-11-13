public static class ResponseFlagHolder{
    public static int[,] GetResponseFlag(int npcNumber){
        if(npcNumber==0) {
            return new int[,]{{0,0,0,0,0,0,0,0,0,0},{1,2,0,0,0,0,0,0,0,0},{0,3,7,0,4,4,0,0,0,0},{0,0,0,5,5,5,6,0,0,5},{0,0,0,0,0,0,6,0,0,0}};
        }
        else return new int[,]{{0}};
    }
}