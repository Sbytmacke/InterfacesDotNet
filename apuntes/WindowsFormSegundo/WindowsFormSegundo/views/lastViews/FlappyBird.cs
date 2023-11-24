using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormSegundo.views
{
    public partial class FlappyBird : Form
    {
        private Timer timer;
        private List<GraphicsPath> clouds;
        private GraphicsPath bird;
        private int cloudSpeed = 4; // Velocidad de desplazamiento de las nubes
        private int birdY; // Posición vertical del pájaro
        private int birdSpeed = 0; // Velocidad de caída del pájaro

        public FlappyBird()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(OnPaint);
            this.DoubleBuffered = true;

            clouds = new List<GraphicsPath>();

            InitClouds();

            birdY = this.ClientSize.Height / 2; // Inicializar la posición vertical del pájaro

            // Inicializar el temporizador
            timer = new Timer();
            timer.Interval = 30; // Intervalo en milisegundos
            timer.Tick += (_, _) =>
            {
                MoveClouds(); // Mover las nubes
                MoveBird(); // Mover el pájaro
                this.Invalidate();
            };
            timer.Start(); // Comenzar el temporizador

            // Manejar el evento de clic en la pantalla para hacer que el pájaro suba
            this.MouseClick += (sender, e) =>
            {
                birdSpeed = -15; // Hacer que el pájaro suba al hacer clic
            };
        }

        private void InitClouds()
        {
            clouds = new List<GraphicsPath>();

            // Nube 1
            GraphicsPath cloud1 = new GraphicsPath();
            cloud1.AddEllipse(100, 50, 60, 20);
            cloud1.AddEllipse(120, 40, 60, 20);
            cloud1.AddEllipse(140, 50, 60, 20);

            // Nube 2
            GraphicsPath cloud2 = new GraphicsPath();
            cloud2.AddEllipse(220, 70, 80, 30);
            cloud2.AddEllipse(240, 60, 80, 30);
            cloud2.AddEllipse(260, 70, 80, 30);

            // Nube 3
            GraphicsPath cloud3 = new GraphicsPath();
            cloud3.AddEllipse(370, 30, 70, 25);
            cloud3.AddEllipse(390, 20, 70, 25);
            cloud3.AddEllipse(410, 30, 70, 25);

            // Nube 4
            GraphicsPath cloud4 = new GraphicsPath();
            cloud4.AddEllipse(500, 55, 90, 35);
            cloud4.AddEllipse(520, 45, 90, 35);
            cloud4.AddEllipse(540, 55, 90, 35);

            GraphicsPath cloud5 = new GraphicsPath();
            cloud4.AddEllipse(670, 10, 60, 35);
            cloud4.AddEllipse(690, 5, 60, 35);
            cloud4.AddEllipse(710, 10, 60, 35);

            // Agregar todas las nubes a la lista de nubes
            clouds.Add(cloud1);
            clouds.Add(cloud2);
            clouds.Add(cloud3);
            clouds.Add(cloud4);
            clouds.Add(cloud5);
        }


        private void MoveClouds()
        {
            // Mover cada nube horizontalmente
            for (int i = 0; i < clouds.Count; i++)
            {
                GraphicsPath cloud = clouds[i];
                Matrix matrix = new Matrix();
                matrix.Translate(-cloudSpeed, 0);
                cloud.Transform(matrix);
                clouds[i] = cloud;

                // Si una nube se sale de la pantalla, la volvemos a colocar al final
                if (cloud.GetBounds().Right < 0)
                {
                    matrix = new Matrix();
                    matrix.Translate(this.ClientSize.Width, 0);
                    cloud.Transform(matrix);
                    clouds[i] = cloud;
                }
            }
        }

        private void MoveBird()
        {
            // Mover el pájaro verticalmente
            birdY += birdSpeed;
            birdSpeed += 1; // Simular la gravedad

            // Evitar que el pájaro salga de la pantalla en la parte superior
            if (birdY < 0)
            {
                birdY = 0;
                birdSpeed = 1; // Detener la subida cuando llega al límite superior
            }

            // Evitar que el pájaro caiga fuera de la pantalla en la parte inferior
            if (birdY > this.ClientSize.Height)
            {
                birdY = this.ClientSize.Height;
                birdSpeed = 0; // Detener la caída cuando llega al límite inferior
            }
        }

        protected void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color backgroundColor = Color.FromArgb(135, 206, 235);
            this.BackColor = backgroundColor;

            // Dibujar nubes blancas
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            foreach (GraphicsPath cloud in clouds)
            {
                g.FillPath(whiteBrush, cloud);
            }

            // Dibujar el pájaro (círculo rojo)
            SolidBrush redBrush = new SolidBrush(Color.Red);
            bird = new GraphicsPath();
            bird.AddEllipse(this.ClientSize.Width / 4, birdY, 30, 30);
            g.FillPath(redBrush, bird);

            // Restablecer el color para otros elementos
            g.ResetTransform();
        }
    }
}