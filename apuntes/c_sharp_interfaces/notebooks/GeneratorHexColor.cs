namespace Generator
{
  public class HexColor
  {
    static Random random = new Random();

    public static string GenerateRandomHexColor()
    {
      // Genera tres componentes de color RGB aleatorios
      int r = random.Next(256); // Valor de rojo (0-255)
      int g = random.Next(256); // Valor de verde (0-255)
      int b = random.Next(256); // Valor de azul (0-255)

      // Convierte los componentes RGB en un código hexadecimal
      string hexColor = $"#{r:X2}{g:X2}{b:X2}";

      return hexColor;
    }
  }
}