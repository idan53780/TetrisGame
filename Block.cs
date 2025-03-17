using System.Collections.Generic; 

namespace TetrisVV1
{
    public abstract  class Block
    {
        protected abstract Position[][] Tiles {  get; }
        protected abstract Position Startoffset { get; }

        public abstract int Id { get; }

        private int rotationState;
        protected Position offset;

        public Block ()
        {
            offset = new Position(Startoffset.Row, Startoffset.Column);

        }

        public IEnumerable <Position> Tilepositions()
        {
            foreach ( Position p in Tiles[rotationState] )
            {
                yield return new Position (p.Row + offset.Row, p.Column + offset.Column) ;
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            if (rotationState == 0)
                rotationState = Tiles.Length - 1;
            else 
                rotationState--;

        }

        public void Move(int rows,int columns)
        {
            offset.Row += rows;
            offset.Column += columns;

        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = Startoffset.Row;
            offset.Column = Startoffset.Column;
        }
    }
}
