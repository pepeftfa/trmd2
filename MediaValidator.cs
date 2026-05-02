using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace misto
{
    internal class MediaValidator
    {
        public static void Validate(string filename, long size)
            {
            if (size <= 0)
                throw new ArgumentException("Розмір файлу повинен бути більшим за нуль!");
            if (size > 5 * 1024 * 1024)
                throw new ArgumentException("Розмір файлу не може перевищувати 5 МБ!");

            string extension = System.IO.Path.GetExtension(filename).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            if (Array.IndexOf(allowedExtensions, extension) < 0)
                throw new ArgumentException("Недопустимий формат файлу! Дозволені формати: .jpg, .jpeg, .png, .gif");
        }
    }
}
