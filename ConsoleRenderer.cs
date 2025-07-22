namespace MazeAStar
{
    public class ConsoleRenderer
    {
        private char[,] _pixels;
        private char[,] _previousPixels;
        private int _width;
        private int _height;

        public ConsoleRenderer()
        {
            _width = Console.WindowWidth;
            _height = Console.WindowHeight;
            _pixels = new char[_width, _height];
            _previousPixels = new char[_width, _height];
            Console.CursorVisible = false;
        }

        public void SetPixel(int w, int h, char val)
        {
            _pixels[w, h] = val;
        }

        public void Render()
        {
            for (int w = 0; w < _width; w++)
            {
                for (int h = 0; h < _height; h++)
                {
                    if (_previousPixels[w, h] == _pixels[w, h])
                        continue;

                    Console.SetCursorPosition(w, h);
                    Console.Write(_pixels[w, h]);
                    _previousPixels[w,h] = _pixels[w, h];
                }
            }
        }
    }
}
