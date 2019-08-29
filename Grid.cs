using System;
using System.Collections.Generic;
namespace myApp{
    public class Grid
    {
        private char [,] grid;
        public void add(char [,] grid ){
            this.grid = grid;            
        }
        public char [,] Get2DArray(){
            return grid;
        }
        private Position pos = new Position(0,0);
        public List<Position> Find(char toFind){
        
            List<Position> positions = new List<Position>();
           for(int y = 0; y < grid.GetLength(0);y++){
               for(int x = 0; x < grid.GetLength(1);x++){
                   if(grid[y,x] == toFind){
                       Position pos = new Position(x,y);
                       positions.Add(pos);
                   }
               }
           }
           return positions;
        }
        public void Replace(Position p, char replaceWith){
            this.grid[p.y,p.x] = replaceWith;
        }
        public char GetFrom(Position p){
            return this.grid[p.y,p.x];
        }
    }
}