using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Paint
{
    public class ColorViewModel
    {
        public string Name { get; set; }
        public SolidColorBrush Brush { get; set; }
    }

    public partial class MainWindow : Window
    {

        public ObservableCollection<ColorViewModel> Colors { get; set; }

        private Stack<StrokeCollection> undoStack = new Stack<StrokeCollection>();

        private Stack<StrokeCollection> redoStack = new Stack<StrokeCollection>();

        private Point startPoint;
        private Shape currentShape;
        private ShapeType currentShapeType;

        public enum ShapeType
        {
            RECTANGLE,
            ELLIPSE,
            NO_SHAPE
        }

        private TranslateTransform menuTransform;
        private bool isMenuVisible = true;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAnimations();
            InitColors();
            InitThickness();
            ic.MouseDown += InkCanvas_MouseDown;
            ic.MouseMove += InkCanvas_MouseMove;
            ic.MouseUp += InkCanvas_MouseUp;
        }

        private void InitializeAnimations()
        {
            menuTransform = new TranslateTransform();
            MenuTransform.RenderTransform = menuTransform;
        }

        private void OnEditionClick(object sender, RoutedEventArgs e)
        {
            if (isMenuVisible)
            {
                AnimateMenu(-250, TimeSpan.FromSeconds(0.3));
                menuColumn.Width = new GridLength(0, GridUnitType.Star);
                Grid.SetColumnSpan(ic, 2);
            }
            else
            {
                AnimateMenu(0, TimeSpan.FromSeconds(0.3));
                menuColumn.Width = GridLength.Auto;
                Grid.SetColumnSpan(ic, 1);
            }

            isMenuVisible = !isMenuVisible;
        }

        private void AnimateMenu(double toValue, TimeSpan duration)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                To = toValue,
                Duration = duration
            };

            menuTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        }

        private void InitColors()
        {
            // Mediante reflexión conseguimos los colores que tiene por defecto la clase Colors
            var colorProperties = typeof(Colors).GetProperties();

            Colors = new ObservableCollection<ColorViewModel>(
                colorProperties.Select(property => new ColorViewModel
                {
                    Name = property.Name,
                    Brush = new SolidColorBrush((Color)property.GetValue(null))
                })
            );

            colorComboBox.ItemsSource = Colors;
            colorComboBox.SelectedIndex = 7; // Asignamos el negro por defecto
            colorComboBox.DisplayMemberPath = "Name";
        }

        private void InitThickness()
        {
            var valuesThickness = new ObservableCollection<int> { 1, 3, 5, 8 };
            thicknessComboBox.ItemsSource = valuesThickness;
            thicknessComboBox.SelectedIndex = 1;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (.png)|*.png|ISF Documents (.isf)|*.isf";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;
                string fileExtension = System.IO.Path.GetExtension(filePath);

                if (fileExtension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    LoadPNG(filePath);
                }
                else if (fileExtension.Equals(".isf", StringComparison.OrdinalIgnoreCase))
                {
                    LoadISF(filePath);
                }
            }
        }

        private void LoadPNG(string imagePath)
        {
            BitmapImage image = new BitmapImage(new Uri(imagePath));
            Image img = new Image { Source = image };
            ic.Children.Add(img);
        }

        private void LoadISF(string isfPath)
        {
            using (FileStream fs = new FileStream(isfPath, FileMode.Open))
            {
                StrokeCollection loadedStrokes = new StrokeCollection(fs);
                ic.Strokes = loadedStrokes;
            }
        }

        private void SaveAsIsf_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Drawing";
            dialog.DefaultExt = ".isf";
            dialog.Filter = "ISF Documents (.isf)|*.isf";

            var result = dialog.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.Create))
                {
                    ic.Strokes.Save(fs);
                }
            }
        }

        private void SaveAsPNG_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Image Files (*.png)|*.png",
                DefaultExt = "png"
            };

            if (saveDialog.ShowDialog() == true)
            {
                SaveInkCanvasAsPNG(ic, saveDialog.FileName);
            }
        }

        private void SaveInkCanvasAsPNG(InkCanvas inkCanvas, string filePath)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)inkCanvas.ActualWidth,
                (int)inkCanvas.ActualHeight,
                96d,
                96d,
                PixelFormats.Pbgra32
            );

            renderBitmap.Render(inkCanvas);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }

        private void SelectThickness(object sender, SelectionChangedEventArgs e)
        {
            int selectedThickness = (int)thicknessComboBox.SelectedItem;
            ic.DefaultDrawingAttributes.Width = selectedThickness;
        }

        private void SelectColor(object sender, SelectionChangedEventArgs e)
        {
            var selectedColor = ((ColorViewModel)colorComboBox.SelectedItem).Brush.Color;
            ic.DefaultDrawingAttributes.Color = selectedColor;
        }

        private void ToggleStroke(object sender, RoutedEventArgs e)
        {
            ic.EditingMode = InkCanvasEditingMode.Ink;

            ic.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
            int selectedIndex = thicknessComboBox.SelectedIndex;

            // Para que no salte excepción, ajustamos selectedIndex para que esté dentro del rango permitido
            double adjustedThickness = Math.Max(Math.Min(selectedIndex, ic.DefaultDrawingAttributes.Width), ic.DefaultDrawingAttributes.Height);

            ic.DefaultDrawingAttributes.Height = adjustedThickness;
            ic.DefaultDrawingAttributes.Width = adjustedThickness;

            ic.DefaultDrawingAttributes.IsHighlighter = false;
            if (toggleRectangle != null)
            {
                toggleRectangle.IsChecked = false;
                toggleEllipse.IsChecked = false;
            }

        }

        private void ToggleSelection(object sender, RoutedEventArgs e)
        {
            ic.EditingMode = InkCanvasEditingMode.Select;
            toggleRectangle.IsChecked = false;
            toggleEllipse.IsChecked = false;
        }

        private void ToggleMarkup(object sender, RoutedEventArgs e)
        {
            ic.EditingMode = InkCanvasEditingMode.Ink;
            ic.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
            ic.DefaultDrawingAttributes.Height = 20;
            ic.DefaultDrawingAttributes.IsHighlighter = true;
            toggleRectangle.IsChecked = false;
            toggleEllipse.IsChecked = false;
        }

        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (undoStack.Count == 1)
            {
                redoStack.Push(new StrokeCollection(ic.Strokes));
                ic.Strokes.Clear();
                return;
            }
            if (undoStack.Count > 1)
            {
                var currentState = undoStack.Pop();
                redoStack.Push(new StrokeCollection(ic.Strokes));
                ic.Strokes = currentState;
            }
        }

        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (redoStack.Count > 0)
            {
                var nextState = redoStack.Pop();
                undoStack.Push(new StrokeCollection(ic.Strokes));
                ic.Strokes = nextState;
            }
        }

        private void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = undoStack.Count > 0;
        }

        private void RedoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = redoStack.Count > 0;
        }

        // Evento para registrar cambios antes de realizar una nueva acción
        private void AddChangesFromStrokes(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            undoStack.Push(new StrokeCollection(ic.Strokes));
            redoStack.Clear();
        }

        private void ToggleEraseByStroke(object sender, RoutedEventArgs e)
        {
            if (toggleEraseByStroke.IsChecked == true)
            {
                ic.EditingMode = InkCanvasEditingMode.EraseByStroke;
                toggleEraseByPoint.IsChecked = false;
            }
            else
            {
                ic.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        private void ToggleEraseByPoint(object sender, RoutedEventArgs e)
        {
            if (toggleEraseByPoint.IsChecked == true)
            {
                ic.EditingMode = InkCanvasEditingMode.EraseByPoint;
                toggleEraseByStroke.IsChecked = false;
            }
            else
            {
                ic.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        private void InkCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(ic);

            switch (currentShapeType)
            {

                case ShapeType.RECTANGLE:
                    currentShape = new Rectangle
                    {
                        Width = 0,
                        Height = 0,
                        Stroke = new SolidColorBrush(ic.DefaultDrawingAttributes.Color),
                        StrokeThickness = ic.DefaultDrawingAttributes.Width
                    };
                    break;

                case ShapeType.ELLIPSE:
                    currentShape = new Ellipse
                    {
                        Width = 0,
                        Height = 0,
                        Stroke = new SolidColorBrush(ic.DefaultDrawingAttributes.Color),
                        StrokeThickness = ic.DefaultDrawingAttributes.Width
                    };
                    break;

                case ShapeType.NO_SHAPE:
                    return;


                default:
                    throw new ArgumentOutOfRangeException();
            }

            InkCanvas.SetLeft(currentShape, startPoint.X);
            InkCanvas.SetTop(currentShape, startPoint.Y);

            ic.Children.Add(currentShape);
        }

        private void InkCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentShape != null)
            {
                double width = Math.Abs(e.GetPosition(ic).X - startPoint.X);
                double height = Math.Abs(e.GetPosition(ic).Y - startPoint.Y);

                currentShape.Width = width;
                currentShape.Height = height;
            }
        }

        private void InkCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            currentShape = null;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            if (toggleRectangle.IsChecked == true)
            {
                ic.EditingMode = InkCanvasEditingMode.None;
                currentShapeType = ShapeType.RECTANGLE;
                toggleEllipse.IsChecked = false;
                toggleStroke.IsChecked = false;
                toggleMarkup.IsChecked = false;
                toggleSelection.IsChecked = false;
            }
            else
            {
                currentShapeType = ShapeType.NO_SHAPE;
            }
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            if (toggleEllipse.IsChecked == true)
            {
                ic.EditingMode = InkCanvasEditingMode.None;
                currentShapeType = ShapeType.ELLIPSE;
                toggleRectangle.IsChecked = false;
                toggleStroke.IsChecked = false;
                toggleMarkup.IsChecked = false;
                toggleSelection.IsChecked = false;
            }
            else
            {
                currentShapeType = ShapeType.NO_SHAPE;
            }
        }
    }
}
