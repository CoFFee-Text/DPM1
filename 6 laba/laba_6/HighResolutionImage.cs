using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    // Интерфейс для всех отрисовываемых элементов
    public interface IDrawable
    {
        void Draw();
    }
    // Интерфейс для графических объектов (изображений)
    public interface IImage : IDrawable
    {
        int GetWidth();
        int GetHeight();
    }
    // Реальный объект (тяжёлое изображение)
    public class HighResolutionImage : IImage
    {
        private string _filename;
        private int _width;
        private int _height;
        public HighResolutionImage(string filename)
        {
            _filename = filename;
            Console.Write($"Loading {_filename}... ");
            LoadFromDisk();
        }
        private void LoadFromDisk()
        {
            // Имитация долгой загрузки
            Thread.Sleep(1000);
            _width = 1920;
            _height = 1080;
            Console.WriteLine($"Uploaded ({_width}x{_height})");
        }
        public void Draw()
        {
            Console.WriteLine($"Rendering an image {_filename}");
        }
        public int GetWidth()
        {
            return _width;
        }
        public int GetHeight()
        {
            return _height;
        }
    }
    // Proxy (заместитель)
    public class ImageProxy : IImage
    {
        private string _filename;
        private HighResolutionImage _realImage;
        public ImageProxy(string filename)
        {
            _filename = filename;
            Console.WriteLine($"Created proxy for {_filename}");
        }
        private void EnsureLoaded()
        {
            //ПРОВЕРИТЬ, СОЗДАН ЛИ _realImage. ЕСЛИ НЕТ, ТО СОЗДАТЬ
            if (_realImage == null)
            {
                _realImage = new HighResolutionImage(_filename);
            }
        }
        public void Draw()
        {
            EnsureLoaded();
            //Обратиться к соответствующему методу realImage.
            _realImage.Draw();
        }
        public int GetWidth()
        {
            EnsureLoaded();
            //Обратиться к соответствующему методу realImage.
            return _realImage.GetWidth();
        }
        public int GetHeight()
        {
            EnsureLoaded();
            //Обратиться к соответствующему методу realImage.
            return _realImage.GetHeight();
        }
    }
}
