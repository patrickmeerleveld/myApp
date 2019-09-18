using System;
using System.Threading;
namespace myApp{
    class Player{
        private Position position;
        private int life = 10;
        
        public int GetLife(){
            return life;
        }
        public void SetLife(int life){
            this.life = life;
        }

        public void UpdatePosition(Position newPos){
            position = newPos;
        }
        public Position GetPosition(){
            return position;
        }
        public char TryMove(Grid g, Position dest){
             
             return g.GetFrom(dest);             

        }
    }
}