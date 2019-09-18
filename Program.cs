using System;
using System.Threading;
using System.Collections.Generic;

namespace myApp
{
    class Program
    {

       // private Int32 age;
        static void Main(string[] args)
        {
            //setup the level
            Grid g = new Grid();
            g.add(new char [,]
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#',' ','#','X',' ','#',' ',' ',' ',' ','X','@'},
                {'#',' ','X',' ',' ','#',' ',' ',' ',' ',' ','#'},
                {'#','P','#','#',' ','#',' ',' ','X',' ',' ','#'},
                {'#',' ','#','#','X','#',' ',' ',' ',' ',' ','#'},
                {'#',' ','#','#',' ','#',' ',' ',' ',' ',' ','#'},
                {'#',' ','#','#',' ','#',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ','#',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ','#',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#'}                
            });           


            GridPainter gp = new GridPainter(g);
            gp.PaintGrid();                    
         
            //setup player
            Player player = new Player();
            Position playerPos = g.Find('P')[0];        
            player.UpdatePosition(playerPos);
            
            //setup level objects and enemies
            List<Enemy> enemies = new List<Enemy>();
            List<Position> enemyPositions = g.Find('X');
            for(int i = 0; i < enemyPositions.Count;i++){
                enemies.Add(new Enemy());
                enemies[i].UpdatePosition(enemyPositions[i]);
                enemies[i].SetLife(10);
            }
            //setup the controller
            Controller c = new Controller();

            //player behaviour after input
            while(IsRunning()){
                Position oldPos = player.GetPosition();   
                Position dest = new Position(oldPos.x, oldPos.y);
                switch(c.GetInput()){
                    case EInput.Up:                          
                        dest.y--;                                              
                    break;
                    case EInput.Down:
                        dest.y++;
                    break;
                    case EInput.Left:
                        dest.x--;                        
                    break;
                    case EInput.Right:
                        dest.x++;                        
                    break;
                    case EInput.ESC:
                    runState = false;
                    break;  
                }     
                char destChar = player.TryMove(g,dest);    
                
                if(destChar == '#'){                            
                    Console.Beep(1200,500);                                      
                }else if(destChar =='X'){               
                    Console.Beep(900,100);
                    g.Replace(dest,'*');
                    Console.Clear();
                    gp.PaintGrid();    
                    Thread.Sleep(500);
                    g.Replace(dest,'X');
                    Enemy currentEnemy = null;
                    foreach(Enemy e in enemies){
                        if(e.GetPosition().x == dest.x && e.GetPosition().y == dest.y){
                            
                            currentEnemy = e;
                            break;
                        }
                    }
                    if(currentEnemy!=null){
                        Random r = new Random();   

                        
                        
                        currentEnemy.SetLife(currentEnemy.GetLife()-r.Next(0,5));
                        player.SetLife(player.GetLife()-r.Next(0,5));
                        if(currentEnemy.GetLife() <= 0){
                            enemies.Remove(currentEnemy);
                            g.Replace(dest,' ');
                        }
                        if(player.GetLife() <= 0){
                            Console.Clear();
                            Console.WriteLine("You Died!");
                            runState = false;
                            break;

                        }
                    }



                }else if(destChar == '@'){
                    Console.Clear();
                    Console.WriteLine("You Escaped!");
                    runState = false;
                    break;
                }
                else
                {
                    g.Replace(player.GetPosition(),' ');                        
                    player.UpdatePosition(dest);
                    g.Replace(dest,'P');      
                }
                Console.Clear();
                gp.PaintGrid();     
                
                     
            }     
            

            

           
        }
       
        private static bool runState = true;
        private static bool IsRunning()
        {
            return runState;
        }



         /* 
            Thread ct = Thread.CurrentThread;
            Console.BackgroundColor = ConsoleColor.Cyan;

            
            Console.WriteLine("Vul je leeftijd in");

            String input = Console.ReadLine();
            int inte = Convert.ToInt32(input);
            string s = Convert.ToString(input);



            Console.WriteLine("jij bent " + inte + " jaar oud");


            

            
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Beep(800,200);
            Console.WriteLine("1");
            
            
            Thread.Sleep(500);
            
           // Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Beep(900,300);
            Console.WriteLine("2");
            

            Thread.Sleep(500);

            //Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Beep(1000, 400);
            Console.WriteLine("3");

            Thread.Sleep(500);

            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

*/
        
    }
}
