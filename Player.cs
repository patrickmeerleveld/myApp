using System;
using System.Threading;
namespace myApp{
    class Player{
        private Position position;
        
        public void UpdatePosition(Position newPos){
            position = newPos;
        }
        public Position GetPosition(){
            return position;
        }
        public void TryMove(Grid g, Position dest, GridPainter gp){
             if(g.GetFrom(dest) == '#'){                            
                Console.Beep(1200,500);                                      
            }else if(g.GetFrom(dest)=='X'){
                Console.Beep(900,100);
                g.Replace(dest,'*');
                Console.Clear();
                gp.PaintGrid();    
                
                Thread.Sleep(500);
                g.Replace(dest,'X');
            }else{
                g.Replace(position,' ');                        
                this.UpdatePosition(dest);
                g.Replace(dest,'P');      
            }
            Console.Clear();
            gp.PaintGrid();

        }
    }
}