namespace Unit05.Game.Casting{
    //bullets destroy targets and give points
    public class Bullet : Actor{
        //creates new instance of bullet
        public Bullet(){
            SetText("|");
            SetColor(Constants.RED);
            SetVelocity(new Point(0,-Constants.CELL_SIZE));
        }
    }
}