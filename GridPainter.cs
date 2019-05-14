using System;
namespace myApp
{
    class GridPainter
    {
        private Grid grid;
        public GridPainter(Grid g)
        {
            grid = g;

        }
        public void PaintGrid()
        {
            for(int y = 0; y < grid.Get2DArray().GetLength(0); y++)
            {
                for(int x = 0; x < grid.Get2DArray().GetLength(1); x++)
                {
                    Console.Write(grid.Get2DArray()[y,x]);
                }    
                Console.Write(System.Environment.NewLine);
            }

        }

    }

}
