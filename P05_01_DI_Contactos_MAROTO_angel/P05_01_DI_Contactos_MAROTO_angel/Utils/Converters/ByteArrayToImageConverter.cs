using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace P05_01_DI_Contactos_MAROTO_angel.Utils.Converters;

public class ByteArrayToImageConverter : IValueConverter
{
    private static BitmapImage LoadImage(byte[] imageBytes)
    {
        if (imageBytes == null || imageBytes.Length == 0)
        {
            return LoadDefaultImage();
        }

        using (MemoryStream memoryStream = new MemoryStream(imageBytes))
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = memoryStream;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            image.Freeze();
            return image;
        }
    }

    private static BitmapImage LoadDefaultImage()
    {
        byte[] imageBytes = Resources.Images.ResourcesImages.user_default;

        try
        {
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = memoryStream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar la imagen por defecto: {ex.Message}");
            return null;
        }
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var imageByteArray = value as byte[];
        return LoadImage(imageByteArray);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}

