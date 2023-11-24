using Timer = System.Windows.Forms.Timer;

namespace views;
public partial class PaintView : Form
{
    private Timer timer;
    private int coordinateX;
    private int coordinateY;
    private int moveCoordinateX;
    private int moveCoordinateY;
    private Font textFontStandart;
    private string textLine1;
    private string textLine2;
    private Color[] colors;
    private int currentColorIndex;
    private Random random;
    private Rectangle textHitbox;

    public PaintView()
    {
        InitializeComponent();
        this.Paint += new PaintEventHandler(PaintForm_Paint);
        this.DoubleBuffered = true;

        this.ClientSize = new Size(500, 500);

        textLine1 = "DVD";
        textLine2 = "Studio";
        textFontStandart = new Font("Arial", 16);
        colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Orange };
        currentColorIndex = 0;
        random = new Random();

        coordinateX = random.Next(50, this.ClientSize.Width / 4);
        coordinateY = random.Next(50, this.ClientSize.Height / 4);
        // Con TextRenderer.MeasureText se calcula la anchura y altura del texto, así calculamos el tamaño de la hitbox
        int widhtHitbox = TextRenderer.MeasureText(textLine2, textFontStandart).Width;
        int heightHitbox = (TextRenderer.MeasureText(textLine1, textFontStandart).Height + TextRenderer.MeasureText(textLine2, textFontStandart).Height);
        textHitbox = new Rectangle(coordinateX, coordinateY, widhtHitbox, heightHitbox);

        moveCoordinateX = 2;
        moveCoordinateY = 2;

        // Cambiamos el color del texto cuando clicamos
        this.MouseClick += new MouseEventHandler(OnClickChangeColor);

        // Cada 10 milisegundos se desplaza
        timer = new Timer();
        timer.Interval = 10;
        timer.Tick += (_, _) =>
        {
            // Rebotar en los bordes del formulario
            if (coordinateX + textHitbox.Width > this.ClientSize.Width || coordinateX < 0)
            {
                // Invertimos el valor del desplazamiento
                moveCoordinateX = -moveCoordinateX;
                ChangeColor();
            }
            if (coordinateY + textHitbox.Height > this.ClientSize.Height || coordinateY < 0)
            {
                // Invertimos el valor del desplazamiento
                moveCoordinateY = -moveCoordinateY;
                ChangeColor();
            }

            // Actualizamos las coordenadas
            coordinateX += moveCoordinateX;
            coordinateY += moveCoordinateY;

            // Actualizamos la hitbox
            textHitbox.X = coordinateX;
            textHitbox.Y = coordinateY;

            this.Invalidate();
        };
        timer.Start();
    }

    private void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
    }

    private void OnClickChangeColor(object sender, MouseEventArgs e)
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
    }

    protected void PaintForm_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        this.BackColor = Color.Black;

        int CoordenateXtoPintText1 = coordinateX + TextRenderer.MeasureText(textLine1, textFontStandart).Width / 6;
        g.DrawString(textLine1, textFontStandart, new SolidBrush(colors[currentColorIndex]), CoordenateXtoPintText1, coordinateY);

        int diskWidth = TextRenderer.MeasureText(" ", textFontStandart).Width * 4;
        int diskHeight = TextRenderer.MeasureText(" ", textFontStandart).Height;
        g.FillEllipse(new SolidBrush(colors[currentColorIndex]), coordinateX, coordinateY + TextRenderer.MeasureText(textLine1, textFontStandart).Height, diskWidth, diskHeight);
        g.DrawString(textLine2, textFontStandart, new SolidBrush(Color.Black), coordinateX, coordinateY + TextRenderer.MeasureText(textLine1, textFontStandart).Height);
    }
}
