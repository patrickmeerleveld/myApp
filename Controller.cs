using System;

namespace myApp
{
    public class Controller{
        public Controller(){

        }
        public EInput GetInput(){
            ConsoleKeyInfo info = Console.ReadKey(true);
            EInput result = EInput.Unassigned;
                        
            switch(info.Key){
                case ConsoleKey.W:
                    result = EInput.Up;
                break; 
                case ConsoleKey.S:
                    result = EInput.Down;
                break;
                case ConsoleKey.A:   
                    result = EInput.Left;
                break;
                case ConsoleKey.D:
                    result = EInput.Right;
                break;
                case ConsoleKey.Spacebar:
                    result = EInput.Fire1;
                break;
                case ConsoleKey.Enter:
                    result = EInput.Fire2;
                break;
                case ConsoleKey.Escape:
                    result = EInput.ESC;
                break;
                
            }
            return result;
            
        }
    
    }
    public enum EInput {Unassigned, Up, Down, Left, Right, Fire1, Fire2, ESC};
}