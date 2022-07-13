namespace Unit05.Game.Casting{
    public class Spaceship: Actor{
        private bool shoot;
        //makes new instance of a spaceship
        public Spaceship(){
            SetText("||_");
            SetColor(Constants.WHITE);
            SetPosition(new Point(Constants.MAX_X/2,Constants.MAX_Y - Constants.CELL_SIZE));
        }
        //returns the value of if a bullet is being shot
        public bool GetShoot(){
            return shoot;
        }
        //sets the value of if the bullet is being shot
        public void SetShoot(bool set){
            shoot = set;
        }
    }
}