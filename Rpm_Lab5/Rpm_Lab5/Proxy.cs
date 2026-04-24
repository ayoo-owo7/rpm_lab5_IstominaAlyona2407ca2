using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpm_Lab5
{
    public interface IDrawable
    {
        void Draw();
    }

    public interface IImage : IDrawable
    {
        int GetWidth();
        int GetHeight();
    }

    public class HighResolutionImage : IImage
    {
        private string _filename;
        private int _width;
        private int _height;

        public HighResolutionImage(string filename)
        {
            _filename = filename;
            Console.Write($"[Proxy] Loading {_filename}... ");
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            System.Threading.Thread.Sleep(1000);
            _width = 1920;
            _height = 1080;
            Console.WriteLine($"Loaded ({_width}x{_height})");
        }

        public void Draw()
        {
            Console.WriteLine($"[Image] Drawing image {_filename}");
        }

        public int GetWidth() => _width;
        public int GetHeight() => _height;
    }

    public class ImageProxy : IImage
    {
        private string _filename;
        private HighResolutionImage _realImage;

        public ImageProxy(string filename)
        {
            _filename = filename;
            Console.WriteLine($"[Proxy] Proxy created for {_filename} (not loaded yet)");
        }

        private void EnsureLoaded()
        {
            if (_realImage == null)
            {
                _realImage = new HighResolutionImage(_filename);
            }
        }

        public void Draw()
        {
            EnsureLoaded();
            _realImage.Draw();
        }

        public int GetWidth()
        {
            EnsureLoaded();
            return _realImage.GetWidth();
        }

        public int GetHeight()
        {
            EnsureLoaded();
            return _realImage.GetHeight();
        }
    }
}
